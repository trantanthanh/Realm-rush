using System;
using TMPro;
using UnityEngine;

[DefaultExecutionOrder(10)]
[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.red;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color( 0f, 1f, 0f);
    [SerializeField] TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    //Tile tile;

    GridManager gridManager;
    void Awake()
    {
        //tile = GetComponentInParent<Tile>();
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;

        //call once for play mode
        DisplayCoordinates();
        UpdateObjectName();
    }

    private void ColorCordinates()
    {
        //label.color = tile.IsPlaceable ? defaultColor : blockedColor;
        if (gridManager == null) { return; }
        Node node = gridManager.Grid.ContainsKey(coordinates) ? gridManager.Grid[coordinates] : null;
        if (node == null) return;
        if (!node.isWalkable)
        {
            label.color = blockedColor;
        }
        else if (node.isPath)
        {
            label.color = pathColor;
        }
        else if (node.isExplored)
        {
            label.color = exploredColor;
        }
        else
        {
            label.color = defaultColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            label.enabled = !false;
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
        if (label == null || gridManager == null) return;
        //coordinates.x = Mathf.RoundToInt(transform.position.x / 10);
        //coordinates.y = Mathf.RoundToInt(transform.position.z / 10);
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);
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
