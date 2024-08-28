using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelection : MonoBehaviour
{
    public string itemName;
    public string itemDescriptions;
    public Message items;
    public Message deskripsi;
    
    void Start()
    {
        PlayerPrefs.SetString("Selecteditem", "Fertilizer Candy"); // Item default yang dipake
    }

    public void OnMouseDown() //fungsi ketika player klik item yang dipilih
    {
        items.ChangeName(itemName);
        deskripsi.ChangeName(itemDescriptions);
        PlayerPrefs.SetString("Selecteditem", itemName);
    }
}
