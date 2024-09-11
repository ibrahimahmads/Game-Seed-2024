using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            HealthScript.health--;
            if(HealthScript.health <=0){
                PlayerManager.isGameOver = true;
                gameObject.SetActive(false);
            }else{
                StartCoroutine(GetHurt());
            }
        }
    }
    IEnumerator GetHurt(){
        Physics2D.IgnoreLayerCollision(7,8);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(7,8, false);
    }
    
}
