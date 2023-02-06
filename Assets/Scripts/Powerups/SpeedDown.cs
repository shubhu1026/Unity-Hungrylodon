using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown : Powerup
{
    float originalMoveForce;
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
        GameManager.gameInstance.MovementSpeedMultiplier = 0.75f;
        Invoke("ResetMoveSpeed", powerupTime);
    }

    void ResetMoveSpeed()
    {  
        GameManager.gameInstance.MovementSpeedMultiplier = 1;
        DestroyPowerup();
    }
}
