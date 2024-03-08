using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fund : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    int currentBalance;
    [SerializeField] int maxFundHealth = 20;
    int currentFundHeath;

    [SerializeField] TextMeshProUGUI textGold;
    [SerializeField] TextMeshProUGUI textHealth;
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
        UpdateUIText();
    }

    public void Deposit(int amount)
    {
        currentBalance += Math.Abs(amount);
        UpdateUIText();
    }

    public void WithDaw(int amount)
    {
        currentBalance -= Math.Abs(amount);
        if (currentBalance <= 0) currentBalance = 0;
        UpdateUIText();
    }

    public void DamageBank(int damage)
    {
        currentFundHeath -= damage;
        if (currentFundHeath <= 0)
        {
            currentFundHeath = 0;
            ReloadScene();
        }
        UpdateUIText();
    }

    void UpdateUIText()
    {
        textGold.text = $"Gold : {currentBalance}";
        textHealth.text = $"Health : {currentFundHeath}";
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
