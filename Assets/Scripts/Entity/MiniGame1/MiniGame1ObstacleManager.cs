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

    // 처음 시작할 때 위 아래(top, bottom) 위치 조정 후, 장애물(Obstacle) 배치
    void Start()
    {
        if (obstacle != null)
        {
            prePosition = new Vector3(4, 0, 0);
            for (int i = 0; i < obstacleCount; i++)
            {
                Instantiate(obstacle, transform);

                // top, bottom 사이 거리 지정
                // 생성된 장애물(Obstacle)의 top, bottom 사이 거리 지정
                distance = Random.Range(6, 10);

                bottomTransform = obstacle.transform.GetChild(0);
                topTransform = obstacle.transform.GetChild(1);

                bottomTransform.localPosition = new Vector3(0, distance / 2, 0);
                topTransform.localPosition = new Vector3(0, -(distance / 2), 0);

                // 장애물(Obstacle)의 위치 지정 
                // 이전 위치 + 일정 간격 
                // 위치 배치
                if (i == 0)
                    obstacle.transform.position = prePosition;
                else
                    obstacle.transform.position = prePosition + new Vector3(xPadding + 2, 0, 0);

                // 이전 위치 저장
                prePosition = obstacle.transform.position;
            }
        }
    }

    public void SetObstaclePosition(GameObject obstacle, float collidingObjWidth)
    {
        Transform collidingObjTransform = obstacle.GetComponent<Transform>(); // Transform을 가져와서 
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
        collidingObjTransform.position = collidingObjPos; // 위치 이동
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
