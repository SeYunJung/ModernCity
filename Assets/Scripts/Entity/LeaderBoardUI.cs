using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardUI : MonoBehaviour
{
    public Button okButton;

    private GameManager _gameManager;
    private MainUIManager _mainUIManager;

    private GameObject player;

    public TextMeshProUGUI name1;
    public TextMeshProUGUI name2;
    public TextMeshProUGUI name3;
    public TextMeshProUGUI name4;
    public TextMeshProUGUI name5;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI score3;
    public TextMeshProUGUI score4;
    public TextMeshProUGUI score5;


    private void Awake()
    {
        okButton.onClick.AddListener(OnClickOKButton);
    }
    private void Start()
    {
        _gameManager = GameManager.Instance;
        _mainUIManager = MainUIManager.Instance;
        player = _gameManager.GetPlayer();
    }

    private void OnClickOKButton()
    {
        _gameManager.ActiveTime();
        _mainUIManager.InActiveUI(UIType.LeaderBoard);
    }
}
