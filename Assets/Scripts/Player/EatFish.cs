using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Fish")
        {
            Destroy(other.gameObject);
        }
    }
}
