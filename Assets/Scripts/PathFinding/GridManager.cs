using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridCoordinatesStart;
    [SerializeField] Vector2Int gridCoordinatesEnd;
    [Tooltip("World Grid Size should match with Unity UnityEditor.EditorSnapSettings.move.x")]
    [SerializeField] int unityGridSize = 10;
    public int UnityGridSize
    {
        get
        {
            return unityGridSize;
        }
    }

    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int destinationCoordinates;

    public Vector2Int StartCoordinates
    {
        get
        {
            return startCoordinates;
        }
    }
    public Vector2Int DestinationCoordinates
    {
        get
        {
            return destinationCoordinates;
        }
    }

    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid
    {
        get
        {
            return grid;
        }
        set
        {
            grid = value;
        }
    }


    void Awake()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        for (int x = gridCoordinatesStart.x; x <= gridCoordinatesEnd.x; ++x)
        {
            for (int y = gridCoordinatesStart.y; y <= gridCoordinatesEnd.y; ++y)
            {
                Vector2Int coordinates = new Vector2Int(x, y);

                grid.Add(coordinates, new Node(coordinates, true));
                //Debug.Log("grid[coordinates].coordinates = " + grid[coordinates].coordinates);
            }
        }
    }

    public void BlockNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            grid[coordinates].isWalkable = false;
        }
    }

    public void ResetNode()
    {
        foreach(KeyValuePair<Vector2Int, Node> entry in grid)
        {
            entry.Value.isConnectedTo = null;
            entry.Value.isExplored = false;
            entry.Value.isPath = false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(position.x / unityGridSize);
        coordinates.y = Mathf.RoundToInt(position.z / unityGridSize);
        return coordinates;
    }

    public Vector3 GetPositionFromCoordiates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3(coordinates.x * unityGridSize, 0, coordinates.y * unityGridSize);
        return position;
    }
}
