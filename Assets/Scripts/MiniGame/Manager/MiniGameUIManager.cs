using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIType
{
    Home,
    Game,
    Retry
}

public class MiniGameUIManager : MonoBehaviour
{
    // 싱글톤 구현 => 다른 씬에서도 사용하기 위해 싱글톤으로 구현 
    private static MiniGameUIManager _instance = null;
    public static MiniGameUIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                return null;
            }
            return _instance;
        }
    }

    public GameObject homeUI;
    public GameObject gameUI;
    public GameObject retryUI;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    private void Start()
    {
        homeUI.SetActive(true);

        // 최고점수 로드
        //gameUI.gameObject.GetComponent<GameUI>().SetBestScore();
        gameUI.gameObject.GetComponent<GameUI>().SetScore();
    }

    public void InActiveUI(UIType type)
    {
        switch (type)
        {
            case UIType.Home:
                homeUI.SetActive(false);
                break;
            case UIType.Game:
                gameUI.SetActive(false);
                break;
            case UIType.Retry:
                retryUI.SetActive(false);
                break;
        }
    }
    
    public void ActiveUI(UIType type)
    {
        switch (type)
        {
            case UIType.Home:
                homeUI.SetActive(true);
                break;
            case UIType.Game:
                gameUI.SetActive(true);
                break;
            case UIType.Retry:
                retryUI.SetActive(true);
                break;
        }
    }

    public void Lose()
    {
        gameUI.SetActive(false);
        retryUI.SetActive(true);
    }

    public void SaveScore()
    {
        // 현재점수, 최고점수 저장
        int currentScore = gameUI.GetComponent<GameUI>().Score;
        int bestScore = PlayerPrefs.GetInt("BestScore");

        PlayerPrefs.SetInt("Score", currentScore);

        if(currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        Debug.Log($"현재점수 : {PlayerPrefs.GetInt("Score")}");
        Debug.Log($"최고점수 : {PlayerPrefs.GetInt("BestScore")}");
    }
}
