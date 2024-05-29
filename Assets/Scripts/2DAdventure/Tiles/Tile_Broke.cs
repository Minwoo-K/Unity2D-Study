using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Broke : Tile_Base
{
    [SerializeField]
    private ParticleSystem tileBreakEffect;

    public override void UpdateCollision()
    {
        base.UpdateCollision();

        if ( IsHit ) return;

        IsHit = true;

        Instantiate(tileBreakEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
