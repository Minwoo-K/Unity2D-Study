using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBase : MonoBehaviour
{
    public virtual void UpdateCollsiion()
    {
        Debug.Log($"{gameObject.name} Tile Collision");
    }
}
