using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_NonBroke : Tile_Base
{
    public override void UponCollision()
    {
        base.UponCollision();

        Debug.Log($"Collided With {name}");
    }
}
