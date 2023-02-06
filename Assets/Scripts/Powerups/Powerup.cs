using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    public abstract void Power();

    //disables spriterenderer and collider of powerup
    public void DisablePowerupPickup()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    public void DestroyPowerup()
    {
        Destroy(gameObject);
    }
}
