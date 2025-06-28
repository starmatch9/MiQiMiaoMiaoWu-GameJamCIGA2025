using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeCamera : MonoBehaviour
{
    private Camera mainCamera;

    // Y�������Ŀ��λ��
    private const float Y_POSITION_1 = 0f;
    private const float Y_POSITION_2 = -30f;
    // Z��̶�λ��
    private const float Z_POSITION = -10f;
    void Start()
    {
        //��ȡ�����
        mainCamera = Camera.main;
    }

    //û�����Ĵ���ʽ��̫������
    public void SwitchCameraYPosition()
    {
        Vector3 currentPos = mainCamera.transform.position;

        // ����Y��λ��
        float newY = Mathf.Approximately(currentPos.y, Y_POSITION_1)
            ? Y_POSITION_2
            : Y_POSITION_1;

        // ����X��Z�᲻�䣬ֻ�ı�Y��
        mainCamera.transform.position = new Vector3(
            currentPos.x,
            newY,
            Z_POSITION
        );
    }
}