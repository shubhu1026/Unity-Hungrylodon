using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GUIMainMenu : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject background;
    [SerializeField] GameObject aboutWindowGO;
    [SerializeField] Image audioButtonImage;
    [SerializeField] Sprite enabledAudio;
    [SerializeField] Sprite disabledAudio;
    [SerializeField] Slider SFXSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] GameObject particleActiveGO;
    [SerializeField] AudioClip clickSound;
    public static GUIMainMenu Instance;
    
    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(canvas);
            return;
        }
        Destroy(gameObject);
        return;        
    }
    private void Start() {
        SFXVolume();
        MusicVolume();
        //actual scene is not start scene -> fix for develop, any scene can be run at start        
        MenuActive(SceneManager.GetActiveScene().buildIndex == 0);        
    }
    public void PlayGame()
    {        
        bool isInMainMenu = SceneManager.GetActiveScene().buildIndex == 0;        
        MenuActive(isInMainMenu);
        if(isInMainMenu) SceneManager.LoadScene(1);
    }

    private void MenuActive(bool enable)
    {        
        gameObject.SetActive(enable);
        background.SetActive(enable);
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
    public void SFXClick()
    {
        SFXController.Instance.PlaySound(clickSound);
    }
}
