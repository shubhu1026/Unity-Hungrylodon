using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    float timer;
    float timeToDrop;
    bool isActive = true;
    bool isUsed = false;
    [SerializeField] AudioClip[] hits;
    void Start()
    {
        GetComponent<Rigidbody2D>().Sleep();
        timeToDrop = Random.Range(5, 45);
    }

    
    void Update()
    {
        if(!isActive) return;
        if (timer > timeToDrop) 
        { 
            GetComponent<Rigidbody2D>().WakeUp(); 
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
        Debug.Log("anchor hit! new scale is: " + newScale);
        other.transform.localScale = new Vector3(sign > 0 ? newScale : -newScale, newScale, newScale);
        other.GetComponentInParent<Rigidbody2D>().AddForce(Vector2.down * 10000, ForceMode2D.Impulse);
        SFXController.Instance.PlaySound(hits[Random.Range(0, hits.Length)]);
        isUsed = true;
    }
    
}
