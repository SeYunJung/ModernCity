using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : BaseController
{
    private InteractiveManager _interactiveManager;
    private Rect _miniGameArea;
    private Rect _leaderBoardArea;

    private bool isInsideMiniGameArea;
    private bool isMiniGameStart;
    private bool isLeaderBoardStart;
    private bool isLeaderBoardArea;

    private GameManager _gameManager;


    private bool _hitNPC;

    private bool _isKnockback;
    private float _knockbackTimer;
    public float knockbackForce;
    public float knockbackDuration;


    protected override void Awake()
    {
        base.Awake();

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
        _leaderBoardArea = _interactiveManager.GetLeaderBoardArea();

        _gameManager = GameManager.Instance;
    }

    protected override void Update()
    {
        base.Update();
        //Debug.Log($"moveDirection = {_movementDirection}");
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

        // NPC�� �浹�ϸ�
        if (_hitNPC)
        {
            _hitNPC = false;
            _gameManager.RequestDialogue();
        }

        // �˹� �����̸� �˹� Ÿ�̸Ӹ� �۵���Ű�� �˹� ���ӽð��� ������ �˹� ���� ���� 
        if (_isKnockback)
        {
            _knockbackTimer -= Time.deltaTime;
            if(_knockbackTimer <= 0)
            {
                _isKnockback = false;
            }
        }

        if (!isLeaderBoardStart)
        {
            isLeaderBoardArea = _leaderBoardArea.Contains(transform.position);
            if (isLeaderBoardArea)
            {
                Debug.Log("�������带 �����Ѵ�.");
                MainUIManager manager = MainUIManager.Instance;

                // ������ �ε�
                //MiniGameUIManager miniGameUIManager = _gameManager.GetMiniGameManager();
                //Debug.Log($"miniGame = {miniGameUIManager}");
                _gameManager.RequestRankingData();

                manager.ActiveUI(UIType.LeaderBoard);

                isLeaderBoardStart = true;
            }
        }
    }

    protected override void FixedUpdate()
    {
        if (!_isKnockback)
            base.FixedUpdate();
    }

    public void ApplyKnockback()
    {
        Knockback();
    }

    public void Knockback()
    {
        if (!_isKnockback)
        {
            // �˹� ���� 
            _rigid.velocity = Vector2.zero;
            _rigid.AddForce(Vector3.down * knockbackForce, ForceMode2D.Impulse);

            // �˹� ���� ����, Ÿ�̸� �ʱ�ȭ
            _isKnockback = true;
            _knockbackTimer = knockbackDuration;
        }
    }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("npc"))
        {
            Debug.Log("NPC�浹!");
            _hitNPC = true;
            // _hitNPC�� true�̸� ��ȭâ�� �߰� ����. 
        }
    }
}
