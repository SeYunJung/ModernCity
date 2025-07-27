using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform playerTransform;

    private float distance; // 카메라와 플레이어 사이 거리

    private void Awake()
    {
        distance = transform.position.x - playerTransform.position.x;
    }

    private void Update()
    {
        // 카메라의 위치를 플레이어 위치 + distance 만큼으로 고정 
        
        // 카메라의 y축은 움직이지 않으면서 플레이어를 따라가야함. 
        Vector3 cameraPos = transform.position;
        cameraPos.x = playerTransform.position.x + distance;
        transform.position = cameraPos;
    }
}
