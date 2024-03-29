using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFish : MonoBehaviour
{
    [SerializeField]private AudioClip[] eatSounds;
    
    private void OnEnable()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Fish")
        {
            OtherFish fish = other.GetComponent<OtherFish>();
            if(!fish.isAlive) return;
            fish.isAlive = false;
            SFXController.Instance.PlaySound(GetRandomSound());
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
    private void IncreaseCurrentScale(OtherFish enemyFish)
    {
        
        float enemyFishSize = enemyFish.FishSize;
        float addedValue = enemyFishSize / 2000;
        float newScale = Mathf.Abs(transform.localScale.x) + addedValue;
        float sign = Mathf.Sign(transform.localScale.x);
        //Debug.Log("old scale was" + transform.localScale.x + " added value is:" + addedValue + " new scale is: " + newScale + "   " + enemyFish.gameObject);
        transform.localScale = new Vector3(sign > 0 ? newScale : -newScale, newScale, newScale);
        GetComponent<FishBase>()?.AttackVisual();
    }

    //add the point value to the score
    private void AddToScore(OtherFish enemyFish)
    {
        Debug.Log("eating fish");
        FindObjectOfType<Score>().AddScore(enemyFish.PointValue/100);
    }
}
