using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Zombie;
    // Start is called before the first frame update
    private void Awake()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) Instantiate(Zombie, transform.position, transform.rotation);
    }
}
