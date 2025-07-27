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
        // gameManager를 가져와서
        // gameManager의 시간 재생/정지 메서드 사용하기. 
        _miniGameManager = MiniGameManager1.Instance;

        // DontDestroyOnLoad에 있는 메인씬 플레이어 가져오기 
        // 누가? 미니게임매니저가. 
        _miniGameManager.InitMainSceneObject();
    }

    void OnClickStartButton()
    {
        // 게임 시작
        // 1. HomeUI 오브젝트를 끈다. 
        // 2. GameUI 오브젝트를 킨다. 
        // 3. 시간이 흘러가게 한다. 
        _uiManager.InActiveUI(UIType.HomeUI);
        _uiManager.ActiveUI(UIType.GameUI);
        _miniGameManager.ActiveTime();
    }

    void OnClickExitButton()
    {
        // 게임 종료
        // 1. 점수 저장한다. (PlayerPrefs에 저장) -> 플레이어가 죽으면 점수가 저장됨. 여기서 처리X
        // 2. 현재 씬에서 벗어난다. (미니게임이 시작되면 GameManager에서 Time.timeSacle이 0이 됨)
        _miniGameManager.ActiveTime(); // 시간을 다시 1로 만들고 

        // 미니게임매니저한테 메인씬 오브젝트를 받는다.
        // 메인씬 오브젝트로 _mainSceneCharacterSpriteRenderer, _mainSceneCharacterCollider 받아온다. 
        //List<GameObject> objectsToKeep = _miniGameManager.Getobjects();
        //GameObject objectToKeep = objectsToKeep[0];
        GameObject player = _miniGameManager.GetMainScenePlayer();
        _mainSceneCharacterSpriteRenderer = player.GetComponentInChildren<SpriteRenderer>();
        _mainSceneCharacterCollider = player.GetComponent<BoxCollider2D>();

        _miniGameManager.SetVisible_Collider(_mainSceneCharacterSpriteRenderer, _mainSceneCharacterCollider);
        // 다시 MainScene으로 돌아왔을 때는 알파값으로 투명도 낮추고 콜라이더에 트리거 끄기
        SceneManager.LoadScene("MainScene"); // 메인씬 로드 
    }
}
