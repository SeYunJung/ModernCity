using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform playerTransform;

    private float distance; // ī�޶�� �÷��̾� ���� �Ÿ�

    private void Awake()
    {
        distance = transform.position.x - playerTransform.position.x;
    }

    private void Update()
    {
        // ī�޶��� ��ġ�� �÷��̾� ��ġ + distance ��ŭ���� ���� 
        
        // ī�޶��� y���� �������� �����鼭 �÷��̾ ���󰡾���. 
        Vector3 cameraPos = transform.position;
        cameraPos.x = playerTransform.position.x + distance;
        transform.position = cameraPos;
    }
}
