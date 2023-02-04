using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSetup : MonoBehaviour
{
    public float gameSpeed;
    public Action<float> OnMusicVolumeChanged;
    public Action<bool> OnAudioActiveChange;
    public Action OnParticleActiveChange;
    public static SystemSetup Instance;
    public bool isAudioEnabled { get; private set; }
    public float SFXVolume { get; private set; }
    public float MusicVolume { get; private set; }
    public bool isParticleEnabled { get; private set; }
    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
        return;
    }

    void Start()
    {
        isParticleEnabled = true;
        isAudioEnabled = true;
    }
    public void ChangeAudioEnabled(bool enabled)
    {
        isAudioEnabled = enabled;
        OnAudioActiveChange?.Invoke(enabled);
    }
    public void SetSFXVolume(float volume)
    {
        SFXVolume = volume;
    }
    public void SetMusicVolume(float volume)
    {
        MusicVolume = volume;
        OnMusicVolumeChanged?.Invoke(MusicVolume);
    }
    public void ChangeParticleSetup(bool enabled)
    {
        isParticleEnabled = enabled;
        OnParticleActiveChange?.Invoke();
    }
}
