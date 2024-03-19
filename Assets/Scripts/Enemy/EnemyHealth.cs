using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof (Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;
    int startHitPoint = 1;
    int currentHitPoints = 0;
    int hitPointStrongOvertime = 0;
    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        currentHitPoints = startHitPoint + hitPointStrongOvertime;
        if (currentHitPoints > maxHitPoint)
        {
            currentHitPoints = maxHitPoint;
        }
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
        ++hitPointStrongOvertime;
        gameObject.SetActive(false);
        enemy.RewardGold();
    }
}
