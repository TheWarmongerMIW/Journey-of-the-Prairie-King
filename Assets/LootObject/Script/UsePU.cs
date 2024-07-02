using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using Unity.VisualScripting;
using System;
using Pathfinding;
using System.Security.Cryptography;
public class UsePU : MonoBehaviour
{
    public Coroutine coffeecoroutine;
    public Coroutine bandoliercoroutine;
    public Coroutine tombstonecoroutine;
    public Coroutine nukecoroutine;
    public GameObject lightning;
    public GameObject TombstoneBackground;
    public GameObject TimerUI;
    public GameObject LootCanvas;
    public GameObject Leg;
    public Animator cbanimator;
    public AudioController audiocontroller;
    [SerializeField] private LootSlot lootslot;
    public bool IsUsingTombstone = false;
    [SerializeField] private bool IsUsingCoffee = false;
    [SerializeField] private bool IsUsingBandolier = false;

    void Start()
    {
        lootslot = GameObject.Find("LootSlot").GetComponent<LootSlot>();
        audiocontroller = GameObject.Find("Player").GetComponent<AudioController>();    
    }

    void Update()
    {
        if (lootslot.lootsprite != null)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (lootslot.loottag == "Coffee")
                {
                    if (coffeecoroutine != null)
                    {
                        StopCoroutine(coffeecoroutine);
                        StopUsingCoffee();
                    }
                    coffeecoroutine = StartCoroutine(UsingCoffeee());
                    audiocontroller.PU.Play();
                    lootslot.OnUsed();
                }
                if (lootslot.loottag == "Bandolier")
                {
                    if (bandoliercoroutine != null)
                    {
                        StopCoroutine(bandoliercoroutine);
                        StopUsingBandolier();
                    }
                    bandoliercoroutine = StartCoroutine(UsingBandolier());  
                    audiocontroller.Gunload.Play();
                    lootslot.OnUsed();
                }
                if (lootslot.loottag == "Nuke")
                {
                    if(nukecoroutine != null) StopCoroutine(nukecoroutine);             
                    nukecoroutine = StartCoroutine(UsingNuke());
                    lootslot.OnUsed();
                }
                else lootslot.OnUsed();    
            }
        }
    }
    //==========================CoffeePU==========================//
    private IEnumerator UsingCoffeee()
    {
        PlayerMovement player = GameObject.Find("Player").GetComponent< PlayerMovement>();  
        player.MoveSpeed += 2f;
        player.MoveSpeed2 += 2f;
        IsUsingCoffee = true;   
        yield return new WaitForSeconds(16f);
        player.MoveSpeed -= 2f;
        player.MoveSpeed2 -= 2f;     
        IsUsingCoffee = false;
    }
    public void StopUsingCoffee()
    {
        if (IsUsingCoffee)
        {
            PlayerMovement player = GameObject.Find("Player").GetComponent<PlayerMovement>();
            player.MoveSpeed -= 2f;
            player.MoveSpeed2 -= 2f; 
            IsUsingCoffee= false;   
        }
    }
    public void CollidedCoffee()
    {
        if (coffeecoroutine != null)
        {
            StopUsingCoffee();
            StopCoroutine(coffeecoroutine);
        }
        coffeecoroutine = StartCoroutine(UsingCoffeee());
    }
    //==========================CoffeePU==========================//
    //==========================BandolierPU==========================//
    private IEnumerator UsingBandolier()
    {
        Gun gun = GameObject.Find("Gun").GetComponent<Gun>();
        gun.FireRate = 0.065f;
        gun.Damage = 4;
        IsUsingBandolier = true;    
        yield return new WaitForSeconds(12);
        gun.FireRate = 0.35f;
        gun.Damage = 1;
        IsUsingBandolier = false;   
    }
    public void StopUsingBandolier()
    {
        if (IsUsingBandolier)
        {
            Gun gun = GameObject.Find("Gun").GetComponent<Gun>();
            gun.FireRate = 0.35f;
            gun.Damage = 1;
            IsUsingBandolier = false;   
        }
    }
    public void CollidedBandolier()
    {
        if (bandoliercoroutine != null)
        {
            StopUsingBandolier();
            StopCoroutine(bandoliercoroutine);
        }
        bandoliercoroutine = StartCoroutine(UsingBandolier());
    }
    //==========================BandolierPU==========================//
    
    //==========================NukePU==========================//
    private IEnumerator UsingNuke()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject zombie in zombies)
        {
            Zombie zombie1 = zombie.GetComponent<Zombie>();
            zombie1.OnNuke();
        }
        ParticleSystem particlesystem = GameObject.Find("NukeExplosion").GetComponent<ParticleSystem>();
        particlesystem.Play();
        audiocontroller.Nuke.Play();    
        yield return new WaitForSeconds(2);
    }
    public void CollidedNuke()
    {
        if (nukecoroutine != null)
        {
            StopCoroutine(nukecoroutine);
        }
        nukecoroutine = StartCoroutine(UsingNuke());    
    }
    //==========================NukePU==========================//
}
