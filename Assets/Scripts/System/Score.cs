using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{    
    [SerializeField] TextMeshProUGUI tmpScore;
    private int scoreValue;
    public static Score Instance;
    
    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
            
            return;
        }
        Destroy(gameObject);
        return;        
    }
    public void AddScorePoint(int points)
    {
        scoreValue += points;
        tmpScore.text = scoreValue.ToString();
    }
}
