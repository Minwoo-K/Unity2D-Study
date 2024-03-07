using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private Transform targetObject;
    [SerializeField]
    private bool x, y, z;

    private float offsetY;

    private void Awake()
    {
        offsetY = Mathf.Abs(transform.position.y - targetObject.position.y);    
    }

    private void LateUpdate()
    {
        transform.position = new Vector3( (x ? targetObject.position.x : transform.position.x),
                                          (y ? targetObject.position.y + offsetY : transform.position.y), 
                                          (z ? targetObject.position.z : transform.position.z) );

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, stageData.MinCameraLimitX, stageData.MaxCameraLimitX);
        transform.position = position;
    }
}
