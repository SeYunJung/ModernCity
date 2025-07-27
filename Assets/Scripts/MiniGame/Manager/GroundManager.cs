using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject groundPrefab;

    private Vector3 _prePosition;

    private void Start()
    {
        _prePosition = transform.position;

        for(int i = 0; i < 30; i++)
        {
            // ground ����
            GameObject ground = Instantiate(groundPrefab, this.transform);

            // ��ġ ����
            // (0,0,0)���� �����ؼ� x������ 1�� 
            ground.transform.position = _prePosition + Vector3.right;
            _prePosition = ground.transform.position;
        }
    }
}
