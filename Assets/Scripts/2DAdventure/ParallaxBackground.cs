using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BackgroundData
{
    public Renderer renderer;
    public float    speed;
}

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    private Transform targetCamera;
    [SerializeField]
    private BackgroundData[] backgrounds;
    [SerializeField]
    private BackgroundData backgroundCloud;

    private float targetStartX;

    private void Awake()
    {
        targetStartX = targetCamera.position.x;
    }

    private void Update()
    {
        // Cloud moves regardless of where the Player/Camera is
        float offset = Time.time * backgroundCloud.speed;
        backgroundCloud.renderer.material.mainTextureOffset = new Vector2(offset, 0);

        // if No targetCamera, the code below shouldn't run
        if ( targetCamera == null ) return;

        // Other backgrounds move proportionally to the Target Camera's position
        float directionX = targetCamera.position.x - targetStartX;
        for ( int i = 0; i < backgrounds.Length; i++ )
        {
            backgrounds[i].renderer.material.mainTextureOffset = new Vector2(directionX * backgrounds[i].speed, 0);
        }
    }
}


