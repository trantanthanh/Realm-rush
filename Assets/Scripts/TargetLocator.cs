using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    EnemyMover target;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<EnemyMover>();
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon();
    }

    private void AimWeapon()
    {
        if (target != null && weapon != null)
        {
            weapon.LookAt(target.transform);
        }
    }
}
