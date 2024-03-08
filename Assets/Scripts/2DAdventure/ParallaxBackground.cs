using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BackgroundData
{
    public Renderer renderer;
    public float    offsetSpeed;
}

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    private Transform           anchorCamera;
    [SerializeField]
    private BackgroundData[]    backgrounds;
    [SerializeField]
    private BackgroundData      backgroundCloud;

    private float               cameraStartPosX; // As backgrounds move proportionally to the anchorCamera

    private void Awake()
    {
        cameraStartPosX = anchorCamera.position.x;
    }

    private void Update()
    {
        float offsetX = Time.time * backgroundCloud.offsetSpeed;
        backgroundCloud.renderer.material.mainTextureOffset = new Vector2(offsetX, 0);

        if ( anchorCamera == null ) return;

        float cameraMoved = anchorCamera.position.x - cameraStartPosX;
        for ( int i = 0; i < backgrounds.Length; i++ )
        {
            float x = cameraMoved * backgrounds[i].offsetSpeed;
            backgrounds[i].renderer.material.mainTextureOffset = new Vector2(x, 0);
        }
    }
}
