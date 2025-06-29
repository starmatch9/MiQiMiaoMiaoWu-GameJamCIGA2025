using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAction : MonoBehaviour
{

    public GameObject dialogue = null;

    //调用对话框的协程
    void Start()
    {
        dialogue.SetActive(true);
        StartCoroutine(ShowTime());

    }

    public IEnumerator ShowTime()
    {
        yield return null;

        A.StaticMembers.ClickBeFalse();

        if (dialogue != null)
        {
            dialogue.SetActive(true);

            while (dialogue.activeInHierarchy)
            {
                yield return null; //每帧检查一次
            }
        }

        A.StaticMembers.ClickBeTrue();

        yield return null;
    }

}
