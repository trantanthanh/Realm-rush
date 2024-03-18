using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Node startNode;
    Node destinateNode;
    Node currentSearchNode;

    Queue<Node> frontier = new Queue<Node>();
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    //Vector2Int[] direnctions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    //Vector2Int[] direnctions = { Vector2Int.up, Vector2Int.left, Vector2Int.right, Vector2Int.down };
    Vector2Int[] direnctions = { Vector2Int.down, Vector2Int.right, Vector2Int.up, Vector2Int.left };
    GridManager gridManager;

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null)
        {
            grid = gridManager.Grid;
        }

        startNode = grid[gridManager.StartCoordinates];
        destinateNode = grid[gridManager.DestinationCoordinates];
    }

    void Start()
    {
        GetNewPath(gridManager.StartCoordinates);
    }

    public List<Node> GetNewPath(Vector2Int coordinates)
    {
        gridManager.ResetNode();
        BreadthFirstSearch(coordinates);
        return BuildPath();
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
            }
        }

        foreach (Node neighbor in neighbors)
        {
            if (!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable && !neighbor.isExplored)
            {
                neighbor.isConnectedTo = currentSearchNode;
                reached.Add(neighbor.coordinates, neighbor);
                frontier.Enqueue(neighbor);
            }
        }
    }

    void BreadthFirstSearch(Vector2Int coordinates)
    {
        frontier.Clear();
        reached.Clear();

        bool isRunning = true;

        frontier.Enqueue(grid[coordinates]);

        while (frontier.Count > 0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored = true;
            ExplorerNeighbors();
            if (currentSearchNode.coordinates == gridManager.DestinationCoordinates)
            {
                isRunning = false;
            }
        }
    }

    List<Node> BuildPath()
    {
        List<Node> path = new List<Node> ();

        Node currentNode = destinateNode;
        currentNode.isPath = true;
        path.Add(currentNode);

        while (currentNode.isConnectedTo != null)
        {
            currentNode = currentNode.isConnectedTo;
            currentNode.isPath = true;
            path.Add(currentNode);
        }

        path.Reverse();
        return path;
    }

    public bool WillBlockPath(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            bool previousState = grid[coordinates].isWalkable;

            grid[coordinates].isWalkable = false;
            List<Node> newPath = GetNewPath(gridManager.StartCoordinates);
            grid[coordinates].isWalkable = previousState;


            if (newPath.Count < 2)
            {
                GetNewPath(gridManager.StartCoordinates);
                return true;
            }
        }
        return false;
    }

    public void NotifyReceivers()
    {
        BroadcastMessage("RecalculatePath", false, SendMessageOptions.DontRequireReceiver);
    }
}
