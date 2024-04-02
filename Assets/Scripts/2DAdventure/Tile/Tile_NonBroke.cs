using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_NonBroke : Tile_Base
{
    public override void UponCollision(GameObject player)
    {
        base.UponCollision(player);

        Debug.Log($"Collided With {name}");
    }
}
