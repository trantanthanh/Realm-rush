using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float timeSpawnInterval = 1f;

    //Object pool
    [SerializeField] int poolSize = 5;
    GameObject[] pool;
    // Start is called before the first frame update
    void Start()
    {
        PopulatePool();
        StartCoroutine(SpawnEnemy());
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; ++i)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    GameObject GetActiveEnemyInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (!pool[i].activeSelf)
            {
                return pool[i];
            }
        }

        return null;
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject enemy = GetActiveEnemyInPool();
            if (enemy != null) enemy.SetActive(true);
            //Instantiate(enemyPrefab, transform);
            yield return new WaitForSeconds(timeSpawnInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
