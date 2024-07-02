using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D PlayerBody;
    public float MoveSpeed;
    public float MoveSpeed2; 
    public Animator animator;
    public Animator Leganimator;
    //public UnityEvent StopSpawning;
    private  KeyCode UpKey = KeyCode.W, DownKey = KeyCode.S, LeftKey = KeyCode.A, RightKey = KeyCode.D;
    private Vector2 movement;

    private void Start()
    {
        Leganimator = GameObject.FindGameObjectWithTag("Leg").GetComponent<Animator>();
        MoveSpeed = 4.25f;
        MoveSpeed2 = 3.5f;
    }
    public void Update()
    {   
        UsePU usepu = GameObject.Find("Player").GetComponent<UsePU>();  
        if ((Input.GetKey(UpKey) || Input.GetKey(LeftKey) || Input.GetKey(DownKey) || Input.GetKey(RightKey)) && usepu.IsUsingTombstone == false)
        {  
            Leganimator.SetTrigger("IsWalking");
            if (Input.GetKey(UpKey)) animator.SetTrigger("LookUp");
            if (Input.GetKey(LeftKey)) animator.SetTrigger("LookLeft");
            if (Input.GetKey(DownKey)) animator.SetTrigger("LookDown");
            if (Input.GetKey(RightKey)) animator.SetTrigger("LookRight");
        }
        //====================Disable player collider & stop spawning====================//
        if (Input.GetKey(KeyCode.O)) GetComponent<Collider2D>().enabled = false;
        else if (Input.GetKey(KeyCode.P)) GetComponent<Collider2D>().enabled = true;
        /*if (Input.GetKey(KeyCode.R)) StopSpawning.Invoke();*/
        //====================Disable player collider & stop spawning====================//
    }
    void FixedUpdate()
    {
        if (Input.GetKey(UpKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(0, 1) * MoveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(LeftKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(-1, 0) * MoveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(DownKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(0, -1) * MoveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(RightKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(1, 0) * MoveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(RightKey) && Input.GetKey(UpKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(1, 1) * MoveSpeed2 * Time.fixedDeltaTime);
        if (Input.GetKey(LeftKey) && Input.GetKey(UpKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(-1, 1) * MoveSpeed2 * Time.fixedDeltaTime);
        if (Input.GetKey(LeftKey) && Input.GetKey(DownKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(-1, -1) * MoveSpeed2 * Time.fixedDeltaTime);
        if (Input.GetKey(RightKey) && Input.GetKey(DownKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(1, -1) * MoveSpeed2 * Time.fixedDeltaTime);
    }
}
