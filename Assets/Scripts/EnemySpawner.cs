using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] int maxFishAllowed = 8;
    [SerializeField] int maxFishToBeSpawned = 50;
    
    float xMinRange = 24f;
    float xMaxRange = 32f;
    float yRange = 9f;
    int TotalSpawnedFishCount;
    int currentFishCount;

    Vector2 spawnPosition;

    Collider2D overlappingCollider;
    void Start()
    {
        StartCoroutine(SpawnFish());
        GameManager.gameInstance.OnGameReset += () =>
        {
            TotalSpawnedFishCount = 0;
            StartCoroutine(SpawnFish());
        };
    }

    IEnumerator SpawnFish()
    {
        while (TotalSpawnedFishCount < maxFishToBeSpawned)
        {
            while(currentFishCount < maxFishAllowed)
            {
                SpawnSingleFish();
                yield return new WaitForSeconds(GameManager.gameInstance.SpawnInterval);
            }
            yield return new WaitWhile(() =>
                {
                    return currentFishCount >= maxFishAllowed;
                }
            );
        }
        yield return new WaitUntil(() =>
                {
                    return currentFishCount == 0;
                }
            );
        yield return new WaitForSeconds(1f);

        GameManager.gameInstance.GameOver();
    }
    private void FishDead()
    {
        currentFishCount--;
    }
    private void SpawnSingleFish()
    {
        GameObject fishPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        spawnPosition = GetSpawnPosition(fishPrefab);
        if (spawnPosition != Vector2.zero)
        {
            TotalSpawnedFishCount++;
            currentFishCount++;
            GameObject currentFish = Instantiate(fishPrefab, spawnPosition, fishPrefab.transform.rotation);
            currentFish.GetComponent<OtherFish>().OnDeath += FishDead;
        }
    }

    Vector2 GetSpawnPosition(GameObject objectToSpawn)
    {
        Vector2 position;
        int loopCount = 0;
        while(loopCount < 5)
        {
            position.x = Random.Range(xMinRange, xMaxRange);
            position.y = Random.Range(-yRange, yRange);
            overlappingCollider = Physics2D.OverlapBox(position, objectToSpawn.GetComponent<CapsuleCollider2D>().size, 90);
            if(overlappingCollider == null)
            {
                return position;
            }
            loopCount++;
        }

        return Vector2.zero;
    }
}
