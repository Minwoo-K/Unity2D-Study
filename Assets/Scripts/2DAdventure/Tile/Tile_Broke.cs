using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Broke : Tile_Base
{
    [Header("Tile_Broke Component")]
    [SerializeField]
    private GameObject tileBreakingEffect;

    public override void UponCollision(GameObject player)
    {
        base.UponCollision(player);

        Instantiate(tileBreakingEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
