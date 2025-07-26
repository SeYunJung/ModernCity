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
    private bool loopCut;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        _interactiveManager = InteractiveManager.Instance;
        _miniGameArea = _interactiveManager.GetMiniGameArea();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        // 플레이어가 이동하다가 미니게임 영역(특정영역)에 도달하면 
        // 특정영역을 알려면 InteractiveManager가 알려줘야 한다. InteractiveManager를 가져오자. 
        // 근데 Manager잖아. InteractiveManager는 나중에 다른 곳에서 사용할 수 있으니 싱글톤으로 만들자. 
        //if ()
        //{
        //    Debug.Log("미니게임을 실행한다");
        //}
        if (!loopCut)
        {
            isInsideMiniGameArea = _miniGameArea.Contains(transform.position);
            if (isInsideMiniGameArea)
            {
                Debug.Log("미니게임을 실행한다.");
                SceneManager.LoadScene("MiniGame1");
                loopCut = true;
            }
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
        //state = (_movementDirection.x == 0) ? State.Idle :
        //        (_movementDirection.x < 0 || (_movementDirection.x < 0 && _movementDirection.y > 0) || (_movementDirection.x < 0 && _movementDirection.y < 0)) ? State.LeftMove :
        //        (_movementDirection.x > 0 || (_movementDirection.x > 0 && _movementDirection.y > 0) || (_movementDirection.x > 0 && _movementDirection.y < 0)) ? State.RightMove :
        //        (_movementDirection.y > 0) ? State.TopMove : State.BottomMove;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Door"))
    //    {
    //        Debug.Log("문과 충돌함");
    //    }
    //}
}
