using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Fish")
        {
            OtherFish fish = other.GetComponent<OtherFish>();
            IncreaseCurrentScale(fish);
            AddToScore(fish);
            Destroy(other.gameObject);
        }
    }

    //Increase player size when they eat other fish
    void IncreaseCurrentScale(OtherFish enemyFish)
    {
        float enemyFishSize = enemyFish.FishSize;
        float newScale = transform.localScale.y + enemyFishSize/1000;
        transform.localScale = new Vector3(newScale, newScale, newScale);
    }

    //add the point value to the score
    void AddToScore(OtherFish enemyFish)
    {
        GameManager.gameInstance.Score += enemyFish.PointValue;
        Debug.Log(GameManager.gameInstance.Score);
    }
}
