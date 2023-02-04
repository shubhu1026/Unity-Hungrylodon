using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public static SFXController Instance;
    
    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
            
            return;
        }
        Destroy(gameObject);
        return;        
    }
    
    public void PlaySound(AudioClip clipToPlay)
    {
        if(!SystemSetup.Instance.isAudioEnabled) return;
        AudioSource.PlayClipAtPoint(clipToPlay, new Vector3(0, 0, -10), SystemSetup.Instance.SFXVolume);
    }
}
