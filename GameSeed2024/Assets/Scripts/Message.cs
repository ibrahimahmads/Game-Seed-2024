using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Message : MonoBehaviour
{
    TextMeshProUGUI Text;

    void Start()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }

    public void ShowMessage(string x)
    {
        Text.enabled = true;
        Text.text = x;
    }

    public void ChangeName(string x)
    {
        Text.text = x;
    }

    public void FinishMessage()
    {
        Text.enabled = false;
    }
}
