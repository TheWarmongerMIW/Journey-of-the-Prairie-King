using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    //public Transform FirePoint;
    public PlayerMovement playermovement;
    public GameObject BulletPrefab;
    public float BulletForce;
    public float FireRate ;
    public Animator cbanim;
    public Animator leganim;
    public float Damage;
    public AudioSource GunShot;
    public UsePU usepu;
    public bool isShooting = false;
    public bool isShootingUp = false;
    public bool isShootingLeft = false;
    public bool isShootingDown = false;
    public bool isShootingRight = false;
    private float LastShootTime = 0;
    private KeyCode UpKey = KeyCode.UpArrow, DownKey = KeyCode.DownArrow, LeftKey = KeyCode.LeftArrow, RightKey = KeyCode.RightArrow;
    private string currentstate;

    const string DefaultState = "Default State";
    const string CBAimUp = "CBAimUp";
    const string CBAimLeft = "CBAimLeft";
    const string CBAimDown = "CBAimDown";
    const string CBAimRight = "CBAimRight";
    private void Start()
    {
        Damage = 1;
        playermovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        cbanim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        leganim = GameObject.FindGameObjectWithTag("Leg"). GetComponent<Animator>();  
        usepu = GameObject.Find("Player").GetComponent<UsePU>();    
    }
    private void Update()
    {
        //==================================================== Aim Up & Down ====================================================//
        if ((Input.GetKey(UpKey) || Input.GetKey(DownKey)) && usepu.IsUsingTombstone == false)
        {
            leganim.SetTrigger("IsAimingUp");
           
            if (Input.GetKey(UpKey))
            {
                ChangeAnim(CBAimUp);
                isShootingUp = true;
            }
            if (Input.GetKey(DownKey))
            {
                ChangeAnim(CBAimDown);
                isShootingDown = true;
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                leganim.SetTrigger("IsWalking");
                leganim.ResetTrigger("IsAimingUp");
            }
        }
        else
        {
            isShootingUp = false;
            isShootingDown = false;
        }

        //==================================================== Aim Left & Right ====================================================//
        if ((Input.GetKey(LeftKey) || Input.GetKey(RightKey)) && usepu.IsUsingTombstone == false)
        {
            leganim.SetTrigger("IsAiming");

            if (Input.GetKey(LeftKey))
            {
                ChangeAnim(CBAimLeft);
                isShootingLeft = true;
            }
            if (Input.GetKey(RightKey))
            {
                ChangeAnim(CBAimRight);
                isShootingRight = true;
            }

            if (Input.GetKey(UpKey) || Input.GetKey(DownKey)) leganim.ResetTrigger("IsAimingUp");

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                leganim.SetTrigger("IsWalking");
                leganim.ResetTrigger("IsAiming");
            }
        }
        else
        {
            isShootingLeft = false;
            isShootingRight = false;
        }

        if (Input.GetKey(UpKey) || Input.GetKey(LeftKey) || Input.GetKey(DownKey) || Input.GetKey(RightKey)) isShooting = true;
        else isShooting = false;
        
        if (isShooting == false && playermovement.isMoving == false && usepu.IsUsingTombstone == false) ChangeAnim(DefaultState);
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
            else
            {
                GunShot.Stop();
            }
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
        Rigidbody2D BulletBody = bullet.GetComponent<Rigidbody2D>();
        Vector2 Direction = Vector2.zero;
        if (Input.GetKey(UpKey)) Direction += Vector2.up;
        if (Input.GetKey(LeftKey)) Direction += Vector2.left;
        if (Input.GetKey(DownKey)) Direction += Vector2.down;
        if (Input.GetKey(RightKey)) Direction += Vector2.right;
        if (Direction != Vector2.zero) Direction.Normalize();
        BulletBody.velocity = Direction * BulletForce;

        if (usepu.IsUsingShotgun == true || usepu.IsUsingBadge == true)
        {
            float coneAngle = 15f; // Angle between bullets in degrees

            for (int i = -1; i <= 1; i++)
            {
                float angle = i * coneAngle;
                Vector2 direction = Quaternion.Euler(0, 0, angle) * Direction;
                bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
                BulletBody = bullet.GetComponent<Rigidbody2D>();
                BulletBody.velocity = direction * BulletForce;
            }
        }

        if (usepu.IsUsingWheel == true)
        {
            float[] angles = new float[] { 0, 45, 90, 135, 180, 225, 270, 315 };

            foreach (float angle in angles)
            {
                Vector2 direction = Quaternion.Euler(0, 0, angle) * Direction;
                bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
                BulletBody = bullet.GetComponent<Rigidbody2D>();
                BulletBody.velocity = direction * BulletForce;
            }
        }
    }
    void ChangeAnim(string newstate)
    {
        if (currentstate == newstate) return;
        cbanim.Play(newstate, -1, 0f);
        currentstate = newstate;    
    }
}
