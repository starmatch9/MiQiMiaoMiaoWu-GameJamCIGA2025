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
        //初始化
        rectTransform = GetComponent<RectTransform>();

        if (TryGetComponent<Graphic>(out var graphic))
        {
            graphic.raycastTarget = true; // 强制启用射线检测
        }

        originalScale = transform.localScale;
        originalPosition = rectTransform.anchoredPosition;
        originalParent = transform.parent;

        // 确保轴心点在中心（防止缩放偏移）
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
    }

    //以下是有关鼠标方法接口的实现（不实现就会报错）
    // 1. 鼠标进入时触发
    public void OnPointerEnter(PointerEventData eventData)
    {
/*        Debug.Log("我进来了");
        Debug.Log($"悬停对象: {name}\n" +
              "鼠标位置: " + eventData.position +
              "\n射线检测对象: " + eventData.pointerCurrentRaycast.gameObject);*/
        if (!isDragging)
        {
            transform.localScale = originalScale * 1.5f;
        }
    }

    // 2. 鼠标离开时触发
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isDragging)
        {
            transform.localScale = originalScale;
        }
    }

    // 3. 鼠标按下时触发
    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        PlaySound();
    }

    // 4. 鼠标松开时触发
    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        rectTransform.anchoredPosition = originalPosition;

        //以下代码检测是否点击到对应位置
        Match();


    }

    //更新图标的位置
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

        //是鱼的话
        if (gameObject.name == "fish")
        {
            if (hit != null && hit.gameObject.name == "niannianyouyu")
            {
                //Debug.Log("鼠标拿着鱼，点击了 2D 对象 TEST");
                BubbleShow bubble = hit.gameObject.GetComponent<BubbleShow>();
                StartCoroutine(bubble.ShowBubble());

                Image image = gameObject.GetComponent<Image>();
                image.enabled = false;
            }
        }
        //是遥控器的话的话
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
