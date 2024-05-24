using System;
using UnityEngine;

[Serializable]
public struct BackgroundData
{
    public Renderer renderer;
    public float offsetSpeed;
}

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    private BackgroundData      cloudBackground;
    [SerializeField]
    private BackgroundData[]    backgrounds;
    [SerializeField]
    private Transform           targetCamera;

    private float targetStartX;

    private void Awake()
    {
        targetStartX = targetCamera.position.x;    
    }

    private void Update()
    {
        // Cloud
        float offsetX = cloudBackground.offsetSpeed * Time.time;
        cloudBackground.renderer.material.mainTextureOffset = new Vector2(offsetX, 0);

        if ( targetCamera == null ) return;

        float x = targetCamera.position.x - targetStartX;

        for ( int i = 0; i < backgrounds.Length; i++ )
        {
            float offset = x * backgrounds[i].offsetSpeed;
            backgrounds[i].renderer.material.mainTextureOffset = new Vector2(offset, 0);
        }
    }
}
