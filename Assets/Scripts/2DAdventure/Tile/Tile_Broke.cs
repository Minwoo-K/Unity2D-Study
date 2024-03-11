using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Broke : Tile_Base
{
    [Header("Tile Broke")]
    [SerializeField]
    private GameObject tileBrokeEffect;

    public override void Setup()
    {
        
    }

    public override void UponCollision()
    {
        if ( Hit ) return;

        Hit = true;

        Instantiate(tileBrokeEffect, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
    }
}
