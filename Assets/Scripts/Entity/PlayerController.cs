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

        // �÷��̾ �̵��ϴٰ� �̴ϰ��� ����(Ư������)�� �����ϸ� 
        // Ư�������� �˷��� InteractiveManager�� �˷���� �Ѵ�. InteractiveManager�� ��������. 
        // �ٵ� Manager�ݾ�. InteractiveManager�� ���߿� �ٸ� ������ ����� �� ������ �̱������� ������. 
        //if ()
        //{
        //    Debug.Log("�̴ϰ����� �����Ѵ�");
        //}
        if (!loopCut)
        {
            isInsideMiniGameArea = _miniGameArea.Contains(transform.position);
            if (isInsideMiniGameArea)
            {
                Debug.Log("�̴ϰ����� �����Ѵ�.");
                SceneManager.LoadScene("MiniGame1");
                loopCut = true;
            }
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
        //state = (_movementDirection.x == 0) ? State.Idle :
        //        (_movementDirection.x < 0 || (_movementDirection.x < 0 && _movementDirection.y > 0) || (_movementDirection.x < 0 && _movementDirection.y < 0)) ? State.LeftMove :
        //        (_movementDirection.x > 0 || (_movementDirection.x > 0 && _movementDirection.y > 0) || (_movementDirection.x > 0 && _movementDirection.y < 0)) ? State.RightMove :
        //        (_movementDirection.y > 0) ? State.TopMove : State.BottomMove;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Door"))
    //    {
    //        Debug.Log("���� �浹��");
    //    }
    //}
}
