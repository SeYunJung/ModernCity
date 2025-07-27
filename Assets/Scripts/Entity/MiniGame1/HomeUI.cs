using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour
{
    private MiniGameManager1 _miniGameManager;

    [SerializeField] private MiniGameUIManager1 _uiManager;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;

    private SpriteRenderer _mainSceneCharacterSpriteRenderer;
    private BoxCollider2D _mainSceneCharacterCollider;

    private void Awake()
    {
        _startButton.onClick.AddListener(OnClickStartButton);
        _exitButton.onClick.AddListener(OnClickExitButton);
    }

    private void Start()
    {
        // gameManager�� �����ͼ�
        // gameManager�� �ð� ���/���� �޼��� ����ϱ�. 
        _miniGameManager = MiniGameManager1.Instance;

        // DontDestroyOnLoad�� �ִ� ���ξ� �÷��̾� �������� 
        // ����? �̴ϰ��ӸŴ�����. 
        _miniGameManager.InitMainSceneObject();
    }

    void OnClickStartButton()
    {
        // ���� ����
        // 1. HomeUI ������Ʈ�� ����. 
        // 2. GameUI ������Ʈ�� Ų��. 
        // 3. �ð��� �귯���� �Ѵ�. 
        _uiManager.InActiveUI(UIType.HomeUI);
        _uiManager.ActiveUI(UIType.GameUI);
        _miniGameManager.ActiveTime();
    }

    void OnClickExitButton()
    {
        // ���� ����
        // 1. ���� �����Ѵ�. (PlayerPrefs�� ����) -> �÷��̾ ������ ������ �����. ���⼭ ó��X
        // 2. ���� ������ �����. (�̴ϰ����� ���۵Ǹ� GameManager���� Time.timeSacle�� 0�� ��)
        _miniGameManager.ActiveTime(); // �ð��� �ٽ� 1�� ����� 

        // �̴ϰ��ӸŴ������� ���ξ� ������Ʈ�� �޴´�.
        // ���ξ� ������Ʈ�� _mainSceneCharacterSpriteRenderer, _mainSceneCharacterCollider �޾ƿ´�. 
        //List<GameObject> objectsToKeep = _miniGameManager.Getobjects();
        //GameObject objectToKeep = objectsToKeep[0];
        GameObject player = _miniGameManager.GetMainScenePlayer();
        _mainSceneCharacterSpriteRenderer = player.GetComponentInChildren<SpriteRenderer>();
        _mainSceneCharacterCollider = player.GetComponent<BoxCollider2D>();

        _miniGameManager.SetVisible_Collider(_mainSceneCharacterSpriteRenderer, _mainSceneCharacterCollider);
        // �ٽ� MainScene���� ���ƿ��� ���� ���İ����� ���� ���߰� �ݶ��̴��� Ʈ���� ����
        SceneManager.LoadScene("MainScene"); // ���ξ� �ε� 
    }
}
