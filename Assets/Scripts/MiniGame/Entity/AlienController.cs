using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private BoxCollider2D _collider;

    private bool _isJump;

    public float _moveSpeed;
    public float _jumpForce;

    private float angle;

    private MiniGameUIManager _miniGameUIManager;
    private GameUI _gameUI;

    private bool _isDead;

    private Animator _animator;

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
        _miniGameUIManager = MiniGameUIManager.Instance;
        _gameUI = _miniGameUIManager.gameUI.GetComponent<GameUI>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _isJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (!_isDead)
        {
            // 이동속도 계산 
            Vector3 velocity = _rigid.velocity;
            velocity.x = _moveSpeed;

            // 점프 가능여부 확인
            if (_isJump)
            {
                velocity.y += _jumpForce;
                _isJump = false;
            }

            // 이동 
            _rigid.velocity = velocity;

            // 회전
            angle = Mathf.Clamp(_rigid.velocity.y * 10f, -90, 90);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("spike"))
        {
            // 게임 오버 
            // 캐릭터가 죽으면 충돌처리X
            if (_isDead) return;

            _isDead = true; // 움직이지 못하게 하기 

            // 죽은 애니메이션 보이게 하기 -> 애니메이터가 필요하다. 
            _animator.SetBool("IsDead", true);

            _miniGameUIManager.Lose();

            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("spikes"))
        {
            _gameUI.AddScore(1);
        }
    }
}
