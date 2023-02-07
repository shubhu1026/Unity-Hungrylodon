using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] int maxFishAllowed = 8;

    float xMinRange = 24f;
    float xMaxRange = 32f;
    float yRange = 9f;

    Vector2 spawnPosition;

    Collider2D overlappingCollider;
    void Start()
    {
        StartCoroutine(SpawnFish());
    }

    IEnumerator SpawnFish()
    {
        while(GameManager.gameInstance.isGameActive)
        {
            if(GameManager.gameInstance.GetFishCount() < maxFishAllowed)
            {
                GameObject fish = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
                spawnPosition = GetSpawnPosition(fish);
                if(spawnPosition != Vector2.zero)
                {
                    GameManager.gameInstance.SpawnedFishCount++;
                    Instantiate(fish, spawnPosition, fish.transform.rotation);
                }
            }
            yield return new WaitForSeconds(GameManager.gameInstance.SpawnInterval);
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
