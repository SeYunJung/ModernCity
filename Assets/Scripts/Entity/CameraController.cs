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
        // ī�޶� ���� ��ġ 
        Vector3 desiredPosition = player.position + distance;
        desiredPosition.z = transform.position.z; // z���� -10���� ���� => 2Dī�޶�� z���� 0���� �۾ƾ� ������Ʈ�� ����. 

        // ī�޶� ��ġ ����
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounsds.x, maxBounsds.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounsds.y, maxBounsds.y);

        // ī�޶� �̵� 
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * cameraSpeed);   
        // ī�޶� ��ǥ�������� �� �����Ӹ��� cameraSpeed * Time.DeltaTime��ŭ �ε巴�� �̵� 
    }
}
