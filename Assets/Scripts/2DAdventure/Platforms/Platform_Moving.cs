using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Moving : Platform_Base
{
    private InterpolateBtwnStations itpl;
    
    public override void Setup()
    {
        itpl = GetComponentInParent<InterpolateBtwnStations>();

        itpl.StartInterpolation();
    }

    public override void UpdateCollision(Transform player)
    {
        if ( player.CompareTag("Player") )
        {
            player.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if ( collision.transform.CompareTag("Player") )
        {
            collision.transform.parent = null;
        }
    }
}
