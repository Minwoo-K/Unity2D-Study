using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBase : MonoBehaviour
{
    public virtual void UpdateCollsion()
    {
        Debug.Log($"Collide with {gameObject.name}!");
    }
}
