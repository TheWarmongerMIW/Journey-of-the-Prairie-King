using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject lootprefab;
    public List<Loot> lootlist = new List<Loot>();
    public InventoryManager inventory;

    private void Start()
    {
        inventory = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();    
    }

    Loot GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootlist)
        {
            if (randomNumber <= item.dropchance) possibleItems.Add(item);
        }
        if (possibleItems.Count > 0)
        {
            Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        Debug.Log("No loot dropped");
        return null;
    }
    public void SpawnLoot(Vector3 spawnPos)
    {
        Loot droppedItem = GetDroppedItem();
        if (droppedItem != null)
        {
            GameObject lootgameobject = Instantiate(lootprefab, spawnPos, Quaternion.identity);
            var lootclone = lootgameobject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootsprite;
            if (droppedItem.lootname is "Coin 1") lootgameobject.tag = "Coin1";
            if (droppedItem.lootname is "Coin 5") lootgameobject.tag = "Coin5";
            if (droppedItem.lootname is "Wheel") lootgameobject.tag = "Wheel";
            if (droppedItem.lootname is "Bandolier") lootgameobject.tag = "Bandolier";
            if (droppedItem.lootname is "1-Up") lootgameobject.tag = "1-Up";
            if (droppedItem.lootname is "Badge") lootgameobject.tag = "Badge";
            if (droppedItem.lootname is "Coffee") lootgameobject.tag = "Coffee";
            if (droppedItem.lootname is "Nuke") lootgameobject.tag = "Nuke";
            if (droppedItem.lootname is "Shotgun") lootgameobject.tag = "Shotgun";
            if (droppedItem.lootname is "Smoke bomb") lootgameobject.tag = "Smoke bomb";
            if (droppedItem.lootname is "Tombstone") lootgameobject.tag = "Tombstone";
        }
    }
}
                                                                  