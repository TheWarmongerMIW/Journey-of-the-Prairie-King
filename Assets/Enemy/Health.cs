using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHealth;
    private int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void TakeDamage() 
    { 
        MaxHealth = MaxHealth - 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
