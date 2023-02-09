using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Powerup
{
    float originalMoveForce;
    //[SerializeField] float powerupTime = 5f; protected variable in abstract class

    public override void Power()
    {
        GameManager.gameInstance.MovementSpeedMultiplier = 1.5f;
        Invoke("ResetMoveSpeed", powerupTime);
    }

    void ResetMoveSpeed()
    {  
        GameManager.gameInstance.MovementSpeedMultiplier = 1;
        DestroyPowerup();
    }
}
