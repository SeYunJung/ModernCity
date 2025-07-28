using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UserUI;

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
    public DialogueUI diaLogueUI;
    public LeaderBoardUI leaderBoardUI;

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
            case UIType.LeaderBoard:
                leaderBoardUI.gameObject.SetActive(false);
                break;
        }
    }

    public void ActiveUI(UIType type)
    {
        switch (type)
        {
            case UIType.Dialogue2:
                // Dialogue1 UI지우고 2띄우기
                diaLogueUI.npcText1.gameObject.SetActive(false);
                diaLogueUI.okButton1.gameObject.SetActive(false);
                diaLogueUI.npcText2.gameObject.SetActive(true);
                diaLogueUI.okButton2.gameObject.SetActive(true);
                break;
            case UIType.LeaderBoard:
                leaderBoardUI.gameObject.SetActive(true);
                break;
        }
    }

    public void ShowDialogue()
    {
        diaLogueUI.gameObject.SetActive(true);
        diaLogueUI.npcText1.gameObject.SetActive(true);
        diaLogueUI.okButton1.gameObject.SetActive(true);
    }

    public void SetLeaderBoard(PlayerDataPakage playerDataPakage)
    {
        List<PlayerData> list = playerDataPakage.playerDatas;

        for(int i = 0; i < list.Count; i++)
        {
            if(i == 0)
            {
                leaderBoardUI.name1.text = list[i].name;
                leaderBoardUI.score1.text = list[i].score.ToString();
            }
            else if(i == 1)
            {
                leaderBoardUI.name2.text = list[i].name;
                leaderBoardUI.score2.text = list[i].score.ToString();
            }
            else if (i == 2)
            {
                leaderBoardUI.name3.text = list[i].name;
                leaderBoardUI.score3.text = list[i].score.ToString();
            }
            else if (i == 3)
            {
                leaderBoardUI.name4.text = list[i].name;
                leaderBoardUI.score4.text = list[i].score.ToString();
            }
            else if (i == 4)
            {
                leaderBoardUI.name5.text = list[i].name;
                leaderBoardUI.score5.text = list[i].score.ToString();
            }
        }
    }
}
