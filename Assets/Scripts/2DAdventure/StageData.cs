using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    [Header("Player Settings")]
    [SerializeField]
    private float maxPlayerLimitX;
    [SerializeField]
    private float minPlayerLimitX;

    [Header("Camera Settings")]
    [SerializeField]
    private float maxCameraLimitX;
    [SerializeField]
    private float minCameraLimitX;
    
    [Header("Map Settings")]
    [SerializeField]
    private float maxMapLimitY; 

    public float MaxPlayerLimitX => maxPlayerLimitX;
    public float MinPlayerLimitX => minPlayerLimitX;
    public float MaxCameraLimitX => maxCameraLimitX;
    public float MinCameraLimitX => minCameraLimitX;
}
