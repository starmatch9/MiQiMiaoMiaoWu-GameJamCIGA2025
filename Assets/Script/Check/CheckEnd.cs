using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnd : MonoBehaviour
{
    private bool hasExe = false;

    GameObject[] dias = null;
    GameObject[] acts = null;

    public MouseConvert mouseConvert = null;


    void Awake()
    {
        //��ǩΪDia��Act����������
        dias = GameObject.FindGameObjectsWithTag("Dia");
        acts = GameObject.FindGameObjectsWithTag("Act");
    }

    private void Start()
    {
        StartCoroutine(CheckCondition());
    }

    // Update is called once per frame
    //����update
    IEnumerator CheckCondition()
    {
        while (!hasExe)
        {
            if (Check())
            {
                if (mouseConvert != null)
                {
                    mouseConvert.test();
                }
                hasExe = true;
            }

            yield return new WaitForSeconds(2f);
        }
    }

    bool Check()
    {
        foreach (GameObject act in acts)
        {
            //��isDone��Ա
            BubbleShow b = act.GetComponent<BubbleShow>();
            if (!b.isDone)
            {
                return false;
            }
        }

        foreach (GameObject dia in dias)
        {
            //�ж����ڼ���̬�Ͳ���
            if (dia.activeInHierarchy)
            {
                return false;
            }
        }
        return true;
    }
}
