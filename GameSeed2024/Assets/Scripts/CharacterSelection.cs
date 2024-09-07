using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters; // Semua karakter (Parent GameObject)
    public Vector2 originalSize = new Vector2(300, 450); // Ukuran asli gambar karakter
    public Vector2 hoverSize = new Vector2(300, 400); // Ukuran gambar karakter saat hover
    public Vector2 selectedSize = new Vector2(300, 400); // Ukuran border saat karakter dipilih
    public GameObject characterInfoPanel; // Panel untuk menampilkan info karakter
    public Image characterImageDisplay; // Gambar karakter yang akan ditampilkan di panel info
    public Image characterName; // Text untuk nama karakter
    public CharacterDetilInfo characterDetilInfo;
    public ButtonNavigasi buttonNavigasi;
    private GameObject selectedCharacter = null; // Menyimpan karakter yang dipilih
    private CharacterInfoData selectedCharacterData = null; 

    void Start()
    {
        // Reset semua karakter ke ukuran asli pada awal
        ResetAllCharacters();
        // Sembunyikan panel info karakter saat awal
        characterInfoPanel.SetActive(false);
    }

    // Memanggil fungsi ini ketika hover mulai
    public void OnHoverEnter(GameObject characterImage)
    {
        if (selectedCharacter != null && characterImage.transform.parent.gameObject == selectedCharacter)
        {
            return; // Jika karakter ini adalah karakter yang dipilih, jangan lakukan apapun
        }
        RectTransform rectTransform = characterImage.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.sizeDelta = hoverSize; // Mengubah ukuran gambar saat hover
        }
    }

    // Memanggil fungsi ini ketika hover selesai
    public void OnHoverExit(GameObject characterImage)
    {
         if (selectedCharacter != null && characterImage.transform.parent.gameObject == selectedCharacter)
        {
            return; // Jika karakter ini adalah karakter yang dipilih, jangan lakukan apapun
        }
        RectTransform rectTransform = characterImage.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.sizeDelta = originalSize; // Mengembalikan ukuran asli
        }
    }

    // Memanggil fungsi ini ketika karakter dipilih
    public void OnCharacterSelect(GameObject character)
    {
        // Jika ada karakter yang dipilih sebelumnya, reset border-nya
        if (selectedCharacter != null)
        {
            ResetCharacterBorder(selectedCharacter);
        }

        // Tandai karakter yang dipilih saat ini
        selectedCharacter = character;
        SetSelectedBorder(character);
        buttonNavigasi.PilihKarakter();
        string characterName = character.name; // Mengambil nama karakter dari GameObject
        PlayerPrefs.SetString("SelectedCharacterName", characterName);
        PlayerPrefs.Save();
        // Tampilkan informasi karakter yang dipilih
        ShowCharacterInfo(character);
    }

    // Mengatur border karakter yang dipilih
    private void SetSelectedBorder(GameObject character)
    {
        RectTransform borderTransform = character.transform.Find("Border").GetComponent<RectTransform>();
        if (borderTransform != null)
        {
            borderTransform.sizeDelta = selectedSize; // Mengubah ukuran border saat karakter dipilih
        }
    }

    // Reset border karakter yang tidak dipilih
    private void ResetCharacterBorder(GameObject character)
    {
        RectTransform borderTransform = character.transform.Find("Border").GetComponent<RectTransform>();
        if (borderTransform != null)
        {
            borderTransform.sizeDelta = originalSize; // Mengembalikan ukuran border asli
        }
    }

    // Reset semua karakter ke ukuran default
    private void ResetAllCharacters()
    {
        foreach (GameObject character in characters)
        {
            RectTransform characterImageTransform = character.transform.Find("Border").GetComponent<RectTransform>();
            if (characterImageTransform != null)
            {
                characterImageTransform.sizeDelta = originalSize; // Ukuran default karakter
            }
            
            ResetCharacterBorder(character);
        }
    }

    // Tampilkan informasi karakter yang dipilih
    private void ShowCharacterInfo(GameObject character)
    {
        // Asumsi ada komponen "CharacterData" yang memiliki cerita dan skill
        CharacterInfoData data = character.GetComponent<CharacterInfoData>();

        if (data == null) return; // Jika tidak ada data, tidak perlu melanjutkan

        // Simpan data karakter yang dipilih untuk digunakan pada tombol
        selectedCharacterData = data;

        // Pastikan panel info aktif
        characterInfoPanel.SetActive(true);

        if (characterImageDisplay != null && characterName != null)
        {
            characterImageDisplay.sprite = selectedCharacterData.characterImage;
            characterName.sprite = selectedCharacterData.characterName;;
        }   
        characterDetilInfo.SetCharacterData(selectedCharacterData);

        // Default menampilkan cerita karakter ketika dipilih
        characterDetilInfo.OnStoryButtonClicked();
    }

    
}

