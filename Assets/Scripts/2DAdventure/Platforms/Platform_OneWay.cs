using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_OneWay : MonoBehaviour
{
    private PlatformEffector2D effector;

    public void Awake()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    public void UpdateCollision(Transform player)
    {
        if ( player.CompareTag("Player") )
        {
            effector.rotationalOffset = 180;
            Invoke("Reset", 1f);
        }
    }

    private void Reset()
    {
        effector.rotationalOffset = 0;
    }
}
