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

        // 씬이 실행되면 Player오브젝트를 DontDestroyOnLoad로 옮기기
        // => 미니게임에서 다시 메인씬으로 돌아왔을 때 기존 플레이어를 그대로 쓰기 위해서 
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
        // 플레이어가 이동하다가 미니게임 영역(특정영역)에 도달하면 
        // 특정영역을 알려면 InteractiveManager가 알려줘야 한다. InteractiveManager를 가져오자. 
        // 근데 Manager잖아. InteractiveManager는 나중에 다른 곳에서 사용할 수 있으니 싱글톤으로 만들자. 
        if (!isMiniGameStart)
        {
            isInsideMiniGameArea = _miniGameArea.Contains(transform.position);
            if (isInsideMiniGameArea)
            {
                Debug.Log("미니게임을 실행한다.");
                //_miniGameManager1.SetInvisible_TriggerCollider(_spriteRenderer, _collider);
                // 미니게임 종류 후 플레이어는 예전자리 그대로 있어야 함.
                // 플레이어를 계속 유지해야 하는 거니 DontDestroyOnLoad에 플레이어를 저장해둬야 함.
                // 미니게임이 시작되면 플레이어를 잠깐 숨기자. 
                // 투명하게 만들고 트리거 충돌을 체크해서 플레이어가 안보이게 하자. 
                _gameManager.PlayerInvisibleMode(this.gameObject);
                _gameManager.InActiveTime(); // 시간 멈추기 => 미니게임이 바로 실행되지 않게 만들려고 
                _gameManager.LoadScene("MiniGame_1");

                // 다시 MainScene으로 돌아왔을 때는 알파값으로 투명도 낮추고 콜라이더에 트리거 끄기 
                //SceneManager.LoadScene("MiniGame1");
                isMiniGameStart = true;
            }
        }

        // NPC와 충돌하면
        if (_hitNPC)
        {
            _hitNPC = false;
            _gameManager.RequestDialogue();
        }

        // 넉백 상태이면 넉백 타이머를 작동시키고 넉백 지속시간이 끝나면 넉백 상태 해제 
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
                Debug.Log("리더보드를 실행한다.");
                MainUIManager manager = MainUIManager.Instance;

                // 데이터 로드
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
            // 넉백 적용 
            _rigid.velocity = Vector2.zero;
            _rigid.AddForce(Vector3.down * knockbackForce, ForceMode2D.Impulse);

            // 넉백 상태 설정, 타이머 초기화
            _isKnockback = true;
            _knockbackTimer = knockbackDuration;
        }
    }

    private void OnMove(InputValue inputValue)
    {
        _movementDirection = inputValue.Get<Vector2>();
        _movementDirection = _movementDirection.normalized;
        // 이동값(inputValue)로 이동 방향을 설정 

        state = (_movementDirection == Vector3.zero) ? State.Idle :
                (_movementDirection == Vector3.left || ((_movementDirection.x < 0 && _movementDirection.y > 0) || (_movementDirection.x < 0 && _movementDirection.y < 0))) ? State.LeftMove :
                (_movementDirection == Vector3.right || ((_movementDirection.x > 0 && _movementDirection.y > 0) || (_movementDirection.x > 0 && _movementDirection.y < 0))) ? State.RightMove :
                (_movementDirection == Vector3.up) ? State.TopMove : State.BottomMove;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("npc"))
        {
            Debug.Log("NPC충돌!");
            _hitNPC = true;
            // _hitNPC가 true이면 대화창이 뜨게 하자. 
        }
    }
}
