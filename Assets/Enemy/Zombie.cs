using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Zombie : MonoBehaviour
{
    public HealthController healthController;
    public AudioSource DeathSound1;
    public AudioSource DeathSound2;

    void Start()
    {
        GetComponent<AIDestinationSetter>().target = FindAnyObjectByType<PlayerMovement>().transform;    
        healthController = GetComponent<HealthController>();    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            {
                healthController.TakeDamage();
                GetComponent<LootBag>().SpawnLoot(transform.position);
                if (Random.Range(1, 3) == 1) DeathSound1.Play(); else DeathSound2.Play();
            }
        }
    }
}
