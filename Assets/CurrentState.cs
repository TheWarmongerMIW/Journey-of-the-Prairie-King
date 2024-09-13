using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentState : MonoBehaviour
{
    [SerializeField] private int Lives;
    [SerializeField] private int Coins;
    [SerializeField] private float Time;
    [SerializeField] private LootManager lootmanager;
    [SerializeField] private Timercontroller timer;
    [SerializeField] private TextMeshProUGUI coinsCount;

    
    void Start()
    {
       
    }
    void Update()
    {
        this.Lives = lootmanager.NumberofLives;
        this.Time = timer.TimeRemaining;

        Coin();
    }

    public void Coin()
    {
        PlayerPrefs.SetInt("CurrentState", lootmanager.NumberofCoins);
        Debug.Log(lootmanager.NumberofCoins);
        coinsCount.text = lootmanager.NumberofCoins.ToString();
    }
}
