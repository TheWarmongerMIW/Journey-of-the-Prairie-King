using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionDetect : MonoBehaviour
{
    public LootManager lootmanager;
    public LootSlot lootslot;
    public UsePU usepu;
    public AudioController audiocontroller;
    public GameObject loot;
    public AudioSource Coin;
    public AudioSource PU;
    void Start()
    {
        lootmanager = GameObject.Find("LootCanvas").GetComponent<LootManager>();
        lootslot = GameObject.Find("LootSlot").GetComponent<LootSlot>();
        usepu = GameObject.Find("Player").GetComponent<UsePU>();
        audiocontroller = GameObject.Find("Player").GetComponent<AudioController>();    
        loot = this.gameObject;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && this.gameObject.tag != "Coin1" && this.gameObject.tag != "Coin5" && this.gameObject.tag != "1-Up")
        {
            PU.Play();
            lootmanager.AddLoot(loot);
            if (lootmanager.FullBag == true)
            {
                PU.Stop();
                if (this.gameObject.tag == "Coffee")
                {
                    usepu.CollidedCoffee();
                    audiocontroller.PU.Play();
                }
                if (this.gameObject.tag == "Bandolier")
                {
                    usepu.CollidedBandolier();
                    audiocontroller.Gunload.Play();
                }
                if (this.gameObject.tag == "Nuke")
                {
                    usepu.CollidedNuke();
                }
                if (this.gameObject.tag == "Tombstone")
                {
                    usepu.CollidedTombstone();
                    audiocontroller.OnTombstone();
                }
                if (this.gameObject.tag == "Shotgun")
                {
                    usepu.CollidedShotgun();
                    audiocontroller.Gunload.Play();
                }
                if (this.gameObject.tag == "Badge")
                {
                    usepu.CollidedBadge();
                    audiocontroller.Gunload.Play();
                }
            }
        }
        if (this.gameObject.tag == "Coin1" || this.gameObject.tag == "Coin5")
        {
            Coin.Play();
            if (this.gameObject.tag == "Coin1") lootmanager.AddCoins(1);
            if (this.gameObject.tag == "Coin5") lootmanager.AddCoins(5);
        }
        if (this.gameObject.tag == "1-Up")
        {
            lootmanager.AddLives();
            PU.Play();
        }
    }
}
