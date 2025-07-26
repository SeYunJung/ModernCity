using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager1 : MonoBehaviour
{
    private static MiniGameManager1 _instance;
    public static MiniGameManager1 Instance { get { return _instance; } }

    private MiniGameUIManager1 uiManager;

    public int currentScore = 0;
    public int score = 1;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        uiManager = MiniGameUIManager1.Instance;
    }

    public void Win()
    {
        Debug.Log("½Â¸®!");
    }

    public void Lose()
    {
        Debug.Log("ÆÐ¹è!");
        uiManager.ShowLose();
    }

    public void AddScore()
    {
        currentScore += score;
        uiManager.SetScore(currentScore);
    }
}
