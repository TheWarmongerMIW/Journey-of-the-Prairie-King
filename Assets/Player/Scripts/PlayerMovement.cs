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
    public AudioSource gunload;
    public UnityEvent StopSpawning;
    public UnityEvent PowerUp;
    public InventoryManager inventory;
    public Sprite Wheel;
    public Sprite Bandolier;
    public Sprite Badge;
    public Sprite Coffee;
    public Sprite Nuke;
    public Sprite Shotgun;
    public Sprite Smokebomb;
    public Sprite Tombstone;
    private  KeyCode UpKey = KeyCode.W, DownKey = KeyCode.S, LeftKey = KeyCode.A, RightKey = KeyCode.D;
    private Vector2 movement;
    private bool HaveStuff = false;

    private void Start()
    {
        Leganimator = GameObject.FindGameObjectWithTag("Leg").GetComponent<Animator>();
        inventory = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
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
        if (Input.GetKey(KeyCode.O)) GetComponent<Collider2D>().enabled = false;
        else if (Input.GetKey(KeyCode.P)) GetComponent<Collider2D>().enabled = true;
        if (Input.GetKey(KeyCode.R)) StopSpawning.Invoke();
        if (HaveStuff == true && Input.GetKeyDown(KeyCode.Space)) PowerUp.Invoke();
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
            if (collision.gameObject.tag == "Coin1" || collision.gameObject.tag == "Coin5")
            {
                Coin.Play();
                if (collision.gameObject.tag == "Coin1") inventory.AddCoins(1);
                if (collision.gameObject.tag == "Coin5") inventory.AddCoins(5);
            }
            if (collision.gameObject.tag == "Wheel" || collision.gameObject.tag == "Bandolier" || collision.gameObject.tag == "1-Up" || collision.gameObject.tag == "Badge" || collision.gameObject.tag == "Coffee" || collision.gameObject.tag == "Nuke" || collision.gameObject.tag == "Shotgun" || collision.gameObject.tag == "Smoke bomb" || collision.gameObject.tag == "Tombstone")
            {
                PU.Play();
                HaveStuff = true;
                if (collision.gameObject.tag == "Wheel") inventory.AddItem(Wheel);
                if (collision.gameObject.tag == "Bandolier") inventory.AddItem(Bandolier);
                if (collision.gameObject.tag == "Badge") inventory.AddItem(Badge);
                if (collision.gameObject.tag == "Coffee") inventory.AddItem(Coffee);
                if (collision.gameObject.tag == "Nuke") inventory.AddItem(Nuke);
                if (collision.gameObject.tag == "Shotgun") inventory.AddItem(Shotgun);
                if (collision.gameObject.tag == "Smoke bomb") inventory.AddItem(Smokebomb);
                if (collision.gameObject.tag == "Tombstone") inventory.AddItem(Tombstone);
                if (collision.gameObject.tag == "1-Up") inventory.AddLife();
            }
        }
    }
    public void HavePU()
    {
        HaveStuff = false;
    }
}
