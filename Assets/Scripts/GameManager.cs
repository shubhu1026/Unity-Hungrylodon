using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] float spawnInterval = 0.5f;
    TextMeshProUGUI multiplier;
    public bool isGameActive = false;
    public int spawnedFishCount = 0;
    private TextMeshProUGUI tmproScore;
    private float _score;
    private float movementSpeedMultiplier = 1f;
    private float dashForceMultiplier = 1f;
    private bool invertControls = false;

    public float Score
    { 
        get => _score;        
        set
        {
            _score = value;
            UpdateScoreGUI();
            ResetBonusTime();
        } 
    }


    public float SpawnInterval{ get{return spawnInterval;} set{spawnInterval = value;}}
    public static GameManager gameInstance;

    //getter and setter
    public int SpawnedFishCount {get{return spawnedFishCount;} set{spawnedFishCount = value;}}
    public float MovementSpeedMultiplier {get{return movementSpeedMultiplier;} set{movementSpeedMultiplier = value;}}
    public float DashForceMultiplier {get{return dashForceMultiplier;} set{dashForceMultiplier = value;}}
    public bool InvertControls {get{return invertControls;} set{invertControls = value;}}

    int fishCount = 0;

    [SerializeField] private float counterResetBonus = 2.2f;
    private float bonusCounter;
    public float bonusMultiplier = 1f;
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
        multiplier = GameObject.Find("Multiptier Text")?.GetComponent<TextMeshProUGUI>();
        StartGame();
    }

    public void StartGame()
    {
        bonusCounter = counterResetBonus;
        isGameActive = true;
        ResetVariables();
    }

    void ResetVariables()
    {
        spawnedFishCount = 0;
        movementSpeedMultiplier = 1;
        dashForceMultiplier = 1f;
        invertControls = false;
        _score = 0;
    }

    void Update()
    {
        if (bonusCounter > 0)
        {
            bonusCounter -= Time.deltaTime;
        }
        else ResetBonusValue();
        if (spawnedFishCount >= 50)
        {
            GameOver();
        }
    }

    private void ResetBonusValue()
    {
        bonusMultiplier = 1f;
        multiplier.text = bonusMultiplier.ToString();
    }
    private void ResetBonusTime()
    {
        bonusCounter = counterResetBonus;
        bonusMultiplier = Mathf.Min(bonusMultiplier + 0.1f, 2f);
        multiplier.text = bonusMultiplier.ToString();
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
