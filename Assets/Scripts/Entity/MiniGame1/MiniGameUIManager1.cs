using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameUIManager1 : MonoBehaviour
{
    private static MiniGameUIManager1 _instance;
    public static MiniGameUIManager1 Instance { get { return _instance; } }

    public TextMeshProUGUI uiLoseText;
    public TextMeshProUGUI uiScoreText;

    private void Awake()
    {
        _instance = this;
    }

    public void ShowLose()
    {
        uiLoseText.gameObject.SetActive(true);
    }

    public void SetScore(int currentScore)
    {
        uiScoreText.text = currentScore.ToString();
    }
}
