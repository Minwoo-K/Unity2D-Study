using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public bool IsDead { protected set; get; } = false;

    public abstract void OnDie();
}
