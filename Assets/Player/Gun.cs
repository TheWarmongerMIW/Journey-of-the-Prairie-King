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
    public float FireRate;
    public Animator animator;
    public Animator leganim;
    public float Damage;
    public AudioSource GunShot;
    private float LastShootTime = 0;
    //public float FireRateStartTime;
    private KeyCode UpKey = KeyCode.UpArrow, DownKey = KeyCode.DownArrow, LeftKey = KeyCode.LeftArrow, RightKey = KeyCode.RightArrow;

    private void Start()
    {
        Damage = 1;
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        leganim = GameObject.FindGameObjectWithTag("Leg"). GetComponent<Animator>();    
    }
    private void Update()
    {
        if (Input.GetKey(UpKey))
        {
            animator.SetTrigger("LookUp");
            leganim.SetTrigger("IsAimingUp");
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                leganim.SetTrigger("IsWalking");
                leganim.ResetTrigger("IsAimingUp");
            }
        }
        if (Input.GetKey(LeftKey))
        {
            animator.SetTrigger("LookLeft");
            leganim.SetTrigger("IsAiming");
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                leganim.SetTrigger("IsWalking");
                leganim.ResetTrigger("IsAiming");
            }
        }
        if (Input.GetKey(DownKey))
        {
            animator.SetTrigger("LookDown");
            leganim.SetTrigger("IsAimingUp");
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                leganim.SetTrigger("IsWalking");
                leganim.ResetTrigger("IsAimingUp");
            }
        }
        if (Input.GetKey(RightKey))
        {
            animator.SetTrigger("LookRight");
            leganim.SetTrigger("IsAiming");
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                leganim.SetTrigger("IsWalking");
                leganim.ResetTrigger("IsAiming");
            }
        }
        if (Input.GetKey(UpKey) && Input.GetKey(LeftKey) || Input.GetKey(DownKey) && Input.GetKey(LeftKey))
        {
            animator.SetTrigger("LookLeft");
            leganim.SetTrigger("IsAiming");
            leganim.ResetTrigger("IsAimingUp");
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                leganim.SetTrigger("IsWalking");
                leganim.ResetTrigger("IsAiming");
                leganim.ResetTrigger("IsAimingUp");
            }
        }
        if (Input.GetKey(UpKey) && Input.GetKey(RightKey) || Input.GetKey(DownKey) && Input.GetKey(RightKey))
        {
            animator.SetTrigger("LookRight");
            leganim.SetTrigger("IsAiming");
            leganim.ResetTrigger("IsAimingUp");
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                leganim.SetTrigger("IsWalking");
                leganim.ResetTrigger("IsAiming");
                leganim.ResetTrigger("IsAimingUp");
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
