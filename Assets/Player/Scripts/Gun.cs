using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    //public Transform FirePoint;
    public GameObject BulletPrefab;
    public float BulletForce;
    public float FireRate ;
    public Animator cbanim;
    public Animator leganim;
    public float Damage;
    public AudioSource GunShot;
    private float LastShootTime = 0;
    public UsePU usepu;
    private KeyCode UpKey = KeyCode.UpArrow, DownKey = KeyCode.DownArrow, LeftKey = KeyCode.LeftArrow, RightKey = KeyCode.RightArrow;

    private void Start()
    {
        Damage = 1;
        cbanim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        leganim = GameObject.FindGameObjectWithTag("Leg"). GetComponent<Animator>();  
        usepu = GameObject.Find("Player").GetComponent<UsePU>();    
    }
    private void Update()
    {
        if (Input.GetKey(UpKey) && usepu.IsUsingTombstone == false)
        {
            cbanim.SetTrigger("LookUp");
            leganim.SetTrigger("IsAimingUp");
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                leganim.SetTrigger("IsWalking");
                leganim.ResetTrigger("IsAimingUp");
                cbanim.ResetTrigger("LookLeft");
                cbanim.ResetTrigger("LookRight");
                cbanim.ResetTrigger("LookDown");
            }
        }
        if (Input.GetKey(LeftKey) && usepu.IsUsingTombstone == false)
        {
            cbanim.SetTrigger("LookLeft");
            leganim.SetTrigger("IsAiming");
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                leganim.SetTrigger("IsWalking");
                leganim.ResetTrigger("IsAiming");
                cbanim.ResetTrigger("LookUp");
                cbanim.ResetTrigger("LookRight");
                cbanim.ResetTrigger("LookDown");
            }
        }
        if (Input.GetKey(DownKey) && usepu.IsUsingTombstone == false)
        {
            cbanim.SetTrigger("LookDown");
            leganim.SetTrigger("IsAimingUp");
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                leganim.SetTrigger("IsWalking");
                leganim.ResetTrigger("IsAimingUp");
                cbanim.ResetTrigger("LookUp");
                cbanim.ResetTrigger("LookLeft");
                cbanim.ResetTrigger("LookRight");
            }
        }
        if (Input.GetKey(RightKey) && usepu.IsUsingTombstone == false)
        {
            cbanim.SetTrigger("LookRight");
            leganim.SetTrigger("IsAiming");
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                leganim.SetTrigger("IsWalking");
                leganim.ResetTrigger("IsAiming");
                cbanim.ResetTrigger("LookUp");
                cbanim.ResetTrigger("LookLeft");
                cbanim.ResetTrigger("LookDown");
            }
        }
        //===UpLeft&DownLeft==//
        if ((Input.GetKey(UpKey) && Input.GetKey(LeftKey) || Input.GetKey(DownKey) && Input.GetKey(LeftKey)) && usepu.IsUsingTombstone == false)
        {
            cbanim.SetTrigger("LookLeft");
            cbanim.ResetTrigger("LookDown");
            leganim.SetTrigger("IsAiming");
            leganim.ResetTrigger("IsAimingUp");
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                leganim.SetTrigger("IsWalking");
                leganim.ResetTrigger("IsAiming");
                leganim.ResetTrigger("IsAimingUp");
                cbanim.ResetTrigger("LookUp");
                cbanim.ResetTrigger("LookDown");
                cbanim.ResetTrigger("LookRight");
            }
        }
        //===UpRight==//
        if ((Input.GetKey(UpKey) && Input.GetKey(RightKey) || Input.GetKey(DownKey) && Input.GetKey(RightKey)) && usepu.IsUsingTombstone == false)
        {
            cbanim.SetTrigger("LookRight");
            leganim.SetTrigger("IsAiming");
            leganim.ResetTrigger("IsAimingUp");
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                leganim.SetTrigger("IsWalking");
                leganim.ResetTrigger("IsAiming");
                leganim.ResetTrigger("IsAimingUp");
                cbanim.ResetTrigger("LookUp");
                cbanim.ResetTrigger("LookDown");
                cbanim.ResetTrigger("LookLeft");
            }
        }
    }
    private void FixedUpdate()
    {if (Time.time > LastShootTime + FireRate)
        {
            if (Input.GetKey(UpKey) || Input.GetKey(LeftKey) || Input.GetKey(DownKey) || Input.GetKey(RightKey)) 
            {
                Shoot();
                GunShot.Play();
                LastShootTime = Time.time;
            }
            else GunShot.Stop();    
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
        Rigidbody2D BulletBody = bullet.GetComponent<Rigidbody2D>();
        Vector2 Direction = Vector2.zero;
        if (Input.GetKey(UpKey))
        {
            Direction += Vector2.up;
        }
        if (Input.GetKey(LeftKey)) Direction += Vector2.left;
        if (Input.GetKey(DownKey)) Direction += Vector2.down;
        if (Input.GetKey(RightKey)) Direction += Vector2.right;
        if (Direction != Vector2.zero) Direction.Normalize();
        BulletBody.velocity = Direction * BulletForce;
    }
}
