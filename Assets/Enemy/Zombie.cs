using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Zombie : MonoBehaviour
{
    public HealthController healthController;

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
            }
        }
    }
}
