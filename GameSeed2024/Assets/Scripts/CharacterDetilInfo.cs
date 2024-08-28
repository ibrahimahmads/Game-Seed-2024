using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterDetilInfo : MonoBehaviour
{
    public GameObject storyPanel;  // Panel untuk Story
    public GameObject skillPanel;  // Panel untuk Skill
    public TextMeshProUGUI characterStoryText; // UI Text untuk Story Karakter
    public TextMeshProUGUI characterSkillText; // UI Text untuk Skill Karakter
    public Button tabButtonStory;  // Tombol Tab untuk Story
    public Button tabButtonSkill;  // Tombol Tab untuk Skill
    private Color activeColor = new Color(1f, 1f, 1f, 1f);  
    private Color inactiveColor = new Color(1f, 1f, 1f, 0.3f);  

    private void Start()
    {
        ShowStoryPanel();
    }

    public void UpdateCharacterDetails(string story, string skill)
    {
        characterStoryText.text = story;
        characterSkillText.text = skill;
    }

    public void ShowStoryPanel() //Menampilkan Story Panel
    {
        storyPanel.SetActive(true);
        skillPanel.SetActive(false);
        SetButtonColor(tabButtonStory, activeColor);
        SetButtonColor(tabButtonSkill, inactiveColor);
    }

    public void ShowSkillPanel() //Menampilkan Skill Panel
    {
        storyPanel.SetActive(false);
        skillPanel.SetActive(true);
        SetButtonColor(tabButtonStory, inactiveColor);
        SetButtonColor(tabButtonSkill, activeColor);
    }
    private void SetButtonColor(Button button, Color color) // Fungsi Ubah warna gambar latar belakang tombol
    {
        button.image.color = color;
    }
}
