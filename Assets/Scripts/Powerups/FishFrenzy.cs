using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFrenzy : Powerup
{
    [SerializeField] GameObject fishPrefab;

    float xPosition = 24f;
    float yPosition = 0f;

    float originalSpawnInterval = 0f;

    public override void Power()
    {
        originalSpawnInterval = GameManager.gameInstance.SpawnInterval;
        GameManager.gameInstance.SpawnInterval = 2f;

        Vector3 spawnOrigin = new Vector3(xPosition, yPosition, 0f);
        Instantiate(fishPrefab, spawnOrigin, Quaternion.identity);

        GameManager.gameInstance.SpawnInterval = originalSpawnInterval;

        DestroyPowerup();
    }
}
