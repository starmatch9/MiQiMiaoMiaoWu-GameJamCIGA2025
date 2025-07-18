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

/*    private bool hasChange = false;*/

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
/*            if (!hasChange) {
                A.StaticMembers.ClickBeFalse();
                Debug.Log("");

                hasChange = true;

            }*/


            currentLine++;
            if (currentLine < Lines.Length)
            {
                ShowDialogue(currentLine);
                PlaySound();
            }
            else
            {
                dialogueBox.SetActive(false);
                /*                A.StaticMembers.ClickBeTrue();
                                hasChange = false;*/

/*                A.StaticMembers.ClickBeTrue();
                Debug.Log("");*/
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