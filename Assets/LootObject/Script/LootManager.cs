using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LootManager : MonoBehaviour
{
    public LootSlot lootslot;
    public int NumberofCoins;
    public int NumberofLives;
    public bool FullBag = false;    
    public UnityEvent<LootManager> CollectCoins;
    public UnityEvent<LootManager> CollectLives;
    public UnityEvent<LootManager> LoseLife;

    private void Start()
    {
        NumberofLives = 3;
    }
    public void AddLoot(GameObject loot)
    {
        if (lootslot.lootsprite == null) lootslot.AddLoot(loot);
        else
        {
            FullBag = true;
            Debug.Log("Collided with " + loot.tag);
        }
    }
    public void AddCoins(int amount)
    {
        NumberofCoins += amount;
        CollectCoins.Invoke(this);
    }
    public void AddLives()
    {
        NumberofLives++;
        CollectLives.Invoke(this);
    }
    public void LoseLives()
    {
        NumberofLives--;
        LoseLife.Invoke(this); 
    }
}
