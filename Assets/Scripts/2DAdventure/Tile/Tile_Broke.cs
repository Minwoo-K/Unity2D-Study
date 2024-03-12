using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Broke : Tile_Base
{
    [Header("Tile_Broke")]
    [SerializeField]
    private GameObject tileBreakEffect;

    public override void Setup()
    {
        
    }

    public override void UponCollision()
    {
        base.UponCollision();

        Instantiate(tileBreakEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
