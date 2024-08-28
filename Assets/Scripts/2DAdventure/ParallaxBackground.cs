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

    private float             startX;

    private void Awake()
    {
        startX = targetCamera.position.x;
    }

    private void Update()
    {
        // backgroundCloud moves continuously alone
        backgroundCloud.background.material.mainTextureOffset = new Vector2(backgroundCloud.moveSpeed * Time.time, 0);

        // Other Backgrounds move proportional to the targetCamera moving
        for ( int i = 0; i < backgrounds.Length; i++ )
        {
            float offsetX = (targetCamera.position.x - startX);
            backgrounds[i].background.material.mainTextureOffset = new Vector2(offsetX * backgrounds[i].moveSpeed, 0);
        }
    }
}
