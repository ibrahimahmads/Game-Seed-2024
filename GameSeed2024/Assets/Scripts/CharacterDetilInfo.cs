using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterDetilInfo : MonoBehaviour
{
    public Button buttonStory; // Tombol untuk menampilkan cerita karakter
    public Button buttonSkill; // Tombol untuk menampilkan skill karakter
    public TextMeshProUGUI characterContentText; // Text untuk cerita atau skill karakter di panel konten
    public TextMeshProUGUI characterTittleContentText; // Text untuk cerita atau skill karakter di panel konten
    private CharacterInfoData currentCharacterData; // Menyimpan data karakter yang dipilih
    // Fungsi ini dipanggil untuk mengatur data karakter saat karakter dipilih
    public void SetCharacterData(CharacterInfoData data)
    {
        currentCharacterData = data; // Simpan data karakter yang dipilih
    }

    // Fungsi ketika tombol "Story" diklik
    public void OnStoryButtonClicked()
    {
        if (currentCharacterData!= null)
        {
            characterTittleContentText.text = "Lore : ";
            characterContentText.text = currentCharacterData.story; // Menampilkan cerita karakter
        }
    }

    // Fungsi ketika tombol "Skill" diklik
    public void OnSkillButtonClicked()
    {
        if (currentCharacterData != null)
        {
            characterTittleContentText.text = "Skill Description : ";
            characterContentText.text = currentCharacterData.skills; // Menampilkan skill karakter
        }
    }
}
