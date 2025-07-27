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
        // 최고점수 저장
        bestScore = PlayerPrefs.GetInt("BestScore");
        score = PlayerPrefs.GetInt("Score");

        if(bestScore < score)
        {
            // 최고점수 갱신
            PlayerPrefs.SetInt("BestScore", score);
        }
    }
}
