using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameOverTest : MonoBehaviour
{
    [SerializeField] Leaderboard leaderboard;
    [SerializeField] int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GameOver", 5);
    }

    void GameOver()
    {
        StartCoroutine(GameOverRoutine());
    }
    
    IEnumerator GameOverRoutine()
    {
        yield return leaderboard.SubmitScoreRoutine(score);
    }
}