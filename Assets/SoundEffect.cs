using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource Overworld;
    public AudioSource DeathSound;
    // Start is called before the first frame update
    void Start()
    {
        Overworld.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeathSong()
    {
        Overworld.Stop();
        DeathSound.Play();      
    }
}
