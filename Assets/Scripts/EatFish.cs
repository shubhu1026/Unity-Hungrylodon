using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFish : MonoBehaviour
{
    [SerializeField] int playerSizeAtStart = 15;

    int playerSize;

    void Start()
    {
        playerSize = playerSizeAtStart;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Fish")
        {
            int enemySize = other.gameObject.GetComponent<EnemySize>().GetFishSize();

            if(playerSize > enemySize)
            {
                Destroy(other.gameObject);
            }
        }
    }
}