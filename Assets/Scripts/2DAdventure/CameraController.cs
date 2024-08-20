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
    private bool x, y, z;       // Whether to follow the target in the axis

    private float offsetYFromTarget;

    private void Awake()
    {
        offsetYFromTarget = Mathf.Abs(transform.position.y - target.position.y);
    }

    private void LateUpdate()
    {
        transform.position = new Vector3( x ? target.position.x : transform.position.x, 
                                          y ? target.position.y + offsetYFromTarget : transform.position.y, 
                                          z ? target.position.z : transform.position.z);

        // Range Adjustment
        float posX = transform.position.x;
        posX = Mathf.Clamp(posX, stageData.CameraMinX, stageData.CameraMaxX);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
}
