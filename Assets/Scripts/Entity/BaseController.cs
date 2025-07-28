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
        
    }

    protected virtual void FixedUpdate()
    {
        Movement(); // _movementDirection �������� _moveSpeed ��ŭ ĳ���� �̵� 
    }

    void Movement()
    {
        _rigid.velocity = _movementDirection * _moveSpeed;
        _animationController.MoveAnimation(state); // �ִϸ��̼� ����
    }
}
