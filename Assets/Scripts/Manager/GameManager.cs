using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UserUI;

public class GameManager : MonoBehaviour
{
    // 싱글톤 구현 => 다른 씬에서도 사용하기 위해 싱글톤으로 구현 
    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                return null;
            }
            return _instance;
        }
    }

    private MainUIManager _mainUIManager;
    private MiniGameUIManager _miniGameUIManager;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        _mainUIManager = MainUIManager.Instance;
        _miniGameUIManager = MiniGameUIManager.Instance;
    }

    public MiniGameUIManager GetMiniGameManager()
    {
        return _miniGameUIManager;
    }

    public void RequestRankingData()
    {
        // 데이터를 불러올 경로 지정
        string path = Path.Combine(Application.dataPath, "ranking.json");

        if (!File.Exists(path))
        {
            Debug.LogError("파일 없음");
        }
        // 파일의 텍스트를 string으로 저장
        string jsonData = File.ReadAllText(path);
        // 이 Json데이터를 역직렬화하여 playerData에 넣어줌
        PlayerDataPakage playerDataPakage = JsonUtility.FromJson<PlayerDataPakage>(jsonData);

        _mainUIManager.SetLeaderBoard(playerDataPakage);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PlayerInvisibleMode(GameObject player)
    {
        SpriteRenderer playerSpriteRenderer = player.GetComponentInChildren<SpriteRenderer>();
        BoxCollider2D playerCollider = player.GetComponent<BoxCollider2D>();

        Color spriteColor = playerSpriteRenderer.color;
        spriteColor.a = 0;
        playerSpriteRenderer.color = spriteColor;
        playerCollider.isTrigger = true;
    }

    public void PlayerVisibleMode(GameObject player)
    {
        SpriteRenderer playerSpriteRenderer = player.GetComponentInChildren<SpriteRenderer>();
        BoxCollider2D playerCollider = player.GetComponent<BoxCollider2D>();

        Color spriteColor = playerSpriteRenderer.color;
        spriteColor.a = 1;
        playerSpriteRenderer.color = spriteColor;
        playerCollider.isTrigger = false;
    }

    public void InActiveTime()
    {
        Time.timeScale = 0.0f;
    }

    public void ActiveTime()
    {
        Time.timeScale = 1.0f;
    }

    public GameObject GetPlayer()
    {
        return GameObject.FindObjectOfType<PlayerController>().gameObject;
    }

    public void RequestResultUI()
    {
        _mainUIManager.ShowMiniGameResult();
    }

    public void RequestDialogue()
    {
        _mainUIManager.ShowDialogue();
    }

    public void Knockback()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();
        playerController.ApplyKnockback();
    }
}
