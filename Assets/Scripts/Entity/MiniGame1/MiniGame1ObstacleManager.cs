using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameObstacleManager1 : Singleton<MiniGameObstacleManager1>
{
    public int obstacleCount = 5;

    public GameObject obstacle;
    private Transform topTransform;
    private Transform bottomTransform;

    private float distance;

    private Vector3 prePosition;
    public float xPadding = 2f;

    // ó�� ������ �� �� �Ʒ�(top, bottom) ��ġ ���� ��, ��ֹ�(Obstacle) ��ġ
    void Start()
    {
        if (obstacle != null)
        {
            prePosition = new Vector3(4, 0, 0);
            for (int i = 0; i < obstacleCount; i++)
            {
                Instantiate(obstacle, transform);

                // top, bottom ���� �Ÿ� ����
                // ������ ��ֹ�(Obstacle)�� top, bottom ���� �Ÿ� ����
                distance = Random.Range(6, 10);

                bottomTransform = obstacle.transform.GetChild(0);
                topTransform = obstacle.transform.GetChild(1);

                bottomTransform.localPosition = new Vector3(0, distance / 2, 0);
                topTransform.localPosition = new Vector3(0, -(distance / 2), 0);

                // ��ֹ�(Obstacle)�� ��ġ ���� 
                // ���� ��ġ + ���� ���� 
                // ��ġ ��ġ
                if (i == 0)
                    obstacle.transform.position = prePosition;
                else
                    obstacle.transform.position = prePosition + new Vector3(xPadding + 2, 0, 0);

                // ���� ��ġ ����
                prePosition = obstacle.transform.position;
            }
        }
    }

    public void SetObstaclePosition(GameObject obstacle, float collidingObjWidth)
    {
        Transform collidingObjTransform = obstacle.GetComponent<Transform>(); // Transform�� �����ͼ� 
        Vector3 collidingObjPos = collidingObjTransform.position;


        ////Vector3 collidingObjPos = collision.transform.position;
        //Vector3 child1LocalPosition = obstacle.transform.GetChild(0).position;
        //Vector3 child2LocalPosition = obstacle.transform.GetChild(1).position;
        //child1LocalPosition.x = 0;
        //child2LocalPosition.x = 0;

        ////collidingObjPos.x = collidingObjPos.x + 15f;
        ////collision.transform.position = collidingObjPos;
        //obstacle.transform.GetChild(0).localPosition = child1LocalPosition;
        //obstacle.transform.GetChild(1).localPosition = child2LocalPosition;


        //collidingObjPos.x += (collidingObjWidth * 5f);
        collidingObjPos.x += (5);
        collidingObjTransform.position = collidingObjPos; // ��ġ �̵�
    }

    public void SetChildObjDistance(GameObject obstacle)
    {
        distance = Random.Range(4, 9);

        topTransform = obstacle.transform.GetChild(0);
        bottomTransform = obstacle.transform.GetChild(1);

        topTransform.localPosition = new Vector3(0, distance / 2, 0);
        bottomTransform.localPosition = new Vector3(0, -(distance / 2), 0);

        obstacle.transform.position = prePosition + new Vector3(xPadding, 0, 0);

        prePosition = obstacle.transform.position;
    }
}
