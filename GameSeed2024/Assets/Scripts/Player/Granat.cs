using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granat : MonoBehaviour
{
    public float explosionDelay = 2f; // waktu tunda ledakan
    public float explosionRadius = 2f;
    public int damage = 10;
    public LayerMask whatIsEnemy;

    private bool hasExploded = false;

    void Start()
    {
        Invoke("Explode", explosionDelay);
    }

    void Explode()
    {
        if (hasExploded) return;
        hasExploded = true;

        // Buat efek ledakan di sini (misal partikel atau suara)

        // Deteksi musuh dalam radius ledakan
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, explosionRadius, whatIsEnemy);
        foreach (Collider2D enemy in enemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<EnemyDummy>().TakeDamage(damage);
            }
        }

        // Hancurkan granat setelah ledakan
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        // Menggambar lingkaran radius ledakan untuk debugging
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
