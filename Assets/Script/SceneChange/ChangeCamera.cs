using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeCamera : MonoBehaviour
{
    private Camera mainCamera;

    // Y轴的两个目标位置
    private const float Y_POSITION_1 = 0f;
    private const float Y_POSITION_2 = -30f;
    // Z轴固定位置
    private const float Z_POSITION = -10f;
    void Start()
    {
        //获取主相机
        mainCamera = Camera.main;
    }

    //没见过的处理方式，太神奇了
    public void SwitchCameraYPosition()
    {
        Vector3 currentPos = mainCamera.transform.position;

        // 交换Y轴位置
        float newY = Mathf.Approximately(currentPos.y, Y_POSITION_1)
            ? Y_POSITION_2
            : Y_POSITION_1;

        // 保持X和Z轴不变，只改变Y轴
        mainCamera.transform.position = new Vector3(
            currentPos.x,
            newY,
            Z_POSITION
        );
    }
}