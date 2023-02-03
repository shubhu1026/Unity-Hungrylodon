using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioClip[] musicTracks;
    [SerializeField] AudioSource audioSource;
    
    private void Start()
    {
        SystemSetup.Instance.OnMusicVolumeChanged += SetMusicVolume;
        SystemSetup.Instance.OnAudioActiveChange += SetAudio;
    }
    private void Update()
    {
        if(!audioSource.isPlaying) PlayRandomTrack();
    }
    private void OnDestroy()
    {
        SystemSetup.Instance.OnMusicVolumeChanged -= SetMusicVolume;
    }
    private void PlayRandomTrack()
    {
        int rnd = UnityEngine.Random.Range(0, musicTracks.Length);        
        audioSource.PlayOneShot(musicTracks[rnd]);
    }
    private void SetMusicVolume(float volume)
    {
        audioSource.volume = volume;
    }
    private void SetAudio(bool active)
    {
        audioSource.gameObject.SetActive(active);
    }
}
