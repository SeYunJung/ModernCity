using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    private int score;
    public int Score {  get { return score; } }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;


    public void AddScore(int currentScore)
    {
        score += currentScore;
        scoreText.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void SetBestScore()
    {
        bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
    }

    public void SetScore()
    {
        scoreText.text = PlayerPrefs.GetInt("Score").ToString();
        bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
    }
}
