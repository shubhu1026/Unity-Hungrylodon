// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class test : MonoBehaviour
// {
//     [SerializeField] ParticleController particleController;
//     [SerializeField] AudioClip[] audioClips;
//     void Start()
//     {
        
//     }
//     void Update()
//     {/*
//         if (Input.GetMouseButtonDown(0))
//         {
//             Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//             worldPosition.z = 0;
//             particleController.transform.position = worldPosition;
//             particleController.PlayParticleSystem();
//         }*/
//         if (Input.GetMouseButtonDown(1))
//         {
            
//             SFXController.Instance.PlaySound(audioClips[Random.Range(0, audioClips.Length)]);
//         }
//     }
// }
