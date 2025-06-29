using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MouseConvert : MonoBehaviour
{
    [SerializeField] private RectTransform cursorImage; // �������UI Image
    [SerializeField] private Canvas parentCanvas;


    public AudioClip sound;
    public AudioSource audioSource;

    public AudioSource BGM;

    public Image cover;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;

    public GameObject Arror1;
    public GameObject Arror2;

    public Animator ZhuoZi;
    public Animator GuiZi;

    public Animator remenuUI;
    public Sprite UI1;
    public Animator arrorUI;
    public Sprite UI2;


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

    public IEnumerator PlayBGM()
    {
        //����ʱ�䣬�����ۼ�
        float elapsedTime = 0f;
        //��ʼ����
        BGM.volume = 0;
        //�Զ���������
        BGM.Play();
        while (elapsedTime < 10f)
        {
            //���հٷֱȴ�0��1��ֵ
            float alpha = Mathf.Lerp(0f, 0.3f, elapsedTime / 10f);
            BGM.volume = alpha;
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //����ʱ�����
        BGM.volume = 0.3f;
    }

    public IEnumerator Display()
    {
        EventSystem.current.enabled = false;

        if (Arror2.activeInHierarchy)
        {
            isFollowingRealMouse = false;

            Vector2 ori = cursorImage.anchoredPosition;
            //�����ƶ���ָ��λ��
            float d = 1f;//��������ʱ��
            float eT = 0f;
            Vector2 newPosition = new Vector2(-786, -67);
            while (eT < d)
            {
                float t = eT / d;
                cursorImage.anchoredPosition = Vector2.Lerp(ori, newPosition, t);
                eT += Time.deltaTime;
                yield return null;
            }
            cursorImage.anchoredPosition = newPosition;

            yield return new WaitForSeconds(0.5f);

            Button but = Arror2.GetComponent<Button>();
            but.onClick.Invoke();

            yield return new WaitForSeconds(1f);


        }

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

        //ǿ��ˢ�²��֣�����û��ʲô���ã�
        LayoutRebuilder.ForceRebuildLayoutImmediate(cursorImage.GetComponent<RectTransform>());

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

        StartCoroutine(PlayBGM());

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
        Vector2 newPosition5 = new Vector2(-641, -140);
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            cursorImage.anchoredPosition = Vector2.Lerp(newPosition4, newPosition5, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cursorImage.sizeDelta = originalSize;

        yield return new WaitForSeconds(1f);
        ZhuoZi.enabled = true;

        duration = 0.5f;//��������ʱ��
        elapsedTime = 0f;
        Vector2 newPosition6 = new Vector2(475, -333);
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            cursorImage.anchoredPosition = Vector2.Lerp(newPosition5, newPosition6, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cursorImage.sizeDelta = originalSize;

        yield return new WaitForSeconds(1f);
        GuiZi.enabled = true;

        //�����ͷ
        duration = 0.5f;//��������ʱ��
        elapsedTime = 0f;
        Vector2 newPosition7 = new Vector2(883, -41);
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            cursorImage.anchoredPosition = Vector2.Lerp(newPosition6, newPosition7, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cursorImage.sizeDelta = originalSize;

        yield return new WaitForSeconds(1f);

        Image h2 = arrorUI.transform.gameObject.GetComponent<Image>();
        h2.sprite = UI2;

        yield return new WaitForSeconds(1f);
        arrorUI.enabled = true;

        //����˵�
        duration = 0.5f;//��������ʱ��
        elapsedTime = 0f;
        Vector2 newPosition8 = new Vector2(-825, 444);
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            cursorImage.anchoredPosition = Vector2.Lerp(newPosition7, newPosition8, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cursorImage.sizeDelta = originalSize;

        yield return new WaitForSeconds(1f);

        Image h1 = remenuUI.transform.gameObject.GetComponent<Image>();
        h1.sprite = UI1;

        yield return new WaitForSeconds(1f);
        remenuUI.enabled = true;
        
        //����
        yield return new WaitForSeconds(2f);


        elapsedTime = 0f;
        cover.transform.gameObject.SetActive(true);
        while (elapsedTime < 4f)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / 4f);
            cover.color = new Color(0, 0, 0, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cover.color = Color.black;

        yield return new WaitForSeconds(3f);

        //SceneManager.LoadScene("MainMenu");
        //EventSystem.current.enabled = true;

        A.StaticMembers.changeSce();

        //�ص����˵�


        //isFollowingRealMouse = true;
    }

}
