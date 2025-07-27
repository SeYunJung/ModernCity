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
            Debug.LogError("_rigid �ʱ�ȭ ����");
        if (_collider == null)
            Debug.LogError("_collider �ʱ�ȭ ����");
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
            // �̵��ӵ� ��� 
            Vector3 velocity = _rigid.velocity;
            velocity.x = _moveSpeed;

            // ���� ���ɿ��� Ȯ��
            if (_isJump)
            {
                velocity.y += _jumpForce;
                _isJump = false;
            }

            // �̵� 
            _rigid.velocity = velocity;

            // ȸ��
            angle = Mathf.Clamp(_rigid.velocity.y * 10f, -90, 90);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("spike"))
        {
            // ���� ���� 
            // ĳ���Ͱ� ������ �浹ó��X
            if (_isDead) return;

            _isDead = true; // �������� ���ϰ� �ϱ� 

            // ���� �ִϸ��̼� ���̰� �ϱ� -> �ִϸ����Ͱ� �ʿ��ϴ�. 
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
