using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{

    public AudioClip sound;
    public AudioSource audioSource;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null && hit.gameObject.name == "SF")
            {

                PlaySound();

                BubbleShow bubble = hit.gameObject.GetComponent<BubbleShow>();
                StartCoroutine(bubble.ShowBubble());
                hit.enabled = false;

            }
        }
    }

    void PlaySound()
    {
        if (sound != null && audioSource != null)
        {
            audioSource.PlayOneShot(sound);
        }
    }
}
