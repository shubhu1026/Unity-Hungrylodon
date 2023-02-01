using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive = false;
    public int spawnedFishCount = 0;

    //getter and setter
    public int SpawnedFishCount {get{return spawnedFishCount;} set{spawnedFishCount = value;}}

    int fishCount = 0;

    void Start()
    {
        isGameActive = true;
    }

    void Update()
    {
        if(spawnedFishCount >= 50)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameActive = false;
        // RestartGame();
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public int GetFishCount()
    {
        fishCount = GameObject.FindGameObjectsWithTag("Fish").Length;
        return fishCount;
    }

    public int GetSpawnedFishCount()
    {
        return spawnedFishCount;
    }
}
