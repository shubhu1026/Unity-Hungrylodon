using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public abstract class Powerup : MonoBehaviour
{
    public abstract void Power();
    [SerializeField] protected float powerupTime = 5f;
    float rotationRange = 15;

    Light2D[] lights;

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
            if(powerupTime > 0) FindObjectOfType<GUIPowerup>().SetPowerupCounter(powerupTime);
            DisablePowerupPickup();
            Power();
        }
    }

    //disables spriterenderer and collider of powerup
    public void DisablePowerupPickup()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        lights = gameObject.GetComponentsInChildren<Light2D>();

        foreach(Light2D light in lights)
        {
            light.enabled = false;
        }
    }

    public void DestroyPowerup()
    {
        Destroy(gameObject);
    }
}
