using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertControls : Powerup
{
    //[SerializeField] float powerupTime = 5f;

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
