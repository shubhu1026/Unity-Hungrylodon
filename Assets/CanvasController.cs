using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] GameObject leaderboard;
    [SerializeField] GameObject playerName;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject about;
    [SerializeField] GameObject background;
    [SerializeField] Image audioButtonImage;
    [SerializeField] Sprite enabledAudio;
    [SerializeField] Sprite disabledAudio;
    [SerializeField] Slider SFXSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] GameObject particleActiveGO;
    [SerializeField] AudioClip clickSound;
    private static CanvasController Instance;
    
    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(gameObject);
        return;        
    }
    private void Start() {
        leaderboard.gameObject.SetActive(true);
        playerName.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
        about.gameObject.SetActive(false);
        SFXVolume();
        MusicVolume();        
    }
    public void PlayGame()
    {
        ShowLeaderboardGui();
        SceneManager.LoadScene(1);
    }
    public void ShowLeaderboardGui()
    {
        leaderboard.gameObject.SetActive(true);
        playerName.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        about.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
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
    
    public void GoToMainMenu()
    {
        leaderboard.gameObject.SetActive(false);
        playerName.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
        about.gameObject.SetActive(false);
    }
    public void GoToAbout()
    {
        leaderboard.gameObject.SetActive(false);
        playerName.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        about.gameObject.SetActive(true);
    }
}
