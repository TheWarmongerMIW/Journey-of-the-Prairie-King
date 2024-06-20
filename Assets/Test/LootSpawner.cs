using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    public GameObject Loot;
    public float timer;
    public float spawnrate;
    public Transform CoinSpawn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnrate) timer += Time.deltaTime;
        if (timer >= spawnrate)
        {
            timer = 0;  
            Instantiate(Loot, CoinSpawn.position, CoinSpawn.rotation); 
        } 
    }
}
