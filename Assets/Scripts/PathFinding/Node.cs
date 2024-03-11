using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Node
{
    public Vector2Int coordinates;
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;

    public Node isConnectedTo;

    //constructor
    public Node(Vector2Int coordinates, bool isWalkable)
    { 
        this.coordinates = coordinates;
        this.isWalkable = isWalkable;
    }
}
