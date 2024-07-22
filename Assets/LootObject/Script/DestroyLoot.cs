using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DestroyLoot : MonoBehaviour
{
    public void Destroyloot(float delay)
    {
        Destroy(gameObject, delay);
    }

    public void DestroyLootOnCBDeath()
    {
        GameObject loots = GameObject.Find("LootPrefab");
    }
}
