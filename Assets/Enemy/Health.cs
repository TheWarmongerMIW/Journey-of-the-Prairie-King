using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public LogicScript logic;
    public int MaxHealth;
    // Start is called before the first frame update
    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    public void TakeDamage() 
    { 
        MaxHealth = MaxHealth - logic.damage;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
