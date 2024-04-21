using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Zombie : MonoBehaviour
{
    public Health Health;  
    public 

    void Start()
    {
        GetComponent<AIDestinationSetter>().target = FindAnyObjectByType<PlayerMovement>().transform; 
        Health = GetComponent<Health>();
        Health.MaxHealth = 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Health.TakeDamage();
            if (Health.MaxHealth <= 0) Destroy(gameObject);
        }
    }
}
