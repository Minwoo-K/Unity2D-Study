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
    private bool x, y;

    private Vector3 startPosition;
    private float deltaY;

    private void Awake()
    {
        startPosition = transform.position;
        deltaY = startPosition.y - target.position.y;
    }

    private void LateUpdate()
    {
        float positionX = Mathf.Clamp(startPosition.x + target.position.x, stageData.CameraMinLimitX, stageData.CameraMaxLimitX);
        float positionY = Mathf.Clamp(startPosition.y + target.position.y + deltaY, stageData.MapMinLimitY, stageData.CameraMaxLimitY);

        transform.position = new Vector3((x ? positionX : transform.position.x),
                                         (y ? positionY : transform.position.y), -10);
    }
}
