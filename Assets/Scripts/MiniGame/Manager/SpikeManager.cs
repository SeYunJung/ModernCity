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
            // spike ���� 
            GameObject spike = Instantiate(spikePrefab, this.transform);

            // ��ġ ����
            // (0, 0, 0)���� �����ؼ� x������ 3�� 
            spike.transform.position = _prePosition + new Vector3(3, 0, 0);
            _prePosition = spike.transform.position;

            // ���̴� ���� 
            // 1 ~ 1.35���� 
            //float number = Random.Range(1.0f, 1.36f);
            float number = yScaleArray.OrderBy(yPos => Random.value).First(); // �������� y�� ũ�� �����ͼ� 
            spike.transform.GetChild(0).localScale = new Vector3(1, number, 1);
            spike.transform.GetChild(1).localScale = new Vector3(1, number, 1);
        }
    }
}
