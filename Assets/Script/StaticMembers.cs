using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class StaticMembers
{
    public static bool canClick = true;
    static StaticMembers()
    {
        canClick = true;
    }
    public static void ClickBeTrue()
    {
        canClick = true;
    }

    public static void ClickBeFalse()
    {
        canClick = false;
    }

}
