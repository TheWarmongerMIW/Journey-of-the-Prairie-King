using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public void DestroyEnemy(float delay)
    {
        Destroy(gameObject, delay);
    }

    public void DestroyEnemyOnCBDeath()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] deadenemies = GameObject.FindGameObjectsWithTag("DeadEnemy");

        foreach (GameObject zombie in zombies)
        {
            Destroy(zombie);    
        }
        
        foreach (GameObject deadenemy in deadenemies)
        {
            Destroy(deadenemy);    
        }
    }
}
