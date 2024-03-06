using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float rangeAttack = 1f;
    float distanceToTarget = -1f;
    Enemy target = null;
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
        if (target != null && target.gameObject.activeInHierarchy)
        {
            distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (distanceToTarget < rangeAttack)
            {
                return;//continue attack old target in range.
            }
        }
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        target = null;
        if (enemies.Length > 0)
        {
            Array.Sort(enemies, CompareDistance);
            float distance = Vector3.Distance(transform.position, enemies[0].transform.position);
            if (distance <= rangeAttack)
            {
                distanceToTarget = distance;
                target = enemies[0];
            }
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
