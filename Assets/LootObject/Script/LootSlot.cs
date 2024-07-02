using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LootSlot : MonoBehaviour
{
    public Sprite lootsprite;
    public LootManager lootmanager; 
    public string loottag;
    [SerializeField] private Image lootimage;

    private void Start()
    {
        lootmanager = GameObject.Find("LootCanvas").GetComponent<LootManager>();    
    }
    public void AddLoot(GameObject loot)
    {
        this.lootsprite = loot.GetComponent<SpriteRenderer>().sprite;
        this.loottag = loot.tag;
        lootimage.sprite = loot.GetComponent<SpriteRenderer>().sprite;   
    }
    public void OnUsed()
    {
        lootmanager.FullBag = false;
        lootimage.sprite = null;
        this.lootsprite = null;
        this.loottag = null;
    }
}
