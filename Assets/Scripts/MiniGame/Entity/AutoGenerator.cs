using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������Ʈ�� �ڵ� �����ǰ� ���ִ� ��ũ��Ʈ
// ������ ���� �ְ� �� ���� ������Ʈ�� ����� �� Ư�� ��ġ�� ������Ʈ�� �ű�� 
public class AutoGenerator : MonoBehaviour
{
    public Transform groundTransform;
    public float collidingObjectWidth = 1f;

    public Transform spikeTransform;

    private int _groundGap = 30; 
    private int _spikeGap = 45;

    // �� ������Ʈ�� Ʈ���� �ݶ��̴��� �ް�
    // Ʈ���� �ݸ��� �޼���� Ʈ���ŵ� ������Ʈ�� �ڷ� ������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ε��� ������Ʈ�� �ڷ� ������ 
        if (collision.CompareTag("ground"))
        {
            // ������ġ + 30��ŭ �̵�
            // 1 -> 11 
            Vector3 collidingObjectPosition = collision.transform.position;
            collidingObjectPosition.x = collidingObjectPosition.x + _groundGap;
            // 1 + 30 = 31
            // 2 + 30 = 32
            // 3 + 30 = 33
            collision.transform.position = collidingObjectPosition;
            return;
        }

        if (collision.CompareTag("spikes"))
        {
            // spike�� ���̸� �ٸ��� ��������. 
            Vector3 collidingObjectPosition = collision.transform.position;
            collidingObjectPosition.x = collidingObjectPosition.x + _spikeGap;
            collision.transform.position = collidingObjectPosition;

            //Vector3 child1LocalPosition = collision.gameObject.transform.GetChild(0).transform.localPosition;
            //Vector3 child2LocalPosition = collision.gameObject.transform.GetChild(1).transform.localPosition;
            //child1LocalPosition.x = 0;
            //child2LocalPosition.x = 0;
            //collision.transform.GetChild(0).transform.localPosition = child1LocalPosition;
            //collision.transform.GetChild(1).transform.localPosition = child2LocalPosition;


            //Vector3 parentPosition = collision.gameObject.transform.parent.position;
            //parentPosition.x = parentPosition.x + _groundGap;
            //collision.gameObject.transform.parent.position = parentPosition;
            return;
        }
    }
}
