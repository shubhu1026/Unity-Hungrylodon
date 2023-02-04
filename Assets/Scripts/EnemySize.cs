using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySize : MonoBehaviour
{
    [SerializeField] int fishSize = 10;

    float scaleFactor;
    float scale;

    void Start()
    {
        scaleFactor = fishSize/100;
        scale = transform.localScale.x;
        transform.localScale = new Vector3(scale + scaleFactor, scale + scaleFactor, scale + scaleFactor);
    }
    
    void Update()
    {
        
    }

    public int GetFishSize()
    {
        return fishSize;
    }
}
