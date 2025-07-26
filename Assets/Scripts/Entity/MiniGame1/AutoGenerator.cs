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
            // �̵���Ű��. 
            // ������ġ + x������ ������Ʈ ���� ���� * 5��ŭ �̵� 
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
            //Debug.Log("������");
            //Debug.Log($"child1 = {child1LocalPosition}");
            //Debug.Log($"child2 = {child2LocalPosition}");

            // ��ֹ��� �ε����� ��ֹ��� ���� ��ġ�� *5�� �̵��ϰ�, ��ֹ� ���� ���� ����
            //GameObject parentObj = collision.transform.parent.gameObject;
            //obstacleManager.SetObstaclePosition(parentObj, collidingObjWidth);

            // ��ֹ� ���� �� ����
            //obstacleManager.SetChildObjDistance(parentObj);

            return;
        }
    }
}
