using System.Collections;
using System.Collections.Generic;
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
        }
    }
}
