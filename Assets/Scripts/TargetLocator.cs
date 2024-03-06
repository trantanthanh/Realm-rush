using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Enemy target;
    // Start is called before the first frame update
    void Start()
    {
        //target = FindObjectOfType<EnemyMover>();
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        target = null;
        if (enemies.Length > 0)
        {
            Array.Sort(enemies, CompareDistance);
            target = enemies[0];
        }
    }

    private int CompareDistance(Enemy a, Enemy b)
    {
        float distanceToA = Vector3.Distance(transform.position, a.transform.position);
        float distanceToB = Vector3.Distance(transform.position, b.transform.position);

        return distanceToA.CompareTo(distanceToB);
    }

    private void AimWeapon()
    {
        if (target != null && weapon != null)
        {
            weapon.LookAt(target.transform);
        }
    }
}
