using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : BaseController
{
    private InteractiveManager _interactiveManager;
    private Rect _miniGameArea;

    private bool isInsideMiniGameArea;
    private bool isMiniGameStart;

    private GameManager _gameManager;

    //private SpriteRenderer _spriteRenderer;
    //private Color _spriteColor;

    //private BoxCollider2D _collider;

    //private MiniGameManager1 _miniGameManager1;

    protected override void Awake()
    {
        base.Awake();

        //Init();

        // ���� ����Ǹ� Player������Ʈ�� DontDestroyOnLoad�� �ű��
        // => �̴ϰ��ӿ��� �ٽ� ���ξ����� ���ƿ��� �� ���� �÷��̾ �״�� ���� ���ؼ� 
        var objs = FindObjectsOfType<PlayerController>();
        if (objs.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected override void Start()
    {
        base.Start();
        _interactiveManager = InteractiveManager.Instance;
        _miniGameArea = _interactiveManager.GetMiniGameArea();

        _gameManager = GameManager.Instance;

        //_miniGameManager1 = MiniGameManager1.Instance;
        //_miniGameManager1.AddobjectsToKeep(gameObject);
    }

    private void Update()
    {
        // �÷��̾ �̵��ϴٰ� �̴ϰ��� ����(Ư������)�� �����ϸ� 
        // Ư�������� �˷��� InteractiveManager�� �˷���� �Ѵ�. InteractiveManager�� ��������. 
        // �ٵ� Manager�ݾ�. InteractiveManager�� ���߿� �ٸ� ������ ����� �� ������ �̱������� ������. 
        if (!isMiniGameStart)
        {
            isInsideMiniGameArea = _miniGameArea.Contains(transform.position);
            if (isInsideMiniGameArea)
            {
                Debug.Log("�̴ϰ����� �����Ѵ�.");
                //_miniGameManager1.SetInvisible_TriggerCollider(_spriteRenderer, _collider);
                // �̴ϰ��� ���� �� �÷��̾�� �����ڸ� �״�� �־�� ��.
                // �÷��̾ ��� �����ؾ� �ϴ� �Ŵ� DontDestroyOnLoad�� �÷��̾ �����ص־� ��.
                // �̴ϰ����� ���۵Ǹ� �÷��̾ ��� ������. 
                // �����ϰ� ����� Ʈ���� �浹�� üũ�ؼ� �÷��̾ �Ⱥ��̰� ����. 
                _gameManager.PlayerInvisibleMode(this.gameObject);
                _gameManager.InActiveTime(); // �ð� ���߱� => �̴ϰ����� �ٷ� ������� �ʰ� ������� 
                _gameManager.LoadScene("MiniGame_1");

                // �ٽ� MainScene���� ���ƿ��� ���� ���İ����� ���� ���߰� �ݶ��̴��� Ʈ���� ���� 
                //SceneManager.LoadScene("MiniGame1");
                isMiniGameStart = true;
            }
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    //private void Init()
    //{
    //    _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    //    _collider = GetComponent<BoxCollider2D>();
    //    //_miniGameManager1 = MiniGameManager1.Instance;
    //    //Time.timeScale = 1.0f;
    //}

    private void OnMove(InputValue inputValue)
    {
        _movementDirection = inputValue.Get<Vector2>();
        _movementDirection = _movementDirection.normalized;
        // �̵���(inputValue)�� �̵� ������ ���� 

        state = (_movementDirection == Vector3.zero) ? State.Idle :
                (_movementDirection == Vector3.left || ((_movementDirection.x < 0 && _movementDirection.y > 0) || (_movementDirection.x < 0 && _movementDirection.y < 0))) ? State.LeftMove :
                (_movementDirection == Vector3.right || ((_movementDirection.x > 0 && _movementDirection.y > 0) || (_movementDirection.x > 0 && _movementDirection.y < 0))) ? State.RightMove :
                (_movementDirection == Vector3.up) ? State.TopMove : State.BottomMove;
    }
}
