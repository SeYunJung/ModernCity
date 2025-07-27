using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameScoreManager1 : Singleton<MiniGameScoreManager1>
{
    private int score;
    private int bestScore;

    public void SaveCurrentScore(int score)
    {
        PlayerPrefs.SetInt("Score", score);
    }

    public void SaveBestScore()
    {
        // �ְ����� ����
        bestScore = PlayerPrefs.GetInt("BestScore");
        score = PlayerPrefs.GetInt("Score");

        if(bestScore < score)
        {
            // �ְ����� ����
            PlayerPrefs.SetInt("BestScore", score);
        }
    }
}
