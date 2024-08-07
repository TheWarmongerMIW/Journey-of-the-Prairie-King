using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentState : MonoBehaviour
{
    [SerializeField] public int Lives;
    [SerializeField] public int Coins;
    [SerializeField] public float Time;

    private LootManager lootmanager;
    private Timercontroller timer;

    /*public CurrentState(int lives, int coins, float time)
    {
        this.Lives = lives; 
        this.Coins = coins; 
        this.Time = time; 
    }*/ 
    
    void Start()
    {
        lootmanager = GameObject.Find("LootCanvas").GetComponent<LootManager>();    
        timer = GameObject.Find("Timer").GetComponent<Timercontroller>();   
    }

    // Update is called once per frame
    void Update()
    {
        this.Lives = lootmanager.NumberofLives;
        this.Coins = lootmanager.NumberofCoins; 
        this.Time = timer.TimeRemaining;
    }
}
