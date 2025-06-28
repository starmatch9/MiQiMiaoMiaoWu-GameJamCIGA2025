using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI TextContent;

    public GameObject dialogueBox;

    public DialogueLine[] Lines;

    private int currentLine = 0;

    public AudioClip sound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        ShowDialogue(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            A.StaticMembers.ClickBeFalse();
            Debug.Log("");

            currentLine++;
            if (currentLine < Lines.Length)
            {
                ShowDialogue(currentLine);
                PlaySound();
            }
            else
            {
                dialogueBox.SetActive(false);
                A.StaticMembers.ClickBeTrue();
            }
        }
    }
    void ShowDialogue(int index)
    {
        TextContent.text = Lines[index].content;
    }

    void PlaySound()
    {
        if (sound != null && audioSource != null)
        {
            audioSource.PlayOneShot(sound);
        }

    }
}