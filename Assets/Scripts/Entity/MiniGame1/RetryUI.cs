using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryUI : MonoBehaviour
{
    private MiniGameManager1 _gameManager;

    [SerializeField] private MiniGameUIManager1 _uiManager;
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _exitButton;

    private void Awake()
    {
        _retryButton.onClick.AddListener(OnClickRestartButton);
        _exitButton.onClick.AddListener(OnClickExitButton);
    }

    private void Start()
    {
        _gameManager = MiniGameManager1.Instance;
    }

    void OnClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnClickExitButton()
    {
        _gameManager.ActiveTime();
        SceneManager.LoadScene("MainScene");
    }
}
