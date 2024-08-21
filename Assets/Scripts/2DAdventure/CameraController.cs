using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;        // StageData
    [SerializeField]
    private Transform target;           // Target transform to follow
    [SerializeField]
    private bool x, y, z;               // If true, follow the target in the given axis
    [SerializeField]
    private float smoothTime = 0.2f;    // Smooth Time for the Camera following the target. The higher the slower.

    private Vector3 smoothVelocity = Vector3.zero;  // Velocity of the smoothness, doesn't matter as long as it exists.
    private float offsetY;              // offset between the target and the camera

    private void Awake()
    {
        offsetY = Mathf.Abs(transform.position.y - target.position.y);
    }

    private void LateUpdate()
    {
        Vector3 position = new Vector3( x ? target.position.x : transform.position.x,
                                        y ? target.position.y + offsetY : transform.position.y,
                                        z ? target.position.z : transform.position.z);

        position.x = Mathf.Clamp(position.x, stageData.CameraMinX, stageData.CameraMaxX);
        position.y = Mathf.Clamp(position.y, stageData.MapMinY, position.y);

        transform.position = Vector3.SmoothDamp(transform.position, position, ref smoothVelocity, smoothTime);
    }
}
