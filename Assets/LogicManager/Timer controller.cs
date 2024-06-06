using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Timercontroller : MonoBehaviour
{
    public Image TimerBar;
    public float TimeRemaining;
    public float MaxTime;
    public Spawner spawner;
    public PlayerMovement playerMovement;   
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();  
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent <PlayerMovement>();    
        TimeRemaining = MaxTime;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (playerMovement.enabled == true && TimeRemaining > 0 && spawner.ZombiePrefab != null)
        {
            TimeRemaining = TimeRemaining - Time.deltaTime;
            TimerBar.fillAmount = TimeRemaining / MaxTime;
        }
    }
    public void OnDeath()
    {
        TimerBar.fillAmount = TimeRemaining /MaxTime;
    }
}
