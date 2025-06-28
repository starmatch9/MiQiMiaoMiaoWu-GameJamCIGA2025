using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StaticMembers : MonoBehaviour
{
    public static bool canClick = false;

    public static void ClickBeTrue()
    {
        canClick = true;
    }

    public static void ClickBeFalse()
    {
        canClick = false;
    }

}
