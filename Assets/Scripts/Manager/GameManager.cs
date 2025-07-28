using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UserUI;

public class GameManager : MonoBehaviour
{
    // �̱��� ���� => �ٸ� �������� ����ϱ� ���� �̱������� ���� 
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
        // �����͸� �ҷ��� ��� ����
        string path = Path.Combine(Application.dataPath, "ranking.json");

        if (!File.Exists(path))
        {
            Debug.LogError("���� ����");
        }
        // ������ �ؽ�Ʈ�� string���� ����
        string jsonData = File.ReadAllText(path);
        // �� Json�����͸� ������ȭ�Ͽ� playerData�� �־���
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
