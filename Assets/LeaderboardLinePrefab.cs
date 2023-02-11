using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardLinePrefab : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI rank;
    [SerializeField] TextMeshProUGUI playerName;
    [SerializeField] TextMeshProUGUI score;
    public void Init(LeaderboardDataGUI data)
    {
        rank.text = data.rank;
        playerName.text = data.name;
        score.text = data.score;
    }
}
