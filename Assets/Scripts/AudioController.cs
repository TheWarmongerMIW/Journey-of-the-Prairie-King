using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource Overworld;
    public AudioSource PU;
    public AudioSource Gunload;
    public AudioSource Tombstone;
    public AudioSource Nuke;
    public Instruction instruction;
    public bool IsPlaying = false;
    public bool IsTombstonePlaying = false;   
    // Start is called before the first frame update
    void Start()
    {
        instruction = GameObject.Find("Instruction").GetComponent<Instruction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (instruction == null && IsPlaying == false && IsTombstonePlaying == false)
        {
            IsPlaying = true;   
            Overworld.Play();
        }
    }
    public void OnTombstone()
    {
        Overworld.Stop();
        IsPlaying = false;
        Tombstone.Play();
    }
}
