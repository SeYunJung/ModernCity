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
            // ground 생성
            GameObject ground = Instantiate(groundPrefab, this.transform);

            // 위치 지정
            // (0,0,0)부터 시작해서 x축으로 1씩 
            ground.transform.position = _prePosition + Vector3.right;
            _prePosition = ground.transform.position;
        }
    }
}
