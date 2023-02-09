using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] float spawnInterval = 0.5f;
    [SerializeField] int maxFishToBeSpawned = 50;
    public Action OnGameReset;
    public bool isGameActive = false;
    public int spawnedFishCount = 0; 
    private float movementSpeedMultiplier = 1f;
    private float dashForceMultiplier = 1f;
    private bool invertControls = false;

    public float SpawnInterval{ get{return spawnInterval;} set{spawnInterval = value;}}
    public static GameManager gameInstance;

    //getter and setter
    public int SpawnedFishCount {get{return spawnedFishCount;} set{spawnedFishCount = value;}}
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
        spawnedFishCount = 0;
        movementSpeedMultiplier = 1;
        dashForceMultiplier = 1f;
        invertControls = false;        
    }

    void Update()
    {
        if (spawnedFishCount >= maxFishToBeSpawned)
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
