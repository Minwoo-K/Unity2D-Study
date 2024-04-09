using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Moving : Platform_Base
{
    public override void Setup()
    {
        
    }

    public override void UponCollision(GameObject player)
    {
        if ( player.CompareTag("Player") )
        {
            player.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if ( collision.gameObject.CompareTag("Player") )
        {
            collision.transform.parent = null;
        }
    }
}
