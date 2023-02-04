// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ParticleController : MonoBehaviour
// {
//     private ParticleSystem _particleSystem;
//     private void Awake() {
//         _particleSystem = GetComponent<ParticleSystem>();
//     }
//     void Start()
//     {
//         var v = _particleSystem.main.playOnAwake;
//         v = false;
        
//         SystemSetup.Instance.OnParticleActiveChange += SetParticleSystemActive;
//         SetParticleSystemActive();
//     }
//     private void OnDestroy()
//     {
//         SystemSetup.Instance.OnParticleActiveChange -= SetParticleSystemActive;
//     }
//     private void SetParticleSystemActive()
//     {
//         if(SystemSetup.Instance.isParticleEnabled)
//         {
//             if(_particleSystem.main.loop) _particleSystem.Play();
//         }
//         else
//         {
//             _particleSystem.Stop();
//         }

//     }
//     public void PlayParticleSystem()
//     {
//         if(SystemSetup.Instance.isParticleEnabled) _particleSystem.Play();
//     }
// }
