using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    // Variables
    [Header("Player Movement Range")]
    [SerializeField]
    private float playerMinX;
    [SerializeField]
    private float playerMaxX;
    [Header("Camera Movement Range")]
    [SerializeField]
    private float cameraMinX;
    [SerializeField]
    private float cameraMaxX;
    [Header("Map Range")]
    [SerializeField]
    private float mapMinY;

    // Properties
    public float PlayerMinX => playerMinX;
    public float PlayerMaxX => playerMaxX;
    public float CameraMinX => cameraMinX;
    public float CameraMaxX => cameraMaxX;
    public float MapMinY => mapMinY;
}
