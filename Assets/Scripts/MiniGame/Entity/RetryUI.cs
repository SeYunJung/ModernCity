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
        // ��������, �ְ����� ����
        _miniGameUIManager.SaveScore();

        // �������� ���� 
        _miniGameUIManager.gameUI.GetComponent<GameUI>().ResetScore();

        //_gameManager.ActiveTime();
        _gameManager.InActiveTime();
        _miniGameUIManager.InActiveUI(UIType.Retry);
        //_miniGameUIManager.ActiveUI(UIType.Game);
        _gameManager.LoadScene("MiniGame_1");
    }

    private void OnClickExitButton()
    {
        // ��������, �ְ����� ����
        _miniGameUIManager.SaveScore();

        _miniGameUIManager.InActiveUI(UIType.Retry);
        _gameManager.ActiveTime();
        _gameManager.PlayerVisibleMode(_player);
        _gameManager.LoadScene("MainScene");

        // ���� ��� UI ���� 
        // MainScene���� MainUIManager�� ���� ��� UI����
        _gameManager.RequestResultUI();
    }
}
