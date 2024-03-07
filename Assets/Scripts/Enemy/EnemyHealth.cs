using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;
    int currentHitPoints = 0;
    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        currentHitPoints = maxHitPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        --currentHitPoints;
        if (currentHitPoints <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
        enemy.RewardGold();
    }
}
