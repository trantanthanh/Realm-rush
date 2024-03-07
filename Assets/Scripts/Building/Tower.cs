using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int price = 50;

    public bool CreateTower(Tower towerPrefab, Vector3 position)
    {
        Fund fund = FindObjectOfType<Fund>();
        if (fund.CurrentBalance >= price)
        {
            fund.WithDaw(price);
            Instantiate(towerPrefab, position, Quaternion.identity);
            return true;
        }
        return false;
    }
}
