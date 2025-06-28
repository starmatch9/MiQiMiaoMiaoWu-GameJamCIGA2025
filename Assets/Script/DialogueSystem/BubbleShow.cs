using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShow : MonoBehaviour
{
    //物体本身
    private GameObject obj;

    //气泡
    private GameObject bubble;

    public GameObject dialogue = null;

    private void Start()
    {
        obj = GetComponent<GameObject>();
        bubble = transform.Find("Bubble").gameObject;
    }

    public IEnumerator ShowBubble()
    {
        bubble.SetActive(true);
        yield return new WaitForSeconds(2f);
        bubble.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        if(dialogue != null)
        {
            dialogue.SetActive(true);
        }
    }
}
