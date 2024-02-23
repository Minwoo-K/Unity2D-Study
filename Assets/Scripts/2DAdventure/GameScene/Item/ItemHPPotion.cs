using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class ItemHPPotion : ItemBase
    {
        public override void UpdateItemTaken(Transform transform)
        {
            transform.GetComponent<PlayerHP>().IncreaseHP();
        }
    }
}

