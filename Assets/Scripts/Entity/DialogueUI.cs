using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public Button okButton1;
    public Button okButton2;

    public TextMeshProUGUI npcText1;
    public TextMeshProUGUI npcText2;

    private MainUIManager _mainUIManager;
    private GameManager _gameManager;

    private void Awake()
    {
        okButton1.onClick.AddListener(OnClickOkButton1);
        okButton2.onClick.AddListener(OnClickOkButton2);
    }

    private void Start()
    {
        _mainUIManager = MainUIManager.Instance;
        _gameManager = GameManager.Instance;
    }

    private void OnClickOkButton1()
    {
        _mainUIManager.ActiveUI(UIType.Dialogue2);
    }

    private void OnClickOkButton2()
    {
        _mainUIManager.InActiveUI(UIType.Dialogue2);
        _gameManager.Knockback();
    }
}
