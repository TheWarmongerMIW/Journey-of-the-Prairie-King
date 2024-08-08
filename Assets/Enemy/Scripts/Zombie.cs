using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public HealthController healthController;
    public AIPath aipath;
    public Seeker seeker;
    public AIDestinationSetter destinationsetter;
    public UsePU usepu;
    public AudioSource DeathSound1;
    public AudioSource DeathSound2;

    void Start()
    {
        GetComponent<AIDestinationSetter>().target = FindAnyObjectByType<PlayerMovement>().transform; 
        usepu = GameObject.Find("Player").GetComponent<UsePU>();    
        healthController = GetComponent<HealthController>();    
    }

    private void Update()
    {
        if (healthController.Health <= 0)
        {
            this.gameObject.tag = "DeadEnemy";
            aipath.enabled = false;
            seeker.enabled = false;
            destinationsetter.enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            healthController.TakeDamage();
            GetComponent<LootBag>().SpawnLoot(transform.position);
            if (Random.Range(1, 3) == 1) DeathSound1.Play(); else DeathSound2.Play();
        }
        if (collision.gameObject.tag == "Player" && usepu.IsUsingTombstone == true)
        {
            healthController.TakeDamage();
            if (Random.Range(1, 3) == 1) DeathSound1.Play(); else DeathSound2.Play();
        }
    }
    public void OnNuke()
    {
        healthController.TakeNuke();
        GetComponent<LootBag>().SpawnLoot(transform.position);
    }
}
