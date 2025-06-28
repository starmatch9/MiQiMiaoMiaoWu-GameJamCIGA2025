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
        //标签为Dia和Act的两个数组
        dias = GameObject.FindGameObjectsWithTag("Dia");
        acts = GameObject.FindGameObjectsWithTag("Act");
    }

    private void Start()
    {
        StartCoroutine(CheckCondition());
    }

    // Update is called once per frame
    //代替update
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
            //看isDone成员
            BubbleShow b = act.GetComponent<BubbleShow>();
            if (!b.isDone)
            {
                return false;
            }
        }

        foreach (GameObject dia in dias)
        {
            //有对象处于激活态就不行
            if (dia.activeInHierarchy)
            {
                return false;
            }
        }
        return true;
    }
}
