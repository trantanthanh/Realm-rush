using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    Vector2Int[] direnctions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid;

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null)
        {
            grid = gridManager.Grid;
        }
    }

    void Start()
    {
        ExplorerNeighbors();
    }

    private void ExplorerNeighbors()
    {
        List<Node> neighbors = new List<Node>();
        foreach (Vector2Int direction in direnctions)
        {
            Vector2Int neighborCoords = currentSearchNode.coordinates + direction;

            if (grid.ContainsKey(neighborCoords))
            {
                neighbors.Add(grid[neighborCoords]);

                //Todo : remove after tested
                grid[neighborCoords].isExplored = true;
                grid[neighborCoords].isPath = true;
            }
        }
    }
}
