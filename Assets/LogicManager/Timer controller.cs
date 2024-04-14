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
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();  
        TimeRemaining = MaxTime;
    }

    // Update is called once per frame
    private void Update()
    {
        if (TimeRemaining > 0 && spawner.ZombiePrefab != null)
        {
            TimeRemaining = TimeRemaining - Time.deltaTime;
            TimerBar.fillAmount = TimeRemaining / MaxTime;
        }
    }
}
