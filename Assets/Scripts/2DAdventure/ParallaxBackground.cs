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
    [SerializeField]
    private float               basicSpeed;

    private void Update()
    {
        float offsetX = Time.time * backgroundCloud.offsetSpeed;
        backgroundCloud.background.material.mainTextureOffset = new Vector2(offsetX, 0);
    }
}
