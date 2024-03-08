using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fund : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    int currentBalance;
    [SerializeField] int maxFundHealth = 20;
    int currentFundHeath;
    public int CurrentBalance
    {
        get
        {
            return currentBalance;
        }
        set
        {
            currentBalance = value;
        }
    }

    public int CurrentFundHeath
    {
        get
        {
            return currentFundHeath;
        }
        set
        {
            currentFundHeath = value;
        }
    }

    void Awake()
    {
        currentBalance = startingBalance;
        currentFundHeath = maxFundHealth;
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

    public void DamageBank(int damage)
    {
        currentFundHeath -= damage;
        if (currentFundHeath <= 0)
        {
            currentFundHeath = 0;
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
