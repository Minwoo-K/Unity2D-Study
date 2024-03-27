using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    [Header("Player Limits")]
    [SerializeField]
    private float playerMinX;
    [SerializeField]
    private float playerMaxX;

    [Header("Cameera Limits")]
    [SerializeField]
    private float cameraMinX;
    [SerializeField]
    private float cameraMaxX;

    [Header("Other Limits")]
    [SerializeField]
    private float mapMinY;

    // Properties
    public float PlayerMinX => playerMinX;
    public float PlayerMaxX => playerMaxX;
    public float CameraMinX => cameraMinX;
    public float CameraMaxX => cameraMaxX;
    public float MapMinY    => mapMinY;
}
