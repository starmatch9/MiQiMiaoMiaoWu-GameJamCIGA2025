using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace A
{
    public static class StaticMembers
    {
        // 确保在Unity初始化时重置
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void Init()
        {
            StaticMembers.canClick = true;
        }

        public static bool canClick = true;

        public static bool doIt()
        {
            return StaticMembers.canClick;
        }

        public static void ClickBeTrue()
        {
            StaticMembers.canClick = true;
        }

        public static void ClickBeFalse()
        {
            StaticMembers.canClick = false;
        }

        public static void changeSce()
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}

