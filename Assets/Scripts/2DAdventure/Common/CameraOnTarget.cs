using UnityEngine;

public class CameraOnTarget : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;            // Level Data
    [SerializeField]
    private Transform target;               // Target for the Camera to follow
    [SerializeField]
    private bool followX, followY, followZ; // Whether the Camera follow the target in each axis

    private float offsetY;                  // Offset value between the Target and Camera

    private void Awake()
    {
        offsetY = Mathf.Abs(transform.position.y - target.position.y);
    }

    private void LateUpdate()
    {
        transform.position = new Vector3((followX ? target.position.x : transform.position.x),
                                         (followY ? target.position.y + offsetY : transform.position.y),
                                         (followZ ? target.position.z : transform.position.z));

        // Capping the X position of the Camera with the Stage Data
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, stageData.CameraLimitMinX, stageData.CameraLimitMaxX);
        transform.position = position;
    }
}
