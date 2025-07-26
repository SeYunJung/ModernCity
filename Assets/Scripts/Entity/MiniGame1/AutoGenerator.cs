using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGenerator : MonoBehaviour
{
    public Transform ground;

    public float collidingObjWidth = 1f;

    private MiniGameObstacleManager1 obstacleManager;

    void Start()
    {
        obstacleManager = MiniGameObstacleManager1.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            // 이동시키기. 
            // 현재위치 + x축으로 오브젝트 가로 길이 * 5만큼 이동 
            Vector3 collidingObjPos = collision.transform.position;

            collidingObjPos.x = collidingObjPos.x + (collidingObjWidth * 14f);
            collision.transform.position = collidingObjPos;
            return;
        }

        if (collision.gameObject.CompareTag("spike"))
        {
            Vector3 collidingObjPos = collision.transform.position;
            Vector3 child1LocalPosition = collision.transform.GetChild(0).localPosition;
            Vector3 child2LocalPosition = collision.transform.GetChild(1).localPosition;
            //Debug.Log($"child1 = {child1LocalPosition}");
            //Debug.Log($"child2 = {child2LocalPosition}");
            child1LocalPosition.x = 0;
            child2LocalPosition.x = 0;

            collidingObjPos.x = collidingObjPos.x + 15f;
            collision.transform.position = collidingObjPos;
            collision.transform.GetChild(0).localPosition = child1LocalPosition;
            collision.transform.GetChild(1).localPosition = child2LocalPosition;
            //Debug.Log("변경후");
            //Debug.Log($"child1 = {child1LocalPosition}");
            //Debug.Log($"child2 = {child2LocalPosition}");

            // 장애물과 부딪히면 장애물을 현재 위치의 *5로 이동하고, 장애물 사이 폭도 변경
            //GameObject parentObj = collision.transform.parent.gameObject;
            //obstacleManager.SetObstaclePosition(parentObj, collidingObjWidth);

            // 장애물 사이 폭 변경
            //obstacleManager.SetChildObjDistance(parentObj);

            return;
        }
    }
}
