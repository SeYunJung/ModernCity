using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 오브젝트를 자동 생성되게 해주는 스크립트
// 가상의 선이 있고 그 선에 오브젝트가 닿았을 때 특정 위치에 오브젝트를 옮기기 
public class AutoGenerator : MonoBehaviour
{
    public Transform groundTransform;
    public float collidingObjectWidth = 1f;

    public Transform spikeTransform;

    private int _groundGap = 30; 
    private int _spikeGap = 45;

    // 이 오브젝트에 트리거 콜라이더를 달고
    // 트리거 콜리션 메서드로 트리거된 오브젝트를 뒤로 보내기
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 부딪힌 오브젝트를 뒤로 보내기 
        if (collision.CompareTag("ground"))
        {
            // 현재위치 + 30만큼 이동
            // 1 -> 11 
            Vector3 collidingObjectPosition = collision.transform.position;
            collidingObjectPosition.x = collidingObjectPosition.x + _groundGap;
            // 1 + 30 = 31
            // 2 + 30 = 32
            // 3 + 30 = 33
            collision.transform.position = collidingObjectPosition;
            return;
        }

        if (collision.CompareTag("spikes"))
        {
            // spike는 길이를 다르게 설정하자. 
            Vector3 collidingObjectPosition = collision.transform.position;
            collidingObjectPosition.x = collidingObjectPosition.x + _spikeGap;
            collision.transform.position = collidingObjectPosition;

            //Vector3 child1LocalPosition = collision.gameObject.transform.GetChild(0).transform.localPosition;
            //Vector3 child2LocalPosition = collision.gameObject.transform.GetChild(1).transform.localPosition;
            //child1LocalPosition.x = 0;
            //child2LocalPosition.x = 0;
            //collision.transform.GetChild(0).transform.localPosition = child1LocalPosition;
            //collision.transform.GetChild(1).transform.localPosition = child2LocalPosition;


            //Vector3 parentPosition = collision.gameObject.transform.parent.position;
            //parentPosition.x = parentPosition.x + _groundGap;
            //collision.gameObject.transform.parent.position = parentPosition;
            return;
        }
    }
}
