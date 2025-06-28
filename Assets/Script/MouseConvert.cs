using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseConvert : MonoBehaviour
{
    [SerializeField] private RectTransform cursorImage; // �������UI Image
    [SerializeField] private Canvas parentCanvas;

    void Start()
    {
        // ����ϵͳ���
        Cursor.visible = false;

        // ��ȡCanvas����Ⱦģʽ����������ת����
        if (parentCanvas == null)
            parentCanvas = GetComponentInParent<Canvas>();
    }

    void Update()
    {
        // ��UI Image�������λ��
        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            Input.mousePosition,
            parentCanvas.worldCamera,
            out mousePos
        );
        cursorImage.anchoredPosition = mousePos;
        
        
        if (Input.GetMouseButtonDown(0)) // 0=���, 1=�Ҽ�, 2=�м�
        {
            Vector2 mousePosition = Input.mousePosition;
            //Debug.Log("�������Ļ����: " + mousePosition);
        }

    }
}
