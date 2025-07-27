using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager1 : Singleton<MiniGameManager1>
{
    private MiniGameUIManager1 _miniGameUIManager1;
    private MiniGameScoreManager1 _miniGameScoreManager1;

    public int currentScore = 0;
    public int score = 1;

    private List<GameObject> objectsToKeep;

    private void Awake()
    {
        Time.timeScale = 0f;

        var objs = FindObjectsOfType<MiniGameManager1>();
        if (objs.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _miniGameUIManager1 = MiniGameUIManager1.Instance;
        _miniGameScoreManager1 = MiniGameScoreManager1.Instance;
    }

    public void Win()
    {
        Debug.Log("�¸�!");
    }

    public void Lose()
    {
        Debug.Log("�й�!");
        _miniGameUIManager1.ShowLose();
        _miniGameScoreManager1.SaveCurrentScore(currentScore);
        _miniGameScoreManager1.SaveBestScore();
    }

    public void AddScore()
    {
        currentScore += score;
        //MiniGameUIManager1.Instance.SetScore(currentScore);
        _miniGameUIManager1.SetScore(currentScore);
    }

    public void InActiveTime()
    {
        Time.timeScale = 0.0f;
    }

    public void ActiveTime()
    {
        Time.timeScale = 1.0f;
    }

    public void SetInvisible_TriggerCollider(SpriteRenderer spriteRenderer, BoxCollider2D collider)
    {
        // ���İ����� �����ϰ� ����
        Color spriteColor = spriteRenderer.color;
        spriteColor.a = 0;
        spriteRenderer.color = spriteColor;
        // �ݶ��̴��� Ʈ���� Ű��. 
        collider.isTrigger = true;
    }

    public void SetVisible_Collider(SpriteRenderer spriteRenderer, BoxCollider2D collider)
    {
        Color spriteColor = spriteRenderer.color;
        spriteColor.a = 1;
        spriteRenderer.color = spriteColor;
        collider.isTrigger = false;
    }

    public void InitMainSceneObject()
    {
        // DontDestroyOnLoad�� �ִ� ���ξ� �÷��̾� �������� 

    }

    public void AddobjectsToKeep(GameObject objectToKeep)
    {
        objectsToKeep.Add(objectToKeep);
    }

    public List<GameObject> Getobjects()
    {
         //= GameObject.FindObjectOfType<PlayerController>();
        return objectsToKeep;
    }

    public GameObject GetMainScenePlayer()
    {
        var obj = GameObject.FindObjectOfType<PlayerController>();
        return obj.gameObject;
    }
}
