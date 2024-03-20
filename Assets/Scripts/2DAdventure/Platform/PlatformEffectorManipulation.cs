using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEffectorManipulation : MonoBehaviour
{
    private PlatformEffector2D platformEffector;

    private void Awake()
    {
        platformEffector = GetComponent<PlatformEffector2D>();
    }
    
    public void OnDownThrough()
    {
        StartCoroutine(DownThrough());
    }

    private IEnumerator DownThrough()
    {
        platformEffector.rotationalOffset = 180;

        yield return new WaitForSeconds(0.5f);

        platformEffector.rotationalOffset = 0;
    }
}
