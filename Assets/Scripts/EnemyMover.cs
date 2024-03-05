using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void FindPath()
    {
        path.Clear();
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");
        foreach (GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            float travelPercent = 0f;
            Vector3 startPosition = transform.position;
            Vector3 endPostion = waypoint.transform.position;
            transform.LookAt(endPostion);
            while (travelPercent < 1.0f)
            {
                travelPercent += speed * Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPostion, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        Destroy(gameObject);//destroy at the end position
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
