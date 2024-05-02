using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    [Header("Player Limit")]
    [SerializeField]
    private float playerMinLimitX;
    [SerializeField]
    private float playerMaxLimitX;

    [Header("Camera Limit")]
    [SerializeField]
    private float cameraMinLimitX;
    [SerializeField]
    private float cameraMaxLimitX;

    [Header("Map")]
    [SerializeField]
    private float mapMinLimitY;

    // Properties
    public float PlayerMinLimitX => playerMinLimitX;
    public float PlayerMaxLimitX => playerMaxLimitX;
    public float CameraMinLimitX => cameraMinLimitX;
    public float CameraMaxLimitX => cameraMaxLimitX;
    public float MapMinLimitY    => mapMinLimitY;
}
