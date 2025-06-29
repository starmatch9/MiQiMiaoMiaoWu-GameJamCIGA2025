using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAction : MonoBehaviour
{

    public GameObject dialogue = null;

    //���öԻ����Э��
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
                yield return null; //ÿ֡���һ��
            }
        }

        A.StaticMembers.ClickBeTrue();

        yield return null;
    }

}
