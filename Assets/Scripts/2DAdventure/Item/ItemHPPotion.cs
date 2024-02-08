using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHPPotion : ItemBase
{
    public override void UpdateItemTaken(Transform transform)
    {
        transform.GetComponent<PlayerHP>().IncreaseHP();
    }
}
