using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Tile> path = new List<Tile>();
    [SerializeField][Range(0f, 5f)] float speed = 1.0f;
    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<Enemy>();
    }

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void FindPath()
    {
        path.Clear();
        //GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");
        //foreach (GameObject tile in waypoints)
        //{
        //    path.Add(tile.GetComponent<Tile>());
        //}
        GameObject pathParent = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in pathParent.transform)
        {
            Tile tile = child.GetComponent<Tile>();
            if (tile != null)
            {
                path.Add(tile);
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach (Tile tile in path)
        {
            float travelPercent = 0f;
            Vector3 startPosition = transform.position;
            Vector3 endPostion = tile.transform.position;
            transform.LookAt(endPostion);
            while (travelPercent < 1.0f)
            {
                travelPercent += speed * Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPostion, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishMove();
    }

    void FinishMove()
    {
        //Destroy(gameObject);//destroy at the end position
        gameObject.SetActive(false);
        enemy.DamgeToBank();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
