using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public abstract class Powerup : MonoBehaviour
{
    public abstract void Power();

    float rotationRange = 15;

    float minMoveSpeed = 1;
    float maxMoveSpeed = 5;
    float moveSpeed;

    void Start() 
    {
        float rotation = Random.Range(-rotationRange, rotationRange);
        transform.Rotate(0, 0, rotation);

        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    void Update() 
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            DisablePowerupPickup();
            Power();
        }
    }

    //disables spriterenderer and collider of powerup
    public void DisablePowerupPickup()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponentInChildren<Light2D>().enabled = false;
    }

    public void DestroyPowerup()
    {
        Destroy(gameObject);
    }
}
