using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegSFX : MonoBehaviour
{
    public AudioSource WalkCB;
    private KeyCode UpKey = KeyCode.W, DownKey = KeyCode.S, LeftKey = KeyCode.A, RightKey = KeyCode.D;
    public void PlaySound()
    {
        if (Input.GetKey(UpKey) || Input.GetKey(LeftKey) || Input.GetKey(DownKey) || Input.GetKey(RightKey)) WalkCB.Play();
        else WalkCB.Stop(); 
    }
}
