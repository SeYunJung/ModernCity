using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum State
{
    Idle,
    LeftMove,
    RightMove,
    TopMove,
    BottomMove
}

// ĳ���� *�̵�* Ŭ����  (�̵��� ����. �ٸ��� �ٸ� Ŭ�������� ��û����.) 
public class BaseController : MonoBehaviour
{
    // �÷��̾ �����϶� �ʿ��� �͵� 
    // Rigidbody2D, OnMove �޼���, �ӵ�, �ִϸ��̼� �޼���, �̵� ���� ����, �ִϸ����� 
    // 1. Rigidbody2D�� �����´�. 
    // 2. OnMove �޼���� ĳ���͸� ����������. 
    // 3. �ִϸ��̼� �޼���� �ִϸ��̼��� �����غ���. 

    protected Rigidbody2D _rigid;
    public float _moveSpeed;

    protected Vector3 _movementDirection;
    protected State state;

    private AnimationController _animationController;

    //protected bool _isKnockback;
    //public float selfKnockbackPower;
    //public float knockbackTime;

    protected virtual void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _animationController = GetComponent<AnimationController>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        //if(_isKnockback)
        //{
        //    knockbackTime += Time.deltaTime;
        //    if(knockbackTime >= 1f)
        //    {
        //        knockbackTime = 0.0f;
        //        _isKnockback = false;
        //    }
        //}
    }

    protected virtual void FixedUpdate()
    {
        Movement(); // _movementDirection �������� _moveSpeed ��ŭ ĳ���� �̵� 
    }

    void Movement()
    {
        //if (_isKnockback)
        //{
        //    //_rigid.velocity = new Vector3(0, -selfKnockbackPower, 0);
        //    //_rigid.velocity = Vector2.zero;
        //    //_rigid.AddForce(new Vector2(0, -selfKnockbackPower), ForceMode2D.Impulse);

        //    //_movementDirection *= 0.2f;
        //    //_movementDirection += new Vector3(0, -selfKnockbackPower, 0);

        //    //_movementDirection = Vector3.down;
        //    //_isKnockback = false;
        //    //ApplyKnockback();
        //}
        //else
        //{
        _rigid.velocity = _movementDirection * _moveSpeed;
        //}
        _animationController.MoveAnimation(state); // �ִϸ��̼� ����
    }

    //void ApplyKnockback()
    //{
    //    _rigid.AddForce(Vector3.down * selfKnockbackPower, ForceMode2D.Impulse);
    //}
}
