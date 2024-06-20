using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Sprite sprite;
    public InventoryManager inventory;

    private void Start()
    {
        inventory = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inventory.AddItem(sprite);
        }
    }
}
