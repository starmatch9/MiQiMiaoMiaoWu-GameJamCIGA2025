using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseConvert : MonoBehaviour
{
    [SerializeField] private RectTransform cursorImage; // �������UI Image
    [SerializeField] private Canvas parentCanvas;


    public AudioClip sound;
    public AudioSource audioSource;

    private bool isFollowingRealMouse = false;

    void Start()
    {
        // ����ϵͳ���
        Cursor.visible = false;

        isFollowingRealMouse = true;

        // ��ȡCanvas����Ⱦģʽ����������ת����
        if (parentCanvas == null)
            parentCanvas = GetComponentInParent<Canvas>();
    }

    void Update()
    {
        if (isFollowingRealMouse)
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
        // ��¼ԭʼ��С��λ��
        Vector2 originalSize = cursorImage.sizeDelta;
        Vector2 originalPosition = cursorImage.anchoredPosition;

        // ������Ļ����λ�ã�Canvas�ֲ����꣩
        Vector2 centerPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            new Vector2(Screen.width / 2, Screen.height / 2),
            parentCanvas.worldCamera,
            out centerPosition
        );

        float duration = 1f;//��������ʱ��
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

        // ȷ������λ�úʹ�С׼ȷ
        cursorImage.anchoredPosition = centerPosition;
        cursorImage.sizeDelta = originalSize * 10f;

        yield return new WaitForSeconds(1f);

        Transform bubbleTransform = cursorImage.transform.Find("Bubble");
        GameObject bubble = bubbleTransform != null ? bubbleTransform.gameObject : null;

        bubble.SetActive(true);

        PlaySound();

        yield return new WaitForSeconds(4f);

        bubble.SetActive(false);



        duration = 1f;//��������ʱ��
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

        //�����ƶ���ָ��λ��
        duration = 1f;//��������ʱ��
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
