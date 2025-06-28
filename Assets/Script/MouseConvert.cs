using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseConvert : MonoBehaviour
{
    [SerializeField] private RectTransform cursorImage; // 拖入你的UI Image
    [SerializeField] private Canvas parentCanvas;

    void Start()
    {
        // 隐藏系统鼠标
        Cursor.visible = false;

        // 获取Canvas的渲染模式（用于坐标转换）
        if (parentCanvas == null)
            parentCanvas = GetComponentInParent<Canvas>();
    }

    void Update()
    {
        // 让UI Image跟随鼠标位置
        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            Input.mousePosition,
            parentCanvas.worldCamera,
            out mousePos
        );
        cursorImage.anchoredPosition = mousePos;
        
        
        if (Input.GetMouseButtonDown(0)) // 0=左键, 1=右键, 2=中键
        {
            Vector2 mousePosition = Input.mousePosition;
            //Debug.Log("鼠标点击屏幕坐标: " + mousePosition);
        }

    }
}
