using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public UsePU usepu;
    public Gun gun;
    public Rigidbody2D PlayerBody;
    public float MoveSpeed;
    public float MoveSpeed2;
    public Animator animator;
    public Animator Leganimator;
    public bool isMoving;
    private string currentstate;
    //public UnityEvent StopSpawning;
    private  KeyCode UpKey = KeyCode.W, DownKey = KeyCode.S, LeftKey = KeyCode.A, RightKey = KeyCode.D;
    private Vector2 movement;
    
    const string DefaultState = "Default State";
    const string CBAimUp = "CBAimUp";
    const string CBAimLeft = "CBAimLeft";
    const string CBAimDown = "CBAimDown";
    const string CBAimRight = "CBAimRight";

    private void Start()
    {
        usepu = GameObject.Find("Player").GetComponent<UsePU>();    
        gun = GameObject.Find("Gun").GetComponent<Gun>();
        Leganimator = GameObject.FindGameObjectWithTag("Leg").GetComponent<Animator>();
        MoveSpeed = 4.25f;
        MoveSpeed2 = 3.5f;
    }
    void Update()
    {
        if ((Input.GetKey(UpKey) || Input.GetKey(LeftKey) || Input.GetKey(DownKey) || Input.GetKey(RightKey)) && usepu.IsUsingTombstone == false)
        {
            Leganimator.SetTrigger("IsWalking");
            isMoving = true;

            if (Input.GetKey(UpKey)) ChangeAnim(CBAimUp);
            if (Input.GetKey(LeftKey)) ChangeAnim(CBAimLeft);
            if (Input.GetKey(DownKey)) ChangeAnim(CBAimDown);
            if (Input.GetKey(RightKey)) ChangeAnim(CBAimRight);
            if (Input.GetKey(LeftKey) && Input.GetKey(DownKey) || Input.GetKey(LeftKey) && Input.GetKey(UpKey)) ChangeAnim(CBAimLeft);
            if (Input.GetKey(RightKey) && Input.GetKey(DownKey) || Input.GetKey(RightKey) && Input.GetKey(UpKey)) ChangeAnim(CBAimRight);

            if (gun.isShootingUp == true) ChangeAnim(CBAimUp);
            if (gun.isShootingLeft == true) ChangeAnim(CBAimLeft);
            if (gun.isShootingDown == true) ChangeAnim(CBAimDown);
            if (gun.isShootingRight == true) ChangeAnim(CBAimRight);
            if (gun.isShootingUp == true || gun.isShootingDown == true)
            {
                if (gun.isShootingLeft == true) ChangeAnim(CBAimLeft);
                if (gun.isShootingRight == true) ChangeAnim(CBAimRight);
            }
        }
        else isMoving = false;

        if (isMoving == false && gun.isShooting == false && usepu.IsUsingTombstone == false)
        {
            ChangeAnim(DefaultState);
        }

        //====================Disable player collider & stop spawning====================//
        if (Input.GetKey(KeyCode.O)) GetComponent<Collider2D>().enabled = false;
        else if (Input.GetKey(KeyCode.P)) GetComponent<Collider2D>().enabled = true;
        /*if (Input.GetKey(KeyCode.R)) StopSpawning.Invoke();*/
        //====================Disable player collider & stop spawning====================//
    }
    void FixedUpdate()
    {
        if (Input.GetKey(UpKey) || Input.GetKey(LeftKey) || Input.GetKey(DownKey) || Input.GetKey(RightKey))   
        {
            if (Input.GetKey(UpKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(0, 1) * MoveSpeed * Time.fixedDeltaTime);
            if (Input.GetKey(LeftKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(-1, 0) * MoveSpeed * Time.fixedDeltaTime);
            if (Input.GetKey(DownKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(0, -1) * MoveSpeed * Time.fixedDeltaTime);
            if (Input.GetKey(RightKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(1, 0) * MoveSpeed * Time.fixedDeltaTime);
            if (Input.GetKey(LeftKey) && Input.GetKey(UpKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(-1, 1) * MoveSpeed2 * Time.fixedDeltaTime);
            if (Input.GetKey(LeftKey) && Input.GetKey(DownKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(-1, -1) * MoveSpeed2 * Time.fixedDeltaTime);
            if (Input.GetKey(RightKey) && Input.GetKey(UpKey))  PlayerBody.MovePosition(PlayerBody.position + new Vector2(1, 1) * MoveSpeed2 * Time.fixedDeltaTime);
            if (Input.GetKey(RightKey) && Input.GetKey(DownKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(1, -1) * MoveSpeed2 * Time.fixedDeltaTime);
        }
    }
    public void ChangeAnim(string newstate)
    {
        if (currentstate == newstate) return;
        animator.Play(newstate, -1, 0f);    
        currentstate = newstate;    
    }
}
