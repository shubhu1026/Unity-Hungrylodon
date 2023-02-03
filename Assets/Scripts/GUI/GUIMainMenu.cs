using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GUIMainMenu : MonoBehaviour
{
    [SerializeField] GameObject background;
    [SerializeField] GameObject aboutWindowGO;
    [SerializeField] Image audioButtonImage;
    [SerializeField] Sprite enabledAudio;
    [SerializeField] Sprite disabledAudio;
    [SerializeField] Slider SFXSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] GameObject particleActiveGO;    
    private void Start() {
        SFXVolume();
        MusicVolume();
    }
    public void PlayGame()
    {
        gameObject.SetActive(false);
        background.SetActive(false);
        //load scene
    }
    public void OpenAboutWindow()
    {
        aboutWindowGO.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public void AudioToggle()
    {
        bool enabled = SystemSetup.Instance.isAudioEnabled;
        SystemSetup.Instance.ChangeAudioEnabled(!enabled);
        //change sprite        
        audioButtonImage.sprite = enabled ? disabledAudio : enabledAudio;
    }
    public void SFXVolume()
    {        
        SystemSetup.Instance.SetSFXVolume(SFXSlider.value);
    }
    public void MusicVolume()
    {
        SystemSetup.Instance.SetMusicVolume(musicSlider.value);
    }
    public void ParticleToggle()
    {
        bool enabled = SystemSetup.Instance.isParticleEnabled;
        SystemSetup.Instance.ChangeParticleSetup(!enabled);
        //set active image
        particleActiveGO.SetActive(!enabled);
    }
}
