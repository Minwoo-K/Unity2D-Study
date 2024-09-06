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
    private float smoothTime;
    [SerializeField]
    private bool x, y, z;

    private float offsetY;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        offsetY = transform.position.y - target.position.y;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(x ? target.position.x : transform.position.x,
                                             y ? target.position.y + offsetY : transform.position.y,
                                             z ? target.position.z - 10 : transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        float posX = transform.position.x;
        posX = Mathf.Clamp(posX, stageData.CameraMinX, stageData.CameraMaxX);
        float posY = transform.position.y;
        posY = Mathf.Clamp(posY, stageData.MapMinY, transform.position.y);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
