using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    [SerializeField] int minPowerupCount = 4;
    [SerializeField] int maxPowerupCount = 10;
    [SerializeField] float minSpawnInterval = 5;
    [SerializeField] float maxSpawnInterval = 25;
    [SerializeField] List<GameObject> powerupPrefabs;

    //for spawns
    float xRange = 24;
    float yPosition = -20f;

    int powerupsSpawned = 0;

    // Start is called before the first frame update
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
            GameObject powerup = powerupPrefabs[Random.Range(0, powerupPrefabs.Count)];

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
}
