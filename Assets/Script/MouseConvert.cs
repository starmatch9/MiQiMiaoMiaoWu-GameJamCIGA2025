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

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;




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
        Vector2 newPosition1 = new Vector2(273, 426);
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            cursorImage.anchoredPosition = Vector2.Lerp(centerPosition, newPosition1, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cursorImage.sizeDelta = originalSize;

        yield return new WaitForSeconds(1f);

        Animator animator1 = item1.GetComponent<Animator>();
        animator1.enabled = true;


        //�����ƶ���ָ��λ��
        duration = 0.5f;//��������ʱ��
        elapsedTime = 0f;
        Vector2 newPosition2 = new Vector2(405, 426);
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            cursorImage.anchoredPosition = Vector2.Lerp(newPosition1, newPosition2, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cursorImage.sizeDelta = originalSize;

        yield return new WaitForSeconds(1f);
        Animator animator2 = item2.GetComponent<Animator>();
        animator2.enabled = true;

        duration = 0.5f;//��������ʱ��
        elapsedTime = 0f;
        Vector2 newPosition3 = new Vector2(542, 426);
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            cursorImage.anchoredPosition = Vector2.Lerp(newPosition2, newPosition3, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cursorImage.sizeDelta = originalSize;

        yield return new WaitForSeconds(1f);
        Animator animator3 = item3.GetComponent<Animator>();
        animator3.enabled = true;

        duration = 0.5f;//��������ʱ��
        elapsedTime = 0f;
        Vector2 newPosition4 = new Vector2(678, 426);
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            cursorImage.anchoredPosition = Vector2.Lerp(newPosition3, newPosition4, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cursorImage.sizeDelta = originalSize;

        yield return new WaitForSeconds(1f);
        Animator animator4 = item4.GetComponent<Animator>();
        animator4.enabled = true;


        duration = 0.5f;//��������ʱ��
        elapsedTime = 0f;
        Vector2 newPosition5 = new Vector2(829, 21);
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            cursorImage.anchoredPosition = Vector2.Lerp(newPosition4, newPosition5, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cursorImage.sizeDelta = originalSize;

        yield return new WaitForSeconds(1f);



        //isFollowingRealMouse = true;
    }

}
