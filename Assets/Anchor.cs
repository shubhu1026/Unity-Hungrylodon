using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        float newScale = Mathf.Abs(other.transform.localScale.x - 0.1f);
        float sign = Mathf.Sign(other.transform.localScale.x);
        Debug.Log("anchor hit! new scale is: " + newScale);
        other.transform.localScale = new Vector3(sign > 0 ? newScale : -newScale, newScale, newScale);
        other.GetComponentInParent<Rigidbody2D>().AddForce(Vector2.down * 10000, ForceMode2D.Impulse);
    }
    
}
