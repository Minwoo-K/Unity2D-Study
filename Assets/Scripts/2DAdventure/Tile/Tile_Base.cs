using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Base : MonoBehaviour
{
    public bool IsHit { get; protected set; } = false;

    public virtual void UponCollision(GameObject player)
    {
        if ( IsHit ) return;

        IsHit = true;
    }
}
