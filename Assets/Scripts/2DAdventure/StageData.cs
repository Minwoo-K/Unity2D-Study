using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    [Header("Player Settings")]
    [SerializeField]
    private float playerMinX;
    [SerializeField]
    private float playerMaxX;
    
    [Header("Camera Settings")]
    [SerializeField]
    private float cameraMinX;
    [SerializeField]
    private float cameraMaxX;

    [Header("Other Settings")]
    [SerializeField]
    private float mapMinY;

    // Properties
    public float PlayerMinX => playerMinX;
    public float PlayerMaxX => PlayerMaxX;
    public float CameraMinX => cameraMinX;
    public float CameraMaxX => cameraMaxX;
    public float MapMinY    => mapMinY;
}
