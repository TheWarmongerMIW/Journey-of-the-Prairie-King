using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float Damage;

    private void OnCollisionStay2D(Collision2D collision)
    {
        UsePU usepu = GameObject.Find("Player").GetComponent<UsePU>();
        if (collision.gameObject.layer == 3 && usepu.IsUsingTombstone == false)
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.TakeDamage();
        }
    }

}
