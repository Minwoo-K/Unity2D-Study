using System;
using UnityEngine;

[Serializable]
public struct BackgroundData
{
    public MeshRenderer background;
    public float        offsetSpeed;
}

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    private Transform           targetCamera;
    [SerializeField]
    private BackgroundData      backgroundCloud;
    [SerializeField]
    private BackgroundData[]    backgrounds;

    private void Update()
    {
        // Background Cloud: moves continously
        float offsetX = Time.time * backgroundCloud.offsetSpeed;
        backgroundCloud.background.material.mainTextureOffset = new Vector2(offsetX, 0);

        // Other Backgrounds: moves based on the targetted Camera's movement
        for ( int i = 0; i < backgrounds.Length; i++ )
        {
            float x = targetCamera.position.x * backgrounds[i].offsetSpeed;
            backgrounds[i].background.material.mainTextureOffset = new Vector2(x, 0);
        }
    }
}
