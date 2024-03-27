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

    private float   offsetY;

    private void Awake()
    {
        offsetY = Mathf.Abs(transform.position.y - target.position.y);
    }

    private void LateUpdate()
    {
        float x = followX ? target.position.x : transform.position.x;
        float y = followY ? target.position.y + offsetY : transform.position.y;
        //float y = Mathf.SmoothDamp(transform.position.y, target.position.y+offsetY, ref dampVelocity, 0.8f);

        x = Mathf.Clamp(x, stageData.CameraMinX, stageData.CameraMaxX);
        y = Mathf.Clamp(y, stageData.MapMinY, stageData.CameraMaxY);
        
        transform.position = new Vector3(x, y, -10);
    }
}
