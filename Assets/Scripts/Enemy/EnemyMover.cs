using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    //[SerializeField] List<Tile> path = new List<Tile>();
    [SerializeField][Range(0f, 5f)] float speed = 1.0f;

    List<Node> path = new List<Node>();
    Enemy enemy;

    GridManager gridManager;
    Pathfinder pathfinder;

    // Start is called before the first frame update
    void Awake()
    {
        enemy = FindObjectOfType<Enemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void OnEnable()
    {
        RecalculatePath();
        //FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    //void FindPath()
    void RecalculatePath()
    {
        path.Clear();
        path = pathfinder.GetNewPath();
    }

    void ReturnToStart()
    {
        transform.position = gridManager.GetPositionFromCoordiates(gridManager.StartCoordinates);
    }

    IEnumerator FollowPath()
    {
        for (int i = 0; i < path.Count;++i)
        {
            float travelPercent = 0f;
            Vector3 startPosition = transform.position;
            Vector3 endPostion = gridManager.GetPositionFromCoordiates(path[i].coordinates);
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
