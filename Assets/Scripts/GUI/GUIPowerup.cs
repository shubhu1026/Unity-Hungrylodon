using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GUIPowerup : MonoBehaviour
{
    
    [SerializeField] private Slider _powerupSlider;
    [SerializeField] AudioClip powerclip;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Image iconImage;
    private float _totalTime;
    private float _currentTime;
    private bool _isActive;

    public void SetPowerupCounter(float time, Sprite icon)
    {
        if(icon != null)
        {
            iconImage.gameObject.SetActive(true);
            iconImage.sprite = icon;
        }
        //MusicController.Instance.SetMute(true);
        audioSource.Stop();
        audioSource.volume = SystemSetup.Instance.MusicVolume;
        //audioSource.PlayOneShot(powerclip);
        _isActive = true;
        _totalTime = time;
        _currentTime = _totalTime;
        _powerupSlider.gameObject.SetActive(true);
    }
    private void Start() {
        _powerupSlider.gameObject.SetActive(false);
        iconImage.gameObject.SetActive(false);
    }
    private void Update()
    {
        if(!_isActive) return;

        _currentTime -= Time.deltaTime;
        if(_currentTime < 0)
        {
            iconImage.gameObject.SetActive(false);
            MusicController.Instance.SetMute(false);
            audioSource.Stop();
            _isActive = false;
            _currentTime = 0;
            _powerupSlider.gameObject.SetActive(false);
        }
        float sliderValueNormalized = _currentTime / _totalTime;        
        _powerupSlider.value = sliderValueNormalized;
    }
    private void OnEnable() {
        MusicController.Instance.SetMute(false);
        audioSource.Stop();
    }
}
