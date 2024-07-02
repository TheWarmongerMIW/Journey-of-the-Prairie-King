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
    public DetectEnim detectenim;
    public PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {       
        TimeRemaining = MaxTime;   
        detectenim = GameObject.Find("GroundFloor").GetComponent<DetectEnim>(); 
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();  
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (detectenim.Detected == true && player.enabled == true)
        {
            StartTimer();   
        }
    }

    public void StartTimer()
    {
        TimeRemaining = TimeRemaining - Time.deltaTime;
        TimerBar.fillAmount = TimeRemaining / MaxTime;
    }
    public void OnDeath()
    {
        TimerBar.fillAmount = TimeRemaining / MaxTime; 
    }
}
