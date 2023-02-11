using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardGUI : MonoBehaviour
{
    [SerializeField] GameObject linePrefab;
    [SerializeField] GameObject parentForLines;
    [SerializeField] GameObject endGameScore;
    private void Start() {
        endGameScore.SetActive(false);
    }
    public void Clear()
    {
        for (int i = parentForLines.transform.childCount - 1; i >= 0 ; i--)
        {
            Destroy(parentForLines.transform.GetChild(i).gameObject);
        }
    }
    public void ShowEntrys(List<LeaderboardDataGUI> dataList)
    {
        foreach (var data in dataList)
        {
            GameObject lineEntry = Instantiate(linePrefab, parentForLines.transform);
            lineEntry.GetComponent<LeaderboardLinePrefab>().Init(data);
        }
    }
    public void ShowActualScore(LeaderboardDataGUI leaderboardData)
    {
        endGameScore.SetActive(true);
        endGameScore.GetComponent<LeaderboardLinePrefab>().Init(leaderboardData);        
    }
    public void ResetGame()
    {
        endGameScore.SetActive(false);
        FindObjectOfType<GameManager>().RestartGame();
    }
}
public struct LeaderboardDataGUI
{
    public string rank;
    public string name;
    public string score;
    public LeaderboardDataGUI(string rank, string name, string score)
    {
        this.rank = rank;
        this.name = name;
        this.score = score;
    }
}
