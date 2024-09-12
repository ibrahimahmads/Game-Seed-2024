using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDummy : MonoBehaviour
{
    public float moveSpeed = 2f; // Kecepatan gerakan musuh
    public Transform rightLimit; // Batas kanan
    public Transform leftLimit; // Batas kiri
    public Transform player; // Referensi pemain
    private bool movingRight = true; // Status gerakan

    private Rigidbody2D rb;
    public int health;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update() {
        movement();
        if(health <= 0){
            Destroy(gameObject);
        }    
    }
    public void TakeDamage(int damage){
        health-= damage;
    }

    void movement ()
    {
        // Gerakan musuh
        if (movingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        // Cek batas dan balik arah
        if (transform.position.x >= rightLimit.position.x || transform.position.x <= player.position.x)
        {
            movingRight = false;
        }
        else if (transform.position.x <= leftLimit.position.x || transform.position.x >= player.position.x)
        {
            movingRight = true;
        }

        // Menghadap ke arah pemain
        Vector3 direction = player.position - transform.position;
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Membalik skala untuk menghadap kiri
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1); // Menghadap kanan
        }
    }
}
