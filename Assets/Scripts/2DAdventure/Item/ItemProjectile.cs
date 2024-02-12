using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class ItemProjectile : ItemBase
    {
        public override void UpdateItemTaken(Transform transform)
        {
            transform.GetComponent<PlayerData>().CurrentProjectile ++;
        }
    }
}

