using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    #region Variables
    [Header("Score")]
    [SerializeField] TextMeshProUGUI _textMeshProScore;
    private float _score;
    [Space]
    [Header("Bonus Multiplier")]
    [SerializeField] TextMeshProUGUI _textMeshProMultiplier;
    [SerializeField] private Image _image;
    [Range(0, float.MaxValue)]
    [SerializeField] private float _counterResetTime = 2.2f;
    private float _bonusCounter;
    public float _bonusMultiplier = 1f;
    #endregion
    private void Start() {
        GameManager.gameInstance.OnGameReset += Reset;
        Reset();
    }
    private void OnDestroy() {
        GameManager.gameInstance.OnGameReset -= Reset;
    }
    private void Update() {
        if (_bonusCounter > 0)
        {
            _bonusCounter -= Time.deltaTime;
            float normalizedCounter = _bonusCounter / _counterResetTime;
            _image.fillAmount = normalizedCounter;
        }
        else ResetBonusMultiplier();
        
    }
    public void AddScore(float scoreValue)
    {
        
        _score += _bonusMultiplier * scoreValue;
        AddBonusMultiplier();
        UpdateGUI();
    }

    private void Reset() {
        _bonusCounter = _counterResetTime;
        _score = 0;
        UpdateGUI();
        
    }
    private void UpdateGUI()
    {
        _textMeshProScore.text = Mathf.RoundToInt(_score).ToString();
        _textMeshProMultiplier.text = _bonusMultiplier.ToString();
    }
    private void ResetBonusMultiplier()
    {
        _bonusMultiplier = 1f;
        _textMeshProMultiplier.text = _bonusMultiplier.ToString();
    }
    private void AddBonusMultiplier()
    {
        _bonusCounter = _counterResetTime;
        _bonusMultiplier = Mathf.Min(_bonusMultiplier + 0.1f, 2f);
        _textMeshProMultiplier.text = _bonusMultiplier.ToString();
    }
}
