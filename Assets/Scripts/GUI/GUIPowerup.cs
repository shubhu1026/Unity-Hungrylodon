using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIPowerup : MonoBehaviour
{
    [SerializeField] private Slider _powerupSlider;
    private float _totalTime;
    private float _currentTime;
    private bool _isActive;
    public void SetPowerupCounter(float time)
    {
        _isActive = true;
        _totalTime = time;
        _currentTime = _totalTime;
        _powerupSlider.gameObject.SetActive(true);
    }
    private void Start() {
        _powerupSlider.gameObject.SetActive(false);
    }
    private void Update()
    {
        if(!_isActive) return;

        _currentTime -= Time.deltaTime;
        if(_currentTime < 0)
        {
            _isActive = false;
            _currentTime = 0;
            _powerupSlider.gameObject.SetActive(false);
        }
        float sliderValueNormalized = _currentTime / _totalTime;        
        _powerupSlider.value = sliderValueNormalized;
    }
}
