using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryUI : MonoBehaviour
{
    public Button retryButton;
    public Button exitButton;

    private GameManager _gameManager;
    private MiniGameUIManager _miniGameUIManager;

    private GameObject _player;

    private void Awake()
    {
        retryButton.onClick.AddListener(OnClickRetryButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _miniGameUIManager = MiniGameUIManager.Instance;
        _player = _gameManager.GetPlayer();
    }

    private void OnClickRetryButton()
    {
        // 현재점수, 최고점수 저장
        _miniGameUIManager.SaveScore();

        // 현재점수 리셋 
        _miniGameUIManager.gameUI.GetComponent<GameUI>().ResetScore();

        _gameManager.InActiveTime();
        _miniGameUIManager.InActiveUI(UIType.Retry);
        _gameManager.LoadScene("MiniGame_1");
    }

    private void OnClickExitButton()
    {
        // 현재점수, 최고점수 저장
        _miniGameUIManager.SaveScore();

        _miniGameUIManager.InActiveUI(UIType.Retry);

        // 현재점수와 최고점수가 PlayerPrefs에 저장된 상태

        // 플레이어가 자신의 이름을 입력하게 한다. 
        _miniGameUIManager.ActiveUI(UIType.User);
    }
}
