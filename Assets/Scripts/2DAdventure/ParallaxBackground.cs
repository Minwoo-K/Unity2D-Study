using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct BackgroundData
{
    public Renderer     background;
    public float        moveSpeed;
}

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    private Transform              targetCamera;
    [SerializeField]
    private BackgroundData      backgroundCloud;
    [SerializeField]
    private BackgroundData[]    backgrounds;

    private float cameraStartX;

    private void Awake()
    {
        cameraStartX = targetCamera.position.x;
    }

    private void Update()
    {
        // Cloud moves the same direction at all times proportional to the realtime.
        float cloudOffset = Time.time * backgroundCloud.moveSpeed;
        backgroundCloud.background.material.mainTextureOffset = new Vector2(cloudOffset, 0);

        if ( targetCamera == null ) return;

        // Other Backgrounds move related to the Target Camera moving
        float x = targetCamera.position.x - cameraStartX;
        for ( int i = 0; i < backgrounds.Length; i++ )
        {
            float offset = x * backgrounds[i].moveSpeed;
            backgrounds[i].background.material.mainTextureOffset = new Vector2(offset, 0);
        }
    }
}
