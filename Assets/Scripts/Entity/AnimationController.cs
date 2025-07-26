using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 애니메이션 동작 클래스 
public class AnimationController : MonoBehaviour
{
    // 애니메이션을 동작시킬 애니메이터가 필요함. 
    private Animator _animator;
    // 애니메이션 파리미터명이 필요함
    // 애니메이션 파라미터명은 string이면 안 좋다고 하니 해시값으로 바꾸자. 
    private static readonly int Move = Animator.StringToHash("Move");

    private int moveNumber;

    // 초기화는 Awake에서 
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        // 애니메이터는 Player오브젝트의 하위 오브젝트가 가지고 있음. 
    }

    // 애니메이션 적용 메서드
    public void MoveAnimation(State state)
    {
        _animator.SetInteger(Move, (int)state);
    }
}
