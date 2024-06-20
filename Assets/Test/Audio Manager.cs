using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource audiosource; 
    [SerializeField] private AudioClip coinsound, pickupsound;

    private void OnEnable()
    {
        Coin.OnCollected += PlayCoinSound;
    }

    private void OnDisable()
    {
        Coin.OnCollected -= PlayCoinSound;
    }
    private void Awake()
    {
        
    }
    public void PlayCoinSound()
    {
        audiosource.PlayOneShot(coinsound);        
    }
}
