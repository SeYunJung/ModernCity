using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveManager : Singleton<InteractiveManager>
{
    // 상호작용 영역을 List<Rect>에 저장하자. 
    // 일단 List<Rect> 타입 변수를 만들자. 
    [SerializeField] private List<Rect> _interactiveAreas;
    // 상호작용 영역을 유니티 에디터에서는 볼 수 있게 기즈모를 만든자. 
    // 기즈모를 나타내려면 색이 필요하니 기즈모 색을 설정하자. 
    [SerializeField] private Color gizmoColor = new Color(1, 0, 0, .3f);

    private void Awake()
    {
        _interactiveAreas.Add(new Rect(4, 1, 2, 2));
    }

    public Rect GetMiniGameArea()
    {
        return _interactiveAreas[0];
    }

    // 기즈모 그려주는 메서드 
    private void OnDrawGizmosSelected()
    {
        // Gizmo = 개발을 위한 아이콘 
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
