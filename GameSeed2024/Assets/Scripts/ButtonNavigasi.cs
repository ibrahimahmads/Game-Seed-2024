using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNavigasi : MonoBehaviour
{
    public GameObject tombolNext;
    public GameObject tombolPrev;
    public GameObject listKarakter;
    public GameObject listItem;
    public GameObject chooseFaction;
    public GameObject namaKarakter;
    public GameObject karakterTampil;
    public Animator animatorKarakter; // Animator untuk panel karakter
    public Animator animatorItem;     // Animator untuk panel item

    private bool isCharacterSelected = false; // Apakah karakter sudah dipilih
    private bool isInCharacterSelection = true; // Mengcek Apakah player berada di menu pemilihan item
    void Start()
    {
        // Menampilkan list karakter secara default
        listKarakter.SetActive(true);
        listItem.SetActive(false);
        tombolNext.SetActive(false);
        tombolPrev.SetActive(true);
    }

    public void PilihKarakter()
    {
        isCharacterSelected = true;  // Set karakter sudah dipilih
        tombolNext.SetActive(true);  // Tampilkan tombol "Next" untuk memilih item
    }

    public void PilihItem()
    {
        if (isCharacterSelected && isInCharacterSelection) // fungsi Ubah state ke pemilihan item
        {
            listItem.SetActive(true);
            chooseFaction.SetActive(false);
            animatorKarakter.Play("List Character Down");
            animatorItem.Play("List Item Left");

            StartCoroutine(SembunyikanKarakterPanel());
            isInCharacterSelection = false; 
        }else
        {
            // Fungsi Masuk ke Battle
        }
    }

    IEnumerator SembunyikanKarakterPanel()
    {
        yield return new WaitForSeconds(animatorKarakter.GetCurrentAnimatorStateInfo(0).length);
        listKarakter.SetActive(false); 
    }

    public void Kembali()
    {
        if (isInCharacterSelection)
        {
            // Kembali ke menu utama
            Debug.Log("Kembali ke menu utama");
        }
        else
        {
            // Fungsi ubah state ke pemilihan karakter
            listKarakter.SetActive(true);
            chooseFaction.SetActive(true);
            animatorKarakter.Play("List Character Up");
            animatorItem.Play("List Item Right"); 
            StartCoroutine(SembunyikanItemPanel());
            isInCharacterSelection = true; 
        }
    }

    IEnumerator SembunyikanItemPanel()
    {
        yield return new WaitForSeconds(animatorItem.GetCurrentAnimatorStateInfo(0).length);
        listItem.SetActive(false); 
    }
}
