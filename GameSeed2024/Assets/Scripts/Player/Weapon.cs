using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float offset;
    [SerializeField] private GameObject gun;
    public GameObject projectile;
    public GameObject grenade;
    public Transform shotPoint;

    private float TimeBetweenShoot;
    public float startTimeBetweenShot;

    private LineRenderer lineRenderer; // Untuk menggambar lintasan granat
    public int trajectoryResolution = 30; // Jumlah titik lintasan
    public float grenadeForce = 10f; // Kekuatan lemparan granat
    public LayerMask whatIsGround;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = trajectoryResolution;
        lineRenderer.enabled = false; // Pastikan LineRenderer tidak terlihat pada awalnya
    }

    void Update()
    {
        HandleRotateGun();
        ShootProjectile();
        HandleGrenade();
    }

    public void HandleRotateGun()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);

        // Flip gun when reach 90 degrees
        Vector3 localScale = gun.transform.localScale;
        if (rotz > 90 || rotz < -90)
        {
            localScale.y = -Mathf.Abs(localScale.y);  // Skala y negatif
        }
        else
        {
            localScale.y = Mathf.Abs(localScale.y);   // Skala y positif
        }
        gun.transform.localScale = localScale;
    }

    public void ShootProjectile()
    {
        if (TimeBetweenShoot <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                TimeBetweenShoot = startTimeBetweenShot;
            }
        }
        else
        {
            TimeBetweenShoot -= Time.deltaTime;
        }
    }

    private void HandleGrenade()
    {
    // Check for right mouse button to display grenade trajectory
    if (Input.GetMouseButton(1)) // Right mouse button pressed
    {
        DrawTrajectory(); // Show grenade trajectory
    }
    else
    {
        lineRenderer.enabled = false; // Hide trajectory when right mouse button is released
    }

    // Handle grenade throw with the Q button
    if (TimeBetweenShoot <= 0) // Check if the cooldown time has elapsed
    {
        if (Input.GetKeyDown(KeyCode.Q)) // If Q key is pressed
        {
            ThrowGrenade(); // Throw the grenade
            TimeBetweenShoot = startTimeBetweenShot; // Reset cooldown timer
        }
    }
    else
    {
        TimeBetweenShoot -= Time.deltaTime; // Decrease cooldown timer each frame
    }
}
    private void DrawTrajectory()
    {
        Vector3[] trajectoryPoints = new Vector3[trajectoryResolution];
        Vector2 startingPosition = shotPoint.position;
        Vector2 startingVelocity = shotPoint.right * grenadeForce;

        for (int i = 0; i < trajectoryResolution; i++)
        {
            float time = i * 0.1f; // Anda bisa menyesuaikan nilai waktu ini
            Vector2 position2D = CalculatePositionAtTime(startingPosition, startingVelocity, time);
            trajectoryPoints[i] = new Vector3(position2D.x, position2D.y, 0);
        }

        lineRenderer.SetPositions(trajectoryPoints);
        lineRenderer.enabled = true;
    }

    private Vector2 CalculatePositionAtTime(Vector2 start, Vector2 velocity, float time)
    {
        Vector2 position = start + velocity * time + 0.5f * Physics2D.gravity * time * time;
        return position;
    }

    private void ThrowGrenade()
    {
        GameObject thrownGrenade = Instantiate(grenade, shotPoint.position, transform.rotation);
        Rigidbody2D rb = thrownGrenade.GetComponent<Rigidbody2D>();
        rb.velocity = shotPoint.right * grenadeForce;
    }
}
