using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionDetect : MonoBehaviour
{
    public LootManager lootmanager;
    public LootSlot lootslot;
    public UsePU usepu;
    public GameObject loot;
    public AudioController audiocontroller;
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
            if (this.gameObject.tag == "Coffee" && lootmanager.FullBag == true)
            {
                usepu.CollidedCoffee();
                audiocontroller.PU.Play();
                PU.Stop();
            }
            if (this.gameObject.tag == "Bandolier" && lootmanager.FullBag == true)
            {
                usepu.CollidedBandolier();
                audiocontroller.Gunload.Play();
                PU.Stop();
            }
            if (this.gameObject.tag == "Nuke" && lootmanager.FullBag == true)
            {
                usepu.CollidedNuke();
                PU.Stop();
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
