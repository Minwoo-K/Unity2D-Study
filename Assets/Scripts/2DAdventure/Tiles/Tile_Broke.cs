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
    }
}
