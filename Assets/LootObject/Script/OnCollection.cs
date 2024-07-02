using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollection: MonoBehaviour
{
    public UnityEvent OnCollect;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnCollect.Invoke();
        }
    }
}
