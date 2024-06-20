using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : MonoBehaviour
{
    public ItemSlot itemslot;
    public GameObject Inventory;
    public int NumberofCoins;
    public int NumberofLife;
    public UnityEvent<InventoryManager> CollectCoins;
    public UnityEvent<InventoryManager> CollectLives;

    private void Start()
    {
        NumberofLife = 3;
    }
    public void AddItem(Sprite sprite)
    {
        itemslot.AddItem(sprite);   
    }
    public void AddCoins(int amount)
    {
        NumberofCoins += amount;
        CollectCoins.Invoke(this);
    }
    public void AddLife()
    {
        NumberofLife++; 
        CollectLives.Invoke(this);  
    }
}
