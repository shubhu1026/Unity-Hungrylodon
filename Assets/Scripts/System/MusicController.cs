using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioClip[] musicTracks;
    [SerializeField] AudioSource audioSource;    
    private void Update()
    {
        if(!audioSource.isPlaying) PlayRandomTrack();
    }

    private void PlayRandomTrack()
    {
        int rnd = UnityEngine.Random.Range(0, musicTracks.Length);
        audioSource.PlayOneShot(musicTracks[rnd]);
    }
}
