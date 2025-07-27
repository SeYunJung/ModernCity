using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    public GameObject spikePrefab;

    private Vector3 _prePosition;

    private float[] yScaleArray = { 1f, 1.25f, 1.35f };

    private void Start()
    {
        for(int i = 0; i < 15; i++)
        {
            // spike 생성 
            GameObject spike = Instantiate(spikePrefab, this.transform);

            // 위치 지정
            // (0, 0, 0)부터 시작해서 x축으로 3씩 
            spike.transform.position = _prePosition + new Vector3(3, 0, 0);
            _prePosition = spike.transform.position;

            // 길이는 랜덤 
            // 1 ~ 1.35까지 
            //float number = Random.Range(1.0f, 1.36f);
            float number = yScaleArray.OrderBy(yPos => Random.value).First(); // 랜덤으로 y축 크기 가져와서 
            spike.transform.GetChild(0).localScale = new Vector3(1, number, 1);
            spike.transform.GetChild(1).localScale = new Vector3(1, number, 1);
        }
    }
}
