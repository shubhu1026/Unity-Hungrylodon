using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnInterval = 5;
    [SerializeField] float maxSpawnInterval = 25;

    [SerializeField] GameObject speedUpPowerup;
    [SerializeField] GameObject speedDownPowerup;
    [SerializeField] GameObject fishFrenzyPowerup;
    [SerializeField] GameObject invertControlsPowerup;

    //for spawns
    float xRange = 24;
    float yPosition = -20f;
    
    void Start()
    {
        StartCoroutine(SpawnPowerups());
    }

    IEnumerator SpawnPowerups()
    {
        do
        {
            Debug.Log(GameManager.gameInstance.isGameActive);
            float spawnInterval = GetSpawnInterval();
            Vector2 spawnLocation = GetSpawnLocation();
            GameObject powerup = PowerupToSpawn();

            yield return new WaitForSeconds(spawnInterval);

            Instantiate(powerup, spawnLocation, Quaternion.identity);
        }while(GameManager.gameInstance.isGameActive);
    }

    float GetSpawnInterval()
    {
        return Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    Vector2 GetSpawnLocation()
    {
        Vector2 position;
        position.x = Random.Range(-xRange, xRange);
        position.y = yPosition;
        return position;
    }

    GameObject PowerupToSpawn()
    {
        float value = Random.value;
        GameObject power;
        //30 % speed up, 30% speed down, 25% invert controls & 15% fish frenzy

        if(value <= 0.15)
        {
            power = fishFrenzyPowerup;
        }
        else if(value <= 0.4)
        {
            power = invertControlsPowerup;
        }
        else if(value <= 0.7)
        {
            power = speedDownPowerup;
        }
        else
        {
            power = speedUpPowerup;
        }

        return power;
    }
}
