using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    [Header("Camera Constraints")]
    [SerializeField]
    private float cameraLimitMinX;
    [SerializeField]
    private float cameraLimitMaxX;

    [Header("Player Constraints")]
    [SerializeField]
    private float playerLimitMinX;
    [SerializeField]
    private float playerLimitMaxX;

    [Header("Map Constraints")]
    [SerializeField]
    private float mapLimitMinY;

    // Properties to each one above to let exterior access to them
    public float CameraLimitMinX => cameraLimitMinX;
    public float CameraLimitMaxX => cameraLimitMaxX;
    public float PlayerLimitMinX => playerLimitMinX;
    public float PlayerLimitMaxX => playerLimitMaxX;
    public float MapLimitMinY    => mapLimitMinY;
}
