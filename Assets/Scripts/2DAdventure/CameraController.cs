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
    private Vector3 offsetFromTarget;

    private void Awake()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = target.position + offsetFromTarget;
        float x = transform.position.x;
        x = Mathf.Clamp(x, stageData.CameraMinX, stageData.CameraMaxX);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
