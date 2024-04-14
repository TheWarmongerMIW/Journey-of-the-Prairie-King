using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LegSpawner : MonoBehaviour
{
    public GameObject Leg;
    public PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>(); 
        Instantiate(Leg, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
