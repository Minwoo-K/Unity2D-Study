using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BackgroundData
{
    public Renderer     background;
    public float        speed;
}

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    private Transform           targetCamera;
    [SerializeField]
    private BackgroundData[]    backgrounds;
    [SerializeField]
    private BackgroundData      backgroundCloud;

    private float               cameraStartX;

    private void Awake()
    {
        cameraStartX = targetCamera.position.x;
    }

    private void Update()
    {
        // Defining the Cloud's scrolling with the Time, irrelevent to the Camera's position
        float cloudOffset = Time.time * backgroundCloud.speed;
        backgroundCloud.background.material.mainTextureOffset = new Vector2(cloudOffset, 0);

        // Other backgrounds scrolling based on the Camera's position
        float x = targetCamera.position.x - cameraStartX;
        for ( int i = 0; i < backgrounds.Length; i++ )
        {
            float offset = x * backgrounds[i].speed;
            backgrounds[i].background.material.mainTextureOffset = new Vector2(offset, 0);
        }
    }
}
