using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShow : MonoBehaviour
{
    //物体本身
    private GameObject obj;

    //气泡
    private GameObject bubble = null;

    public GameObject dialogue1 = null;
    public GameObject dialogue2 = null;

    public AudioClip sound;
    public AudioSource audioSource;


    //形态1和形态2
    public Sprite XingTai1 = null;
    public Sprite XingTai2 = null;

    private void Start()
    {
        obj = GetComponent<GameObject>();
        Transform bubbleTransform = transform.Find("Bubble");
        bubble = bubbleTransform != null ? bubbleTransform.gameObject : null;
    }

    void PlaySound()
    {
        if (sound != null && audioSource != null)
        {
            audioSource.PlayOneShot(sound);
        }
    }

    public IEnumerator ShowBubble()
    {

        if (dialogue1 != null)
        {
            dialogue1.SetActive(true);

            while (dialogue1.activeInHierarchy)
            {
                yield return null; //每帧检查一次
            }
        }



        if(bubble != null)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (XingTai1 != null)
            {
                spriteRenderer.sprite = XingTai1;
            }


            Collider2D collider2D = GetComponent<Collider2D>();
            collider2D.enabled = false;


            bubble.SetActive(true);
            PlaySound();
            yield return new WaitForSeconds(3f);
            bubble.SetActive(false);
            yield return new WaitForSeconds(0.8f);

            if (XingTai2 != null)
            {
                spriteRenderer.sprite = XingTai2;
            }

            Animator animator = GetComponent<Animator>();


            if(animator != null)
            {
                animator.SetBool("run", true);

            }

        }

        if(dialogue2 != null)
        {
            dialogue2.SetActive(true);
        }
    }
}
