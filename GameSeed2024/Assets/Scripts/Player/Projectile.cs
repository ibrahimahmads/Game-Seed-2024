using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damage;
    public float distance;
    public LayerMask whatIsSolid;
    void Start() {
        Invoke("DestroyProjectile",lifeTime);    
    }
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up,distance,whatIsSolid);
        if(hitInfo.collider != null){
            if(hitInfo.collider.CompareTag("Enemy")){
                Debug.Log("enemy hitted!!");
                hitInfo.collider.GetComponent<EnemyDummy>().TakeDamage(damage);
            }
            DestroyProjectile();
        }
        transform.Translate(Vector2.right * speed *Time.deltaTime);
    }
    void DestroyProjectile(){
        Destroy(gameObject);
    }
}
