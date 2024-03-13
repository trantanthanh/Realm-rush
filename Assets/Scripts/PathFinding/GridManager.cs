using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
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
        for (int x = 0; x < gridSize.x; ++x)
        {
            for (int y = 0; y < gridSize.y; ++y)
            {
                Vector2Int coordinates = new Vector2Int(x, y);

                grid.Add(coordinates, new Node(coordinates, true));
                //Debug.Log("grid[coordinates].coordinates = " + grid[coordinates].coordinates);
            }
        }
    }
}
