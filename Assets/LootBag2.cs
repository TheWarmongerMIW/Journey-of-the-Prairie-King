using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LootBag2 : MonoBehaviour
{
    public GameObject[] LootPrefab;
    public List<GameObject> LootBag = new List<GameObject>();

    void Start()
    {
        int randomnumber = Random.Range(1, 101);
        LootBag = new List<GameObject>(LootPrefab); 
        foreach (GameObject item in LootBag)
        {
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
