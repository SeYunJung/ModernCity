using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    private GameManager _gameManager;
    private MiniGameUIManager _miniGameUIManager;

    private GameObject player;

    private void Awake()
    {
        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _miniGameUIManager = MiniGameUIManager.Instance;
        player = _gameManager.GetPlayer();
    }

    private void OnClickStartButton()
    {
        _gameManager.ActiveTime();
        _miniGameUIManager.InActiveUI(UIType.Home);
        _miniGameUIManager.ActiveUI(UIType.Game);
    }

    private void OnClickExitButton()
    {
        _miniGameUIManager.InActiveUI(UIType.Home);
        _gameManager.ActiveTime();
        _gameManager.PlayerVisibleMode(player);
        SceneManager.LoadScene("MainScene");
    }
}
