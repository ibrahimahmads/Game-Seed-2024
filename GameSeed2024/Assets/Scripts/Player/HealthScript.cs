using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    
    public static int health = 3;
    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;
    
    void Awake (){
        health = 3;
    }
    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHearts;
        }
        for(int i = 0; i< health; i++){
            hearts[i].sprite = fullHearts;
        }    
    }
}
