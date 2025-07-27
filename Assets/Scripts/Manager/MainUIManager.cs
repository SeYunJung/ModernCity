using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIManager : MonoBehaviour
{
    // 싱글톤 구현 => 다른 씬에서도 사용하기 위해 싱글톤으로 구현 
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
        Debug.Log("게임결과!");
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
