using UnityEngine;

public class CameraOnTarget : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private bool followX, followY, followZ;

    private float offsetY;

    private void Awake()
    {
        offsetY = Mathf.Abs(transform.position.y - target.position.y);
    }

    private void LateUpdate()
    {
        transform.position = new Vector3((followX ? target.position.x : transform.position.x),
                                         (followY ? target.position.y + offsetY : transform.position.y),
                                         (followZ ? target.position.z : transform.position.z));

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, stageData.CameraLimitMinX, stageData.CameraLimitMaxX);
        transform.position = position;
    }
}
