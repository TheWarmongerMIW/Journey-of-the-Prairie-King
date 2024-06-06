using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLoot : MonoBehaviour
{
    public void Destroyloot(float delay)
    {
       Destroy(gameObject, delay); 
    }
}
