using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectEnim : MonoBehaviour
{
    public bool Detected = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Detected = true;
    }
}
