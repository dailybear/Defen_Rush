using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways] // 편집모드와 플레이모드 모두에서 실행 / 실수로 수정하는 일이 없도록
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    // 색을 바꾸기 위한 변수
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;


    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false; // 좌표 표시 기본으로 꺼진 상태
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying) // 애플리케이션이 재생되고 있지 않을 때
        {
            // do something 코드 실행(편집모드에서만 실행)
            DisplayCoordinates();
            UpdateObjectName();
            label.enabled = true;
        }

        //SetLabelColor();
        ToggleLabels();
    }

    void SetLabelColor()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    void ToggleLabels() // 좌표 켜고 끄기
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }


    void DisplayCoordinates() // 타일 위에 좌표 표시
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coordinates.x + ", " + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
