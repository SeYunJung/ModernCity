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

// 캐릭터 *이동* 클래스  (이동만 하자. 다른건 다른 클래스에게 요청하자.) 
public class BaseController : MonoBehaviour
{
    // 플레이어가 움직일때 필요한 것들 
    // Rigidbody2D, OnMove 메서드, 속도, 애니메이션 메서드, 이동 방향 변수, 애니메이터 
    // 1. Rigidbody2D를 가져온다. 
    // 2. OnMove 메서드로 캐릭터를 움직여본다. 
    // 3. 애니메이션 메서드로 애니메이션을 적용해본다. 

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
        Movement(); // _movementDirection 방향으로 _moveSpeed 만큼 캐릭터 이동 
    }

    void Movement()
    {
        _rigid.velocity = _movementDirection * _moveSpeed;
        _animationController.MoveAnimation(state); // 애니메이션 적용
    }
}
