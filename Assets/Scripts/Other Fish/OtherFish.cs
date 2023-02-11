using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherFish : MonoBehaviour
{
    //fish size can be multiples of 10
    public Action OnDeath;
    [SerializeField] float baseFishSize = 10f;
    [SerializeField] float basePointValue = 10f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] bool randomizeScale = true;

    float fishSize;
    float pointValue;
    public float PointValue {get {return pointValue;}}
    public float FishSize {get {return fishSize;}}
    public bool isAlive = true;
    bool shouldMoveLeft = false;

    void Start()
    {    
        GetMoveDirection();
        if(randomizeScale)
        {
            SetFishScale();
        }
        SetPointValue();
    }

    void SetFishScale()
    {
        //Add randomness to fish scale
        if(UnityEngine.Random.value < 0.5)
        {
            fishSize = baseFishSize + UnityEngine.Random.Range(0f, 1f) * 10;
            float newScale = transform.localScale.y + fishSize/100;
            transform.localScale = new Vector3(newScale, newScale, newScale);
        }
        else
        {
            fishSize = baseFishSize - UnityEngine.Random.Range(0f, 1f) * 10;
            float newScale = transform.localScale.y + fishSize/100;
            transform.localScale = new Vector3(newScale, newScale, newScale);
        }
    }

    void SetPointValue()
    {
        pointValue = basePointValue * 1000 + fishSize; 
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
    public void Die()
    {
        var v = GetComponent<CapsuleCollider2D>();
        v.enabled = false;
        moveSpeed = 0;
        StartCoroutine(Disapear());
    }
    private IEnumerator Disapear()
    {
        GetComponent<FishBase>().speedAnimation = 0;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        while (spriteRenderer.color.a > 0)
        {
            float speed = Time.deltaTime * 2;
            Color newColor = spriteRenderer.color;
            newColor.a -= speed;
            spriteRenderer.color = newColor;
            Vector3 newScale = Vector3.one * speed;
            float sign = Mathf.Sign(transform.localScale.x);
            newScale.x = newScale.x * sign;
            transform.localScale += newScale;
            yield return null;
        }
        Destroy(gameObject);
        
    }
    private void OnDestroy() {
        OnDeath?.Invoke();
    }
}
