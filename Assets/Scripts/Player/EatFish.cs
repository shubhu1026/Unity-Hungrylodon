using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFish : MonoBehaviour
{
    [SerializeField] AudioClip[] eatSounds;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Fish")
        {
            SFXController.Instance.PlaySound(GetRandomSound());
            OtherFish fish = other.GetComponent<OtherFish>();
            IncreaseCurrentScale(fish);
            AddToScore(fish);
            fish.Die();
        }
    }

    private AudioClip GetRandomSound()
    {
        return eatSounds[UnityEngine.Random.Range(0, eatSounds.Length)];
    }

    //Increase player size when they eat other fish
    void IncreaseCurrentScale(OtherFish enemyFish)
    {
        float enemyFishSize = enemyFish.FishSize;
        float newScale = Mathf.Abs(transform.localScale.x) + enemyFishSize/1000;
        float sign = Mathf.Sign(transform.localScale.x);
        transform.localScale = new Vector3(sign > 0 ? newScale : -newScale, newScale, newScale);
        GetComponent<FishBase>()?.AttackVisual();
    }

    //add the point value to the score
    void AddToScore(OtherFish enemyFish)
    {
        GameManager.gameInstance.Score += enemyFish.PointValue;
    }
}
