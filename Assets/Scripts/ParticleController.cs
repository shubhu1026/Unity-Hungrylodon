using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem;    
    void Start()
    {
        var v = particleSystem.main.playOnAwake;
        v = false;
        
        SystemSetup.Instance.OnParticleActiveChange += SetParticleSystemActive;
        SetParticleSystemActive();
    }
    private void OnDestroy()
    {
        SystemSetup.Instance.OnParticleActiveChange -= SetParticleSystemActive;
    }
    private void SetParticleSystemActive()
    {
        if(SystemSetup.Instance.isParticleEnabled)
        {
            particleSystem.Play();
        }
        else
        {
            particleSystem.Stop();
        }

    }
}
