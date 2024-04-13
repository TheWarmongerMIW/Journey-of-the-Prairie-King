using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D PlayerBody;
    public float MoveSpeed = 0;
    private  KeyCode UpKey = KeyCode.W, DownKey = KeyCode.S, LeftKey = KeyCode.A, RightKey = KeyCode.D;
    private Vector2 movement;

    private void Start()
    {
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
