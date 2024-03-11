using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Base : MonoBehaviour
{
    public virtual void UponCollision()
    {
        Debug.Log($"Tile Collision with {name}");
    }
}