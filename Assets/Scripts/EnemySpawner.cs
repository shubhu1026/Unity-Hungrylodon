using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] float spawnInterval = 0.5f;
    [SerializeField] int maxFishAllowed = 8;

    float xRange = 19f;
    float yRange = 9f;

    Vector2 spawnPosition;

    Collider2D overlappingCollider;

    GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Start()
    {
        StartCoroutine(SpawnFish());
    }

    IEnumerator SpawnFish()
    {
        while(gameManager.isGameActive)
        {
            if(gameManager.GetFishCount() < maxFishAllowed)
            {
                GameObject fish = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
                spawnPosition = GetSpawnPosition(fish);
                if(spawnPosition != Vector2.zero)
                {
                    gameManager.SpawnedFishCount++;
                    Instantiate(fish, spawnPosition, fish.transform.rotation);
                }
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector2 GetSpawnPosition(GameObject objectToSpawn)
    {
        Vector2 position;
        int loopCount = 0;
        while(loopCount < 5)
        {
            position.x = Random.Range(-xRange, xRange);
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
