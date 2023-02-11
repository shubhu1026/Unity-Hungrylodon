using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using LootLocker.Requests;

public class GameManager : MonoBehaviour
{
    [SerializeField] float spawnInterval = 0.5f;
    [SerializeField] GameObject anchors;
    public Action OnGameReset;
    public bool isGameActive = false;
    //public int spawnedFishCount = 0; 
    private float movementSpeedMultiplier = 1f;
    private float dashForceMultiplier = 1f;
    private bool invertControls = false;

    public float SpawnInterval{ get{return spawnInterval;} set{spawnInterval = value;}}
    public static GameManager gameInstance;

    //getter and setter
    //public int SpawnedFishCount {get{return spawnedFishCount;} set{spawnedFishCount = value;}}
    public float MovementSpeedMultiplier {get{return movementSpeedMultiplier;} set{movementSpeedMultiplier = value;}}
    public float DashForceMultiplier {get{return dashForceMultiplier;} set{dashForceMultiplier = value;}}
    public bool InvertControls {get{return invertControls;} set{invertControls = value;}}

    int fishCount = 0;

    
    void Awake()
    {
        if(gameInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        gameInstance = this;
        DontDestroyOnLoad(gameObject);        
    }

    void Start() 
    {        
        StartGame();
    }

    public void StartGame()
    {        
        isGameActive = true;
        ResetVariables();
    }

    void ResetVariables()
    {
        OnGameReset?.Invoke();
        //spawnedFishCount = 0;
        movementSpeedMultiplier = 1;
        dashForceMultiplier = 1f;
        invertControls = false;        
    }

    void Update()
    {
        /*
        if (spawnedFishCount >= maxFishToBeSpawned)
        {
            GameOver();
        }
        */
    }
    
    public void GameOver()
    {
        Debug.Log("end game");
        isGameActive = false;
        
        
        StartCoroutine(EndGamecoroutine(EndGameMenu));

        //FindObjectOfType<CanvasController>().ShowLeaderboardGui();
        // RestartGame();
    }
    private void EndGameMenu()
    {
        CanvasController canvasController = FindObjectOfType<CanvasController>();
        canvasController.ShowEndLeaderboardGui();
        
        FindObjectOfType<Leaderboard>().ShowActualScore();
    }
    IEnumerator EndGamecoroutine(Action endAction)
    {
        yield return FindObjectOfType<Leaderboard>().SubmitScoreRoutine(FindObjectOfType<Score>().GetScore());
        yield return FindObjectOfType<Leaderboard>().FetchTopHighscoresRoutine();
        endAction();
        StopAllCoroutines();
        Debug.Log("end coroutine ended");
    }
    public void RestartGame()
    {
        Debug.Log("reset game");
        //ResetVariables();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        var powerups = FindObjectsOfType<PowerupsMoveAnimation>();
        for (int i = powerups.Length - 1; i >= 0 ; i--)
        {
            Destroy(powerups[i].gameObject);
        }
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        playerMovement.transform.position = Vector3.zero;
        playerMovement.transform.localScale = new Vector3(-1, 1, 1);
        FindObjectOfType<CanvasController>().ResetGame();
        Destroy(FindObjectOfType<Anchors>().gameObject);
        Instantiate(anchors);
        StartGame();        
    }

    public int GetFishCount()
    {
        fishCount = GameObject.FindGameObjectsWithTag("Fish").Length;
        return fishCount;
    }
/*
    public int GetSpawnedFishCount()
    {
        return spawnedFishCount;
    }*/
}
