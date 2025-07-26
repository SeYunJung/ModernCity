using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform playerTransform;

    private float distance;

    private void Awake()
    {
        distance = transform.position.x - playerTransform.position.x;
        Debug.Log($"distance = {distance}");
    }

    void Update()
    {
        Vector3 cameraPos = transform.position;
        cameraPos.x = playerTransform.position.x + distance;
        transform.position = cameraPos;
    }
}
