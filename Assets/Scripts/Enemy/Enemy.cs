using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;

    Fund fund;
    // Start is called before the first frame update
    void Start()
    {
        fund = FindObjectOfType<Fund>();   
    }

    public void RewardGold()
    {
        fund.Deposit(goldReward);
    }

    public void StealGold()
    {
        fund.WithDaw(goldPenalty);
    }
}
