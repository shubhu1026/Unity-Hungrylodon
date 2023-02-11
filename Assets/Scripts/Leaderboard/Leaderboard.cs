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
    string leaderboardID = "11534";
    // Start is called before the first frame update
        void Start()
    {
        StartCoroutine(SetupRoutine());
    }

    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInputField.text, (response) =>
        {
            if(response.success)
            {
                Debug.Log("Succesfully set player name");
            }
            else
            {
                Debug.Log("Could not set player name" + response.Error);
            }
        });
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
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
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
}