using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unity.VisualScripting;

public class HealthController : MonoBehaviour
{
    public float Health;
    public Gun gun;
    public UnityEvent OnDied;

    private void Start()
    {
        gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
    }

    public void TakeDamage()
    {
        if (Health == 0)
        {
            return;
        }
        Health -= gun.Damage;
        if (Health <= 0)
        {
            Health = 0;
            OnDied.Invoke();
        }
    }
    public void TakeNuke()
    {
        Health -= 10;
        OnDied.Invoke();
    }
}
