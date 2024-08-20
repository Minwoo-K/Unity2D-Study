using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    [Header("Player Movement Range")]
    [SerializeField]
    private float PlayerMinX;
    [SerializeField]
    private float PlayerMaxX;
    [Header("Camera Movement Range")]
    [SerializeField]
    private float CameraMinX;
    [SerializeField]
    private float CameraMaxX;
    [Header("Map Range")]
    [SerializeField]
    private float MapMinY;
}
