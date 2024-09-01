using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public DialogueSegment[] DialogueSegments;
    [Space]
    public Image SpeakerFace;
    public Image SpeakerFace2;
    public Image SpeakerFace3;
    //public Image SkipIndicator;
    [Space]
    public TextMeshProUGUI SpeakerName;
    public TextMeshProUGUI DialogueDis;
    [Space]
    public float TextSpeed;
    public int DialogueIndex;
    public bool canCont;

    // Start is called before the first frame update
    void Start()
    {
        SetStyle(DialogueSegments[0].Speaker);
        StartCoroutine(PlayDialogue(DialogueSegments[0].Dialogue));
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //SkipIndicator.enabled = canCont;
        if(Input.GetButtonDown("Fire1") && canCont)
        {
            DialogueIndex++;
            if(DialogueIndex == DialogueSegments.Length)
            {
                gameObject.SetActive(false);
                Time.timeScale = 1;
                return;
            }

            SetStyle(DialogueSegments[DialogueIndex].Speaker);
            StartCoroutine(PlayDialogue(DialogueSegments[DialogueIndex].Dialogue));
        }
    }

    void SetStyle (DialogueSCobj Speaker)
    {
        
        if (Speaker.SubjectFace2 == null && Speaker.SubjectFace != null)
        {
            SpeakerFace.gameObject.SetActive(true);
            SpeakerFace.sprite = Speaker.SubjectFace;
            SpeakerFace.color = Color.white;
            SpeakerFace2.gameObject.SetActive(false);
            SpeakerFace3.gameObject.SetActive(false);
        }
        else if(Speaker.SubjectFace2 != null && Speaker.SubjectFace != null)
        {
            SpeakerFace2.gameObject.SetActive(true);
            SpeakerFace3.gameObject.SetActive(true);
            SpeakerFace2.sprite = Speaker.SubjectFace;
            SpeakerFace2.color = Color.white;
            SpeakerFace3.sprite = Speaker.SubjectFace2;
            SpeakerFace3.color = Color.white;
            SpeakerFace.gameObject.SetActive(false);
        }
        SpeakerName.SetText(Speaker.SubjectName);

    }
    IEnumerator PlayDialogue(string Dialogue)
    {

        canCont = false;
        DialogueDis.SetText(string.Empty);

        for(int i = 0; i < Dialogue.Length; i++)
        {
            DialogueDis.text += Dialogue[i];
            yield return new WaitForSecondsRealtime(1f / TextSpeed);
        }
        canCont = true;
    }
}

[System.Serializable]
public class DialogueSegment
{
    public DialogueSCobj Speaker;
    public string Dialogue;
}
