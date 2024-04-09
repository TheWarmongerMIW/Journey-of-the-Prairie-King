using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Zombie : MonoBehaviour
{
    public Health Health;  

    void Start()
    {
        Health = GetComponent<Health>();
        Health.MaxHealth = 1;
        GetComponent<AIDestinationSetter>().target = FindAnyObjectByType<PlayerMovement>().transform; 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Damage Taken");
            Health.TakeDamage();
            if (Health.MaxHealth <= 0) Destroy(gameObject);
        }
    }
}
