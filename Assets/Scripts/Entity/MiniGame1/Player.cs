using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private BoxCollider2D _collider;

    public float moveSpeed = 1.0f;
    public float jumpForce = 1.0f;

    private bool _isJump;

    private bool _isDead;

    private Animator _animator;

    private MiniGameManager1 _miniGameManager;
    [SerializeField] private MiniGameUIManager1 _uiManager;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _animator = GetComponentInChildren<Animator>();

        if (_rigid == null)
            Debug.LogError("_rigid 초기화 에러");
        if (_collider == null)
            Debug.LogError("_collider 초기화 에러");
    }

    private void Start()
    {
        _miniGameManager = MiniGameManager1.Instance;
    }

    private void FixedUpdate()
    {
        if (!_isDead)
        {
            Vector3 velocity = _rigid.velocity;
            velocity.x = moveSpeed;

            if (_isJump)
            {
                velocity.y += jumpForce; // 점프 가속도 더해주고 
                _isJump = false;
            }

            // 다 계산 후에 적용
            _rigid.velocity = velocity;

            // 회전
            float angle = Mathf.Clamp(_rigid.velocity.y * 10f, -90, 90);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _isJump = true;
        }

        if (_isDead)
        {
            //if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
            //{
            //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //}
            // 죽으면 재도전 여부 물어보기 
            _uiManager.ActiveUI(UIType.RetryUI); // 재도전 UI 띄우기
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 캐릭터가 죽으면 충돌처리X
        if (_isDead) return;

        // 충돌을 하면 움직이지 못하게 하고 죽은 애니메이션을 보이게 해보자. 
        if (collision.gameObject.CompareTag("obstacle"))
        {
            _isDead = true; // 움직이지 못하게 하기 

            // 죽은 애니메이션 보이게 하기 -> 애니메이터가 필요하다. 
            _animator.SetInteger("isDead", 1);

            _miniGameManager.Lose();

            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isDead) return;

        if (collision.gameObject.CompareTag("spike"))
        {
            // 점수 추가
            _miniGameManager.AddScore();
        }
    }
}

