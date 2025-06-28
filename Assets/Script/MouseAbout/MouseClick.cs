using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseClick : MonoBehaviour
{
    public GameObject fish = null;
    public GameObject jiaodai = null;
    public GameObject madongshaizi = null;
    public GameObject yaokongqi = null;
    public GameObject a1 = null;



    public AudioClip sound;
    public AudioSource audioSource;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && A.StaticMembers.doIt())
        {
            Debug.Log("¿§·È»¹ÊÇ" + A.StaticMembers.doIt());

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null && hit.gameObject.name == "SF")
            {
                PlaySound();

                BubbleShow bubble = hit.gameObject.GetComponent<BubbleShow>();
                StartCoroutine(bubble.ShowBubble());
                hit.enabled = false;
            }

            if (hit != null && hit.gameObject.name == "BZ")
            {
                PlaySound();

                BubbleShow bubble = hit.gameObject.GetComponent<BubbleShow>();
                StartCoroutine(bubble.ShowBubble());
                hit.enabled = false;
            }



            if (hit != null && hit.gameObject.name == "MTSZ")
            {

                PlaySound();

                BubbleShow bubble = hit.gameObject.GetComponent<BubbleShow>();
                StartCoroutine(bubble.ShowBubble());
                hit.enabled = false;

                SpriteRenderer image = hit.gameObject.GetComponent<SpriteRenderer>();
                image.enabled = false;

                madongshaizi.SetActive(true);

            }

            if (hit != null && hit.gameObject.name == "GuiZi")
            {

                PlaySound();

                BubbleShow bubble = hit.gameObject.GetComponent<BubbleShow>();
                StartCoroutine(bubble.ShowBubble());
                hit.enabled = false;

                yaokongqi.SetActive(true);

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
