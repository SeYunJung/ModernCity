using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveManager : MonoBehaviour
{
    // �̱��� ���� => �ٸ� �������� ����ϱ� ���� �̱������� ���� 
    private static InteractiveManager _instance = null;
    public static InteractiveManager Instance
    {
        get
        {
            if (_instance == null)
            {
                return null;
            }
            return _instance;
        }
    }

    // ��ȣ�ۿ� ������ List<Rect>�� ��������. 
    // �ϴ� List<Rect> Ÿ�� ������ ������. 
    [SerializeField] private List<Rect> _interactiveAreas;
    // ��ȣ�ۿ� ������ ����Ƽ �����Ϳ����� �� �� �ְ� ����� ������. 
    // ����� ��Ÿ������ ���� �ʿ��ϴ� ����� ���� ��������. 
    [SerializeField] private Color gizmoColor = new Color(1, 0, 0, .3f);

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            Init();

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Init()
    {
        _interactiveAreas.Add(new Rect(4, 1, 2, 2));
    }

    public Rect GetMiniGameArea()
    {
        return _interactiveAreas[0];
    }

    // ����� �׷��ִ� �޼��� 
    private void OnDrawGizmosSelected()
    {
        // Gizmo = ������ ���� ������ 
        if (_interactiveAreas == null) return;

        Gizmos.color = gizmoColor;
        foreach (var area in _interactiveAreas)
        {
            Vector3 center = new Vector3(area.x + area.width / 2, area.y + area.height / 2);
            Vector3 size = new Vector3(area.width, area.height);

            Gizmos.DrawCube(center, size);
        }
    }
}
