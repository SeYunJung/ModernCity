using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainUIManager : MonoBehaviour
{
    // �̱��� ���� => �ٸ� �������� ����ϱ� ���� �̱������� ���� 
    private static MainUIManager _instance = null;
    public static MainUIManager Instance
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

    public ResultUI resultUI;
    public DialogueUI diaLogueUI;   

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void ShowMiniGameResult()
    {
        Debug.Log("���Ӱ��!");
        //resultUI = GameObject.Find("ResultPanel").GetComponent<ResultUI>();
        //resultUI = GameObject.Find("Canvas").transform.Find("ResultPanel").GetComponent<ResultUI>();
        resultUI = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<ResultUI>();    
        resultUI.Init();
        resultUI.gameObject.SetActive(true);
    }

    public void InActiveUI(UIType type)
    {
        switch (type)
        {
            case UIType.Home:
                resultUI.gameObject.SetActive(false);
                break;
            case UIType.Dialogue2:
                diaLogueUI.npcText2.gameObject.SetActive(false);
                diaLogueUI.okButton2.gameObject.SetActive(false);
                diaLogueUI.gameObject.SetActive(false);
                break;
        }
    }

    public void ActiveUI(UIType type)
    {
        switch (type)
        {
            case UIType.Dialogue2:
                // Dialogue1 UI����� 2����
                diaLogueUI.npcText1.gameObject.SetActive(false);
                diaLogueUI.okButton1.gameObject.SetActive(false);
                diaLogueUI.npcText2.gameObject.SetActive(true);
                diaLogueUI.okButton2.gameObject.SetActive(true);
                break;
        }
    }

    public void ShowDialogue()
    {
        //diaLogueUI.ActiveUI();
        diaLogueUI.gameObject.SetActive(true);
        diaLogueUI.npcText1.gameObject.SetActive(true);
        diaLogueUI.okButton1.gameObject.SetActive(true);
    }
}
