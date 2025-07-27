using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum UIType
{
    HomeUI,
    GameUI,
    RetryUI
}

public class MiniGameUIManager1 : Singleton<MiniGameUIManager1>
{
    [SerializeField] private MiniGameManager1 _gameManager;

    private GameObject _canvas;
    [SerializeField] private GameObject _homeUI;
    [SerializeField] private GameObject _gameUI;
    [SerializeField] private GameObject _retryUI;

    [SerializeField] private TextMeshProUGUI _uiLoseText;
    [SerializeField] private TextMeshProUGUI _uiScoreText;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        _gameManager = GameObject.FindObjectOfType<MiniGameManager1>();

        _canvas = GameObject.Find("Canvas");
        //_homeUI = GameObject.Find("HomeUI");
        _homeUI = _canvas.transform.GetChild(0).gameObject;
        //_gameUI = GameObject.Find("GameUI");
        _gameUI = _canvas.transform.GetChild(1).gameObject;
        //_retryUI = GameObject.Find("RetryUI");
        _retryUI = _canvas.transform.GetChild(2).gameObject;
        //[SerializeField] private TextMeshProUGUI uiLoseText;
        //[SerializeField] private TextMeshProUGUI uiScoreText;

        _uiLoseText = _gameUI.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        _uiScoreText = _gameUI.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();

        //_uiLoseText = _gameUI.GetComponentsInChildren<TextMeshProUGUI>()[0];
        //_uiScoreText = _gameUI.GetComponentsInChildren<TextMeshProUGUI>()[1];
    }

    public void ShowLose()
    {
        Debug.Log($"uiLoseText = {_uiLoseText}");
        _uiLoseText.gameObject.SetActive(true);
    }

    public void SetScore(int currentScore)
    {
        Debug.Log($"uiScoreText = {_uiScoreText}");
        _uiScoreText.text = currentScore.ToString();
    }

    public void ActiveUI(UIType type)
    {
        switch (type)
        {
            case UIType.HomeUI:
                _homeUI.SetActive(true);
                break;
            case UIType.GameUI:
                _gameUI.SetActive(true);
                break;
            case UIType.RetryUI:
                _retryUI.SetActive(true);
                break;
        }
    }

    public void InActiveUI(UIType type)
    {
        switch (type)
        {
            case UIType.HomeUI:
                _homeUI.SetActive(false);
                break;
            case UIType.GameUI:
                _gameUI.SetActive(false);
                break;
            case UIType.RetryUI:
                _retryUI.SetActive(false);
                break;
        }
    }
}
