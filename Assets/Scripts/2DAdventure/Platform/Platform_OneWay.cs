using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_OneWay : Platform_Base
{
    private PlatformEffector2D effector;

    public override void Setup()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    public override void UponCollision(GameObject player)
    {
        if ( Input.GetKeyDown(KeyCode.DownArrow) )
        {
            StartCoroutine(DownWay());
        }
    }

    private IEnumerator DownWay()
    {
        float standby = 0.5f;

        effector.rotationalOffset = 180;

        yield return new WaitForSeconds(standby);

        effector.rotationalOffset = 0;
    }
}

