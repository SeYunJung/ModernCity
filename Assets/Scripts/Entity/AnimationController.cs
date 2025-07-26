using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ִϸ��̼� ���� Ŭ���� 
public class AnimationController : MonoBehaviour
{
    // �ִϸ��̼��� ���۽�ų �ִϸ����Ͱ� �ʿ���. 
    private Animator _animator;
    // �ִϸ��̼� �ĸ����͸��� �ʿ���
    // �ִϸ��̼� �Ķ���͸��� string�̸� �� ���ٰ� �ϴ� �ؽð����� �ٲ���. 
    private static readonly int Move = Animator.StringToHash("Move");

    private int moveNumber;

    // �ʱ�ȭ�� Awake���� 
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        // �ִϸ����ʹ� Player������Ʈ�� ���� ������Ʈ�� ������ ����. 
    }

    // �ִϸ��̼� ���� �޼���
    public void MoveAnimation(State state)
    {
        _animator.SetInteger(Move, (int)state);
    }
}
