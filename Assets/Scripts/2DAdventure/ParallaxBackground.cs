using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct BackgroundData
{
    public Renderer background;
    public float    moveSpeed;
}

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    private Transform           targetCamera;
    [SerializeField]
    private BackgroundData      backgroundCloud;
    [SerializeField]
    private BackgroundData[]    backgrounds;

    private Vector3             startPosition;

    private void Awake()
    {
        startPosition = targetCamera.position;
    }

    private void Update()
    {
        // backgroundCloud moves continuously alone
        backgroundCloud.background.material.mainTextureOffset = new Vector2(backgroundCloud.moveSpeed * Time.time, 0);
    }
}
