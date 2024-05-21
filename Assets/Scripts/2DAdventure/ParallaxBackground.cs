using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BackgroundData
{
    public MeshRenderer renderer;
    public float offsetSpeed;
}

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    private BackgroundData      cloud;
    [SerializeField]
    private BackgroundData[]    backgrounds;

    private void Update()
    {
        float offsetX = cloud.offsetSpeed * Time.time;
        cloud.renderer.material.mainTextureOffset = new Vector2(offsetX, 0);
    }
}
