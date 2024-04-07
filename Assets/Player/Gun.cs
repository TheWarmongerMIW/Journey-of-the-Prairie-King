using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //public Transform FirePoint;
    public GameObject BulletPrefab;
    public float BulletForce;
    public float FireRate;
    private float LastShootTime = 0;
    //public float FireRateStartTime;
    private KeyCode UpKey = KeyCode.UpArrow, DownKey = KeyCode.DownArrow, LeftKey = KeyCode.LeftArrow, RightKey = KeyCode.RightArrow;

    // Update is called once per frame
    void Update()
    {if (Time.time > LastShootTime + FireRate)
        {
            if (Input.GetKey(UpKey) || Input.GetKey(LeftKey) || Input.GetKey(DownKey) || Input.GetKey(RightKey)) 
            {
                Shoot();
                LastShootTime = Time.time;
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
            }
        }
    }
}
/* if (Input.GetKey(UpKey) && IsShootingD == false) UpShoot();
 if (Input.GetKey(LeftKey) && IsShootingD == false) LeftShoot();
 if (Input.GetKey(DownKey ) && IsShootingD == false) DownShoot();        
 if (Input.GetKey(RightKey) && IsShootingD == false) RightShoot();
 if (Input.GetKey(UpKey) && Input.GetKey(LeftKey))
 {
     IsShootingD = true;
     DLeftShoot();
 }else IsShootingD = false;
 if (Input.GetKey(UpKey) && Input.GetKey(RightKey))
 {
     IsShootingD = true;
     DRightShoot();
 }else IsShootingD = false;
 if (Input.GetKey(DownKey) && Input.GetKey(RightKey))
 {
     IsShootingD = true;
     DDownRightShoot();
 }else IsShootingD = false;
 if (Input.GetKey(DownKey) && Input.GetKey(LeftKey))
 {
     IsShootingD = true;
     DDownLeftShoot();
 }else IsShootingD = false;
}
 void UpShoot()
{
 GameObject Bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
 Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
 rb.AddForce(transform.up * new Vector2 (0,1) * bulletForce, ForceMode2D.Impulse);
}   
 void LeftShoot()
{
 GameObject Bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
 Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
 rb.AddForce(new Vector2(-1, 0) * bulletForce, ForceMode2D.Impulse);
}
 void DownShoot()
{
 GameObject Bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
 Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
 rb.AddForce(new Vector2(0, -1) * bulletForce, ForceMode2D.Impulse);
}   
 void RightShoot()
{
 GameObject Bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
 Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
 rb.AddForce(new Vector2(1, 0) * bulletForce, ForceMode2D.Impulse);
}
 void DLeftShoot()
{
 GameObject Bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
 Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
 rb.AddForce(new Vector2(-1, 1) * bulletForce, ForceMode2D.Impulse);
}
 void DRightShoot()
{
 GameObject Bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
 Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
 rb.AddForce(new Vector2(1, 1) * bulletForce, ForceMode2D.Impulse);
}
 void DDownRightShoot()
{
 GameObject Bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
 Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
 rb.AddForce(new Vector2(1, -1) * bulletForce, ForceMode2D.Impulse);
}   
 void DDownLeftShoot()
{
 GameObject Bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
 Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
 rb.AddForce(new Vector2(-1, -1) * bulletForce, ForceMode2D.Impulse);
}*/
