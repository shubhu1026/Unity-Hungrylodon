using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherFish : MonoBehaviour
{
    //fish size can be multiples of 10
    [SerializeField] float baseFishSize = 10f;
    [SerializeField] float basePointValue = 10f;
    [SerializeField] float moveSpeed = 10f;

    float fishSize;
    float pointValue;
    public float PointValue {get {return pointValue;}}
    public float FishSize {get {return fishSize;}}

    bool shouldMoveLeft = false;

    void Start()
    {    
        GetMoveDirection();
        SetFishScale();
        SetPointValue();
    }

    void SetFishScale()
    {
        //Add randomness to fish scale
        if(Random.value < 0.5)
        {
            fishSize = baseFishSize + Random.Range(0f, 1f) * 10;
            float newScale = transform.localScale.y + fishSize/100;
            transform.localScale = new Vector3(newScale, newScale, newScale);
        }
        else
        {
            fishSize = baseFishSize - Random.Range(0f, 1f) * 10;
            float newScale = transform.localScale.y + fishSize/100;
            transform.localScale = new Vector3(newScale, newScale, newScale);
        }
    }

    void SetPointValue()
    {
        pointValue = basePointValue + fishSize; 
    }

    void GetMoveDirection()
    {
        if(transform.position.x > 0)
        {
            shouldMoveLeft = true;
        }
        else
        {
            shouldMoveLeft = false;
        }
    }

    // Update is called once per frame
    void Update()
    {   
        Move();
        RotateSprite();
    }

    void Move()
    {
        if(shouldMoveLeft)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    void RotateSprite()
    {
        if(shouldMoveLeft && Mathf.Sign(transform.localScale.x) < 0)
        {
            Vector3 currentScale;
            currentScale = transform.localScale;
            currentScale.x *= -1;
            transform.localScale = currentScale;
        }
        //if moving left and looking right
        else if(!shouldMoveLeft && Mathf.Sign(transform.localScale.x) > 0)
        {
            Vector3 currentScale;
            currentScale = transform.localScale;
            currentScale.x *= -1;
            transform.localScale = currentScale;
        }
    }
}