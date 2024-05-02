using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private bool followX, followY;

    private float offsetY;

    private void Awake()
    {
        offsetY = Mathf.Abs(transform.position.y - target.position.y);
    }

    private void LateUpdate()
    {
        float x = followX ? target.position.x : transform.position.x;
        float y = followY ? target.position.y+offsetY : transform.position.y;


        x = Mathf.Clamp(x, stageData.CameraMinLimitX, stageData.CameraMaxLimitX);
        y = Mathf.Clamp(y, stageData.MapMinLimitY, stageData.CameraMaxLimitY);

        transform.position = new Vector3(x, y, -10);
    }
}
