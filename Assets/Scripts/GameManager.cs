using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] float spawnInterval = 0.5f;
    public bool isGameActive = false;
    public int spawnedFishCount = 0;
    private TextMeshProUGUI tmproScore;
    private float _score;
    public float Score
    { 
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            UpdateScoreGUI();
        } 
    }

    public float SpawnInterval{ get{return spawnInterval;} set{spawnInterval = value;}}

    public static GameManager gameInstance;

    //getter and setter
    public int SpawnedFishCount {get{return spawnedFishCount;} set{spawnedFishCount = value;}}

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
        tmproScore = FindObjectOfType<Score>().GetComponent<TextMeshProUGUI>();
    }

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

    private void UpdateScoreGUI()
    {
        tmproScore.text = Mathf.RoundToInt(_score).ToString();
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
