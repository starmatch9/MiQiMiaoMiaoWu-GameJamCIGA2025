using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseConvert : MonoBehaviour
{
    [SerializeField] private RectTransform cursorImage; // 拖入你的UI Image
    [SerializeField] private Canvas parentCanvas;


    public AudioClip sound;
    public AudioSource audioSource;

    private bool isFollowingRealMouse = false;

    void Start()
    {
        // 隐藏系统鼠标
        Cursor.visible = false;

        isFollowingRealMouse = true;

        // 获取Canvas的渲染模式（用于坐标转换）
        if (parentCanvas == null)
            parentCanvas = GetComponentInParent<Canvas>();
    }

    void Update()
    {
        if (isFollowingRealMouse)
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
    void PlaySound()
    {
        if (sound != null && audioSource != null)
        {
            audioSource.PlayOneShot(sound);
        }
    }

    public void test()
    {
        StartCoroutine(Display());
    }

    public IEnumerator Display()
    {
        // 记录原始大小和位置
        Vector2 originalSize = cursorImage.sizeDelta;
        Vector2 originalPosition = cursorImage.anchoredPosition;

        // 计算屏幕中央位置（Canvas局部坐标）
        Vector2 centerPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            new Vector2(Screen.width / 2, Screen.height / 2),
            parentCanvas.worldCamera,
            out centerPosition
        );

        float duration = 1f;//动画持续时间
        float elapsedTime = 0f;

        isFollowingRealMouse = false;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            cursorImage.anchoredPosition = Vector2.Lerp(originalPosition, centerPosition, t);
            cursorImage.sizeDelta = Vector2.Lerp(originalSize, originalSize * 10f, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 确保最终位置和大小准确
        cursorImage.anchoredPosition = centerPosition;
        cursorImage.sizeDelta = originalSize * 10f;

        yield return new WaitForSeconds(1f);

        Transform bubbleTransform = cursorImage.transform.Find("Bubble");
        GameObject bubble = bubbleTransform != null ? bubbleTransform.gameObject : null;

        bubble.SetActive(true);

        PlaySound();

        yield return new WaitForSeconds(4f);

        bubble.SetActive(false);



        duration = 1f;//动画持续时间
        elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            cursorImage.anchoredPosition = Vector2.Lerp(originalPosition, centerPosition, t);
            cursorImage.sizeDelta = Vector2.Lerp(originalSize * 10f, originalSize, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cursorImage.sizeDelta = originalSize;

        //让他移动到指定位置
        duration = 1f;//动画持续时间
        elapsedTime = 0f;

        Vector2 newPosition = new Vector2(809, 427);

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            cursorImage.anchoredPosition = Vector2.Lerp(centerPosition, newPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cursorImage.sizeDelta = originalSize;



        isFollowingRealMouse = true;
    }

}
