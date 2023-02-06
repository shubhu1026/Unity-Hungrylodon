using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertControls : Powerup
{
    [SerializeField] float powerupTime = 5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            DisablePowerupPickup();
            Power();
        }
    }

    public override void Power()
    {
        GameManager.gameInstance.InvertControls = true;
        Invoke("ResetControls", powerupTime);
    }

    void ResetControls()
    {  
        GameManager.gameInstance.InvertControls = false;
        DestroyPowerup();
    }
}
