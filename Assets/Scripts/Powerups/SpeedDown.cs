using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown : Powerup
{
    float originalMoveForce;
    

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
