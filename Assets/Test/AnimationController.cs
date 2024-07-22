using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator cbanim;
    [SerializeField] private Animator leganim;
    [SerializeField] private string currentstate;
    [SerializeField] private bool isMoving;
    [SerializeField] private bool isShooting;
    [SerializeField] private bool isShootingUp;
    [SerializeField] private bool isShootingLeft;
    [SerializeField] private bool isShootingDown;
    [SerializeField] private bool isShootingRight;
    

    const string DefaultState = "Default State";
    const string CBAimUp = "CBAimUp";
    const string CBAimLeft = "CBAimLeft";
    const string CBAimDown = "CBAimDown";
    const string CBAimRight = "CBAimRight";
    // Start is called before the first frame update
    void Start()
    {
        cbanim = GameObject.Find("Player").GetComponent<Animator>();    
        leganim = GameObject.Find("Leg").GetComponent <Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //======================================================= Shoot Anim =======================================================//
        //==================================================== Aim Up & Down ====================================================//
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            leganim.SetTrigger("IsAimingUp");

            if (Input.GetKey(KeyCode.UpArrow))
            {
                ChangeAnim(CBAimUp);
                isShootingUp = true;
            }
            if (Input.GetKey(KeyCode.DownArrow))
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
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            leganim.SetTrigger("IsAiming");

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                ChangeAnim(CBAimLeft);
                isShootingLeft = true;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                ChangeAnim(CBAimRight);
                isShootingRight = true;
            }

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) leganim.ResetTrigger("IsAimingUp");

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

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow)) isShooting = true;
        else isShooting = false;

        //======================================================= Walk Anim =======================================================//
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            leganim.SetTrigger("IsWalking");
            isMoving = true;

            if (Input.GetKey(KeyCode.W)) ChangeAnim(CBAimUp);
            if (Input.GetKey(KeyCode.A)) ChangeAnim(CBAimLeft);
            if (Input.GetKey(KeyCode.S)) ChangeAnim(CBAimDown);
            if (Input.GetKey(KeyCode.D)) ChangeAnim(CBAimRight);
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)) ChangeAnim(CBAimLeft);
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)) ChangeAnim(CBAimRight);

            if (isShootingUp == true) ChangeAnim(CBAimUp);
            if (isShootingLeft == true) ChangeAnim(CBAimLeft);
            if (isShootingDown == true) ChangeAnim(CBAimDown);
            if (isShootingRight == true) ChangeAnim(CBAimRight);
        }
        else isMoving = false;

        /*if (isMoving == false && isShooting == false)
        {
            ChangeAnim(DefaultState);
        }*/

        if (isShooting == false && isMoving == false) ChangeAnim(DefaultState);
    }

    void ChangeAnim(string newstate)
    {
        if (currentstate == newstate) return;
        cbanim.Play(newstate);  
        currentstate = newstate;
    }
}
