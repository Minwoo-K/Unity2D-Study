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
    private bool x, y, z;

    private float offsetY;

    private void Awake()
    {
        offsetY = transform.position.y - target.position.y;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3( (x ? target.position.x : transform.position.x),
                                          (y ? target.position.y+offsetY : transform.position.y),
                                          (z ? target.position.z : transform.position.z) );
        
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, stageData.MinCameraLimitX, stageData.MaxCameraLimitX);
        transform.position = position;
    }
}
