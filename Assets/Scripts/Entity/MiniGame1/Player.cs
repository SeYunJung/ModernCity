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
            Debug.LogError("_rigid �ʱ�ȭ ����");
        if (_collider == null)
            Debug.LogError("_collider �ʱ�ȭ ����");
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
                velocity.y += jumpForce; // ���� ���ӵ� �����ְ� 
                _isJump = false;
            }

            // �� ��� �Ŀ� ����
            _rigid.velocity = velocity;

            // ȸ��
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
            // ������ �絵�� ���� ����� 
            _uiManager.ActiveUI(UIType.RetryUI); // �絵�� UI ����
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ĳ���Ͱ� ������ �浹ó��X
        if (_isDead) return;

        // �浹�� �ϸ� �������� ���ϰ� �ϰ� ���� �ִϸ��̼��� ���̰� �غ���. 
        if (collision.gameObject.CompareTag("obstacle"))
        {
            _isDead = true; // �������� ���ϰ� �ϱ� 

            // ���� �ִϸ��̼� ���̰� �ϱ� -> �ִϸ����Ͱ� �ʿ��ϴ�. 
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
            // ���� �߰�
            _miniGameManager.AddScore();
        }
    }
}

