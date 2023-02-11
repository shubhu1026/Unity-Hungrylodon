using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    public static Leaderboard Instance;
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);        
    }
    [SerializeField] TMP_InputField playerNameInputField;
    [SerializeField] LeaderboardGUI gui;
    [SerializeField] int maxShowedScores = 6;
    string playerName;
    string leaderboardID = "11534";
    // Start is called before the first frame update
        void Start()
    {
        StartCoroutine(SetupRoutine());
    }

    public void SetPlayerName()
    {
        string tempText = playerNameInputField.text;
        if(tempText.Length < 11) playerName = tempText;
        else playerName = tempText.Substring(0, 10);
        
    }    
    IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        yield return FetchTopHighscoresRoutine();
    }

    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession(
            (response) =>
            {
                if(response.success)
                {
                    Debug.Log("Player was logged in");
                    PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                    done = true;
                }
                else
                {
                    Debug.Log("Could not start session");
                    done = true;
                }
            }
        );
        
        yield return new WaitWhile(() => done == false);
    }

    public IEnumerator SubmitScoreRoutine(int scoreToUpload)
    {
        string playerID = PlayerPrefs.GetString("PlayerID");
        bool scoreCheck = false;
        bool isBetterScore = false;
        LootLockerSDKManager.GetMemberRank(leaderboardID, playerID, (response) =>
        {
            if (response.statusCode == 200) {
                Debug.Log("Successful");
                if (response.score > scoreToUpload)
                {
                    Debug.Log("score is not better");
                    scoreCheck = true;
                    return;
                }
                else
                {
                    scoreCheck = true;
                    isBetterScore = true;
                }
            } else {
                Debug.Log("failed: " + response.Error);
            }
        });
        yield return new WaitWhile(() => !scoreCheck);
        if(!isBetterScore) yield break;
        bool setName = false;
        LootLockerSDKManager.SetPlayerName(playerName, (response) =>
        {
            if(response.success)
            {
                setName = true;
                Debug.Log("Succesfully set player name");
            }
            else
            {
                Debug.Log("Could not set player name" + response.Error);
                setName = true;
            }
        });
        yield return new WaitWhile(() => setName == false);
        bool done = false;        
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardID, (response) =>
            {
                if(response.success)
                {
                    Debug.Log("Successfully uploaded score");
                    done = true;
                }
                else
                {
                    Debug.Log("Failed" + response.Error);
                    done = true;
                }
            }
        );
        yield return new WaitWhile(() => done == false);
    }

    public IEnumerator FetchTopHighscoresRoutine()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreList(leaderboardID, 10, 0, (response) =>
        {
            if(response.success)
            {
                //string tempPlayerNames = "Names\n";
                //string tempPlayerScores = "Scores\n";

                LootLockerLeaderboardMember[] members = response.items;
                List<LeaderboardDataGUI> leaderboardDatas = new();
                int size = Mathf.Min(members.Length, maxShowedScores);
                for(int i = 0; i < size; i++)
                {
                    LeaderboardDataGUI leaderboardData = new LeaderboardDataGUI(
                            members[i].rank.ToString(),
                            members[i].player.name != "" ? members[i].player.name : members[i].player.id.ToString(),
                            members[i].score.ToString()
                            );
                    leaderboardDatas.Add(leaderboardData);
                    /*
                    tempPlayerNames += members[i].rank + ". ";
                    if(members[i].player.name != "")
                    {
                        tempPlayerNames += members[i].player.name;
                    }
                    else
                    {
                        tempPlayerNames += members[i].player.id;
                    }

                    tempPlayerScores += members[i].score + "\n";
                    tempPlayerNames += "\n";
                    */
                }
                gui.Clear();
                gui.ShowEntrys(leaderboardDatas);
                done = true;
                //playerNames.text = tempPlayerNames;
                //playerScores.text = tempPlayerScores;
            }
            else
            {
                Debug.Log("Failed" + response.Error);
                done = true;
            }
        });

        yield return new WaitWhile(() => done == false);
    }

    public void ShowLeaderboard()
    {
        StartCoroutine(FetchTopHighscoresRoutine());
    }
    public void ShowActualScore()
    {
        LeaderboardDataGUI leaderboardDataGUI = new LeaderboardDataGUI(
            "",
            playerName,
            FindObjectOfType<Score>().GetScore().ToString()
        );
        gui.ShowActualScore(leaderboardDataGUI);
    } 
}