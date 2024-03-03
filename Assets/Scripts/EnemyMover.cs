using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;
    // Start is called before the first frame update
    void Start()
    {
        //PrintWaypointsName();
    }

    private void PrintWaypointsName()
    {
        foreach (var waypoint in path)
        {
            Debug.Log(waypoint.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
