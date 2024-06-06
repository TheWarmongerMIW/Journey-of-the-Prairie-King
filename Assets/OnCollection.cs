using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollection: MonoBehaviour
{
    public UnityEvent OnCollected;
    public AudioSource Coin;
    public AudioSource PU;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Coin") Coin.Play();
        //if (collision.gameObject.tag == "Wheel" || collision.gameObject.tag == "Bandolier" || collision.gameObject.tag == "1-Up" || collision.gameObject.tag == "Badge" || collision.gameObject.tag == "Coffee" || collision.gameObject.tag == "Nuke" || collision.gameObject.tag == "Shotgun" || collision.gameObject.tag == "Smoke bomb" || collision.gameObject.tag == "Tombstone") PU.Play();
        if (collision.gameObject.tag == "Player") OnCollected.Invoke();
    }
}
