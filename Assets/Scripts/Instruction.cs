using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    public float timer = 0;
    private float destroytime = 5;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= destroytime) Destroy(gameObject);   
    }
}
