using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fund : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    public int currentBalance;
    public int CurrentBalance { 
        get
        {
            return currentBalance;
        }
        set
        {
            currentBalance = value;
        }
    }

    void Awake()
    {
        currentBalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        currentBalance += Math.Abs(amount);
    }

    public void WithDaw(int amount)
    {
        currentBalance -= Math.Abs(amount);
        if (currentBalance <= 0) currentBalance = 0;
    }
}
