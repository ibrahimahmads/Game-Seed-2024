using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionHover : MonoBehaviour
{
    public Image highlightImage;  // Drag and drop your highlight image in the inspector

    void Start()
    {
        highlightImage.enabled = false;  // Hide the highlight at the start
        highlightImage.gameObject.SetActive(false);
    }

    public void OnMouseEnter()
    {
        highlightImage.enabled = true;
        highlightImage.gameObject.SetActive(true);  // Show the highlight when mouse enters
    }

    public void OnMouseExit()
    {
        highlightImage.enabled = false;
        highlightImage.gameObject.SetActive(false); // Hide the highlight when mouse exits
    }
}
