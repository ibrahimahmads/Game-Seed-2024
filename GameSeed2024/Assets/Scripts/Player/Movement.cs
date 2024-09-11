using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed = 5f;
    
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Tambahkan referensi ke senjata (weapon)
    [SerializeField] private Transform weapon;  // Senjata yang akan mengikuti flip

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Flip();
        //Jump();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        // Mengecek arah horizontal dan melakukan flip
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;

            // Membalikkan arah skala karakter
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

            // Membalikkan arah senjata
            Vector3 weaponScale = weapon.localScale;
            weaponScale.x *= -1f; // Membalikkan skala sumbu X senjata
            weapon.localScale = weaponScale;

        }
    }

    
}
