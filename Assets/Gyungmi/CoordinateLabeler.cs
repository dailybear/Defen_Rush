using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways] // �������� �÷��̸�� ��ο��� ���� / �Ǽ��� �����ϴ� ���� ������
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    // ���� �ٲٱ� ���� ����
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;


    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false; // ��ǥ ǥ�� �⺻���� ���� ����
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying) // ���ø����̼��� ����ǰ� ���� ���� ��
        {
            // do something �ڵ� ����(������忡���� ����)
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

    void ToggleLabels() // ��ǥ �Ѱ� ����
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }


    void DisplayCoordinates() // Ÿ�� ���� ��ǥ ǥ��
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
