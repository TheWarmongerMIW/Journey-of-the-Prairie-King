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
    public float MoveSpeed = 0;
    public float MoveSpeed2 = 0; 
    public Animator animator;
    public Animator Leganimator;
    public AudioSource Coin;
    public AudioSource PU;
    public UnityEvent StopSpawning;
    public UnityEvent OnCollect;
    public Spawner spawner;
    private  KeyCode UpKey = KeyCode.W, DownKey = KeyCode.S, LeftKey = KeyCode.A, RightKey = KeyCode.D;
    private Vector2 movement;

    private void Start()
    {
        Leganimator = GameObject.FindGameObjectWithTag("Leg").GetComponent<Animator>();
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();  
    }
    public void Update()
    {
        if (Input.GetKey(UpKey) || Input.GetKey(LeftKey) || Input.GetKey(DownKey) || Input.GetKey(RightKey))
        {  
            Leganimator.SetTrigger("IsWalking");
            if (Input.GetKey(UpKey)) animator.SetTrigger("LookUp");
            if (Input.GetKey(LeftKey)) animator.SetTrigger("LookLeft");
            if (Input.GetKey(DownKey)) animator.SetTrigger("LookDown");
            if (Input.GetKey(RightKey)) animator.SetTrigger("LookRight");
        }
        if (Input.GetKey(KeyCode.P)) GetComponent<Collider2D>().enabled = false;
        else if (Input.GetKey(KeyCode.O)) GetComponent<Collider2D>().enabled = true;
        if (Input.GetKey(KeyCode.R)) StopSpawning.Invoke(); 
    }
    void FixedUpdate()
    {
        if (Input.GetKey(UpKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(0,1) * MoveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(LeftKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(-1, 0) * MoveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(DownKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(0, -1) * MoveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(RightKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(1, 0) * MoveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(RightKey) && Input.GetKey(UpKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(1, 1) * MoveSpeed2 * Time.fixedDeltaTime);
        if (Input.GetKey(LeftKey) && Input.GetKey(UpKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(-1, 1) * MoveSpeed2 * Time.fixedDeltaTime);
        if (Input.GetKey(LeftKey) && Input.GetKey(DownKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(-1, -1) * MoveSpeed2 * Time.fixedDeltaTime);
        if (Input.GetKey(RightKey) && Input.GetKey(DownKey)) PlayerBody.MovePosition(PlayerBody.position + new Vector2(1, -1) * MoveSpeed2 * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            OnCollect.Invoke();
            if (collision.gameObject.tag == "Coin") Coin.Play();
            if (collision.gameObject.tag == "Wheel" || collision.gameObject.tag == "Bandolier" || collision.gameObject.tag == "1-Up" || collision.gameObject.tag == "Badge" || collision.gameObject.tag == "Coffee" || collision.gameObject.tag == "Nuke" || collision.gameObject.tag == "Shotgun" || collision.gameObject.tag == "Smoke bomb" || collision.gameObject.tag == "Tombstone") PU.Play();
        }
    }
}
