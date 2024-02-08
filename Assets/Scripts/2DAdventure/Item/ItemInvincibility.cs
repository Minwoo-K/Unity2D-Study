using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInvincibility : ItemBase
{
    [SerializeField]
    private float validTime = 3;

    public override void UpdateItemTaken(Transform transform)
    {
        transform.GetComponent<PlayerHP>().TurnOnInvincible(validTime);
    }
}
