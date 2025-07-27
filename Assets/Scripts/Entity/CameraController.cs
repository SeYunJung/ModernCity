using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float cameraSpeed;
    public Vector2 minBounsds;
    public Vector2 maxBounsds;

    private Vector3 distance;

    private void Start()
    {
        distance = transform.position - player.position;
    }

    private void LateUpdate()
    {
        // 카메라가 따라갈 위치 
        Vector3 desiredPosition = player.position + distance;
        desiredPosition.z = transform.position.z; // z축은 -10으로 유지 => 2D카메라는 z축이 0보다 작아야 오브젝트가 보임. 

        // 카메라 위치 제한
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounsds.x, maxBounsds.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounsds.y, maxBounsds.y);

        // 카메라 이동 
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * cameraSpeed);   
        // 카메라를 목표지점까지 매 프레임마다 cameraSpeed * Time.DeltaTime만큼 부드럽게 이동 
    }
}
