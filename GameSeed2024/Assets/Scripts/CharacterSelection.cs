using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelection : MonoBehaviour
{
    public string characterName;
    public string characterStory;   
    public string characterSkill;
    public CharacterDetilInfo characterDetil;
    public Message message;
    public ButtonNavigasi buttonNavigasi; 
    public GameObject panelInfo; // Panel info karakter
    public Image selectedCharacterDisplay;  // Image UI untuk menampilkan karakter yang dipilih
    public Sprite characterSprite;  // Sprite dari karakter yang dipilih
    
    public void OnMouseDown() //fungsi ketika player klik karakter yang dipilih
    {
        message.ChangeName(characterName);
        buttonNavigasi.PilihKarakter();
        PlayerPrefs.SetString("SelectedCharacter", characterName);
        DisplaySelectedCharacter();
    }

    void DisplaySelectedCharacter() // Fungsi untuk Tampilkan gambar karakter yang dipilih di tengah layar
    {
        selectedCharacterDisplay.sprite = characterSprite; 
        panelInfo.SetActive(true);
        characterDetil.UpdateCharacterDetails(characterStory,characterSkill);
        characterDetil.ShowStoryPanel();
        selectedCharacterDisplay.gameObject.SetActive(true);  
    }
}
