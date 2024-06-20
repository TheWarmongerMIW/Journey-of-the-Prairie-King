using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectible 
{
    public static event Action OnCollected;
    public void Collect()
    {
        Debug.Log("Collected");
        Destroy(gameObject);    
        OnCollected?.Invoke();
    }
}
