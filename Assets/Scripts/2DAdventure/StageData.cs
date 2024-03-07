using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    [Header("Stage Level")]
    [SerializeField]
    private int stageLevel;

    [Header("Player Movement Range")]
    [SerializeField]
    private float minPlayerLimitX;
    [SerializeField]
    private float maxPlayerLimitX;

    [Header("Camera Movement Range")]
    [SerializeField]
    private float minCameraLimitX;
    [SerializeField]
    private float maxCameraLimitX;

    [Header("Map Limit")]
    [SerializeField]
    private float minMapLimitX;

    public int   StageLevel      => stageLevel;
    public float MinPlayerLimitX => minPlayerLimitX;
    public float MaxPlayerLimitX => maxPlayerLimitX;
    public float MinCameraLimitX => minCameraLimitX;
    public float MaxCameraLimitX => maxCameraLimitX;
    public float MinMapLimitX    => minMapLimitX;
}

