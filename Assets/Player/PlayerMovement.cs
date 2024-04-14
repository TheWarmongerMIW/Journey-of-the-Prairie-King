using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D PlayerBody;
    public float MoveSpeed = 0;
    public Animator animator;
    public Animator Leganimator;
    private  KeyCode UpKey = KeyCode.W, DownKey = KeyCode.S, LeftKey = KeyCode.A, RightKey = KeyCode.D;
    private Vector2 movement;

    private void Start()
    {
        Leganimator = GameObject.FindGameObjectWithTag("Leg").GetComponent<Animator>(); 
    }
    private void Update()
    {
        if (Input.GetKey(UpKey))
        {
            animator.SetTrigger("LookUp");
            Leganimator.SetTrigger("IsWalking");
        }
        if (Input.GetKey(LeftKey)) 
        {
            animator.SetTrigger("LookLeft");
            Leganimator.SetTrigger("IsWalking");
        }
        if (Input.GetKey(DownKey))
        {
            animator.SetTrigger("LookDown");
            Leganimator.SetTrigger("IsWalking");
        }
        if (Input.GetKey(RightKey))
        {
            animator.SetTrigger("LookRight");
            Leganimator.SetTrigger("IsWalking");
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey(UpKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(0,1) * MoveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(LeftKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(-1, 0) * MoveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(DownKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(0, -1) * MoveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(RightKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(1, 0) * MoveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(RightKey) && Input.GetKey(UpKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(1, 1) * MoveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(LeftKey) && Input.GetKey(UpKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(-1, 1) * MoveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(LeftKey) && Input.GetKey(DownKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(-1, -1) * MoveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(RightKey) && Input.GetKey(DownKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(1, -1) * MoveSpeed * Time.fixedDeltaTime);
    }
    //public void OnFinishedAiming()
    //{
    //animator.SetBool("AimDown", false);
    //}
    //public void OnFinishedAiming()
    //{
        //animator.SetBool("AimDown", false);
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Destroy(gameObject);
            Debug.Log("Collided");
        }
    }
    //private void FixedUpdate()
    //{
    //PlayerBody.MovePosition(PlayerBody.position + movement * MoveSpeed * Time.fixedDeltaTime);
    //}
}
