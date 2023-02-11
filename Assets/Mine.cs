using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] float speedPower = 35f;
    float timer;
    float timeToDrop;
    bool isActive = true;
    bool isUsed = false;
    float explosionSpeed = 0.1f;
    [SerializeField] AudioClip[] hits;
    [SerializeField] Sprite[] explosionAnimation;
    int index;
    [SerializeField] SpriteRenderer spriteRenderer;
    void Start()
    {
        GetComponent<Rigidbody2D>().Sleep();
        timeToDrop = Random.Range(5, 45);
    }

    
    void Update()
    {
        if(isUsed)
        {
            timer += Time.deltaTime;
            if(timer > explosionSpeed)
            {
                timer = 0;
                index++;
                if(index >= explosionAnimation.Length)
                {
                    Destroy(gameObject);
                    return;
                }
                spriteRenderer.sprite = explosionAnimation[index];
            }
        }
        if(!isActive) return;
        if (timer > timeToDrop) 
        { 
            GetComponent<Rigidbody2D>().WakeUp();
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * speedPower, ForceMode2D.Impulse);
            isActive = false;
        }
        else
        {
            timer += Time.deltaTime;

        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(isUsed) return;
        float newScale = Mathf.Abs(other.transform.localScale.x - 0.1f);
        float sign = Mathf.Sign(other.transform.localScale.x);
        Debug.Log("mine hit! new scale is: " + newScale);
        other.transform.localScale = new Vector3(sign > 0 ? newScale : -newScale, newScale, newScale);        
        SFXController.Instance.PlaySound(hits[Random.Range(0, hits.Length)]);
        timer = 0;
        GetComponent<Rigidbody2D>().Sleep();
        isUsed = true;
    }
    
}
