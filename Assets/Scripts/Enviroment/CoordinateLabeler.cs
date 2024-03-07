using System;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    [SerializeField] TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;
    void Awake()
    {
        waypoint = GetComponentInParent<Waypoint>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;

        //call once for play mode
        DisplayCoordinates();
        UpdateObjectName();
    }

    private void ColorCordinates()
    {
        label.color = waypoint.IsPlaceable ? defaultColor : blockedColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        ColorCordinates();
        CheckToggleLabels();
    }

    private void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

    private void DisplayCoordinates()
    {
        if (label == null) return;
        coordinates.x = Mathf.RoundToInt(transform.position.x / 10);
        coordinates.y = Mathf.RoundToInt(transform.position.z / 10);
        label.text = $"{coordinates.x}, {coordinates.y}";
    }

    void CheckToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.enabled;
        }
    }
}
