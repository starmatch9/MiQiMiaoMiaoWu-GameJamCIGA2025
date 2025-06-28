using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseDrag : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,
    IPointerDownHandler, IPointerUpHandler
{
    private bool isDragging = false;

    private Vector3 originalScale;
    private Vector2 originalPosition;
    private Transform originalParent;

    public AudioClip sound;
    public AudioSource audioSource;

    private RectTransform rectTransform;

    void Awake()
    {
        //��ʼ��
        rectTransform = GetComponent<RectTransform>();

        if (TryGetComponent<Graphic>(out var graphic))
        {
            graphic.raycastTarget = true; // ǿ���������߼��
        }

        originalScale = transform.localScale;
        originalPosition = rectTransform.anchoredPosition;
        originalParent = transform.parent;

        // ȷ�����ĵ������ģ���ֹ����ƫ�ƣ�
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
    }

    //�������й���귽���ӿڵ�ʵ�֣���ʵ�־ͻᱨ��
    // 1. ������ʱ����
    public void OnPointerEnter(PointerEventData eventData)
    {
/*        Debug.Log("�ҽ�����");
        Debug.Log($"��ͣ����: {name}\n" +
              "���λ��: " + eventData.position +
              "\n���߼�����: " + eventData.pointerCurrentRaycast.gameObject);*/
        if (!isDragging)
        {
            transform.localScale = originalScale * 1.5f;
        }
    }

    // 2. ����뿪ʱ����
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isDragging)
        {
            transform.localScale = originalScale;
        }
    }

    // 3. ��갴��ʱ����
    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        PlaySound();
    }

    // 4. ����ɿ�ʱ����
    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        rectTransform.anchoredPosition = originalPosition;

        //���´������Ƿ�������Ӧλ��
        Match();


    }

    //����ͼ���λ��
    void Update()
    {
        if (isDragging)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                transform.parent as RectTransform,
                Input.mousePosition,
                null,
                out Vector2 localPoint
            );
            rectTransform.anchoredPosition = localPoint;
        }
    }

    void PlaySound()
    {
        if (sound != null && audioSource != null)
        {
            audioSource.PlayOneShot(sound);
        }

    }

    void Match()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(mousePos);

        //����Ļ�
        if (gameObject.name == "fish")
        {
            if (hit != null && hit.gameObject.name == "niannianyouyu")
            {
                //Debug.Log("��������㣬����� 2D ���� TEST");
                BubbleShow bubble = hit.gameObject.GetComponent<BubbleShow>();
                StartCoroutine(bubble.ShowBubble());

                Image image = gameObject.GetComponent<Image>();
                image.enabled = false;
            }
        }
        //��ң�����Ļ��Ļ�
        if (gameObject.name == "yaokongqi")
        {
            if (hit != null && hit.gameObject.name == "TV")
            {
                BubbleShow bubble = hit.gameObject.GetComponent<BubbleShow>();
                StartCoroutine(bubble.ShowBubble());
            }
        }

    }
}
