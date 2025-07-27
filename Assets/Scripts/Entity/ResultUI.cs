using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    private Button _okButton;

    private MainUIManager _mainUIManager;

    private void Awake()
    {
        _okButton.onClick.AddListener(OnClickOkButton);
    }

    private void Start()
    {
        _mainUIManager = MainUIManager.Instance;
    }

    public void Init()
    {
        scoreText.text = PlayerPrefs.GetInt("Score").ToString();
        bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
    }

    private void OnClickOkButton()
    {
        _mainUIManager.InActiveUI(UIType.Home);
    }
}
