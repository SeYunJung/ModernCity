using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ½Ì±ÛÅæ ±¸Çö => ´Ù¸¥ ¾À¿¡¼­µµ »ç¿ëÇÏ±â À§ÇØ ½Ì±ÛÅæÀ¸·Î ±¸Çö 
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
        Debug.Log("³Ë¹é!");
        PlayerController playerController = FindObjectOfType<PlayerController>();
        playerController.ApplyKnockback();
    }
}
