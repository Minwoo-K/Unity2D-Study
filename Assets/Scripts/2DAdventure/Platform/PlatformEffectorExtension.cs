using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEffectorExtension : MonoBehaviour
{
    private PlatformEffector2D effector;

    private void Awake()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    public void OnDownWay()
    {
        effector.rotationalOffset = 180;

        Invoke(nameof(Reset), 0.5f);
    }

    public void Reset()
    {
        effector.rotationalOffset = 0;
    }
}
