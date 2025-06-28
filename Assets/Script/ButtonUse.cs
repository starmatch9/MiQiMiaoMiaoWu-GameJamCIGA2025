using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUse : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    void Update()
    {
        if (A.StaticMembers.doIt())
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
}
