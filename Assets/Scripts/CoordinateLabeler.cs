using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();//call once for play mode
        UpdateObjectName();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
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


}
