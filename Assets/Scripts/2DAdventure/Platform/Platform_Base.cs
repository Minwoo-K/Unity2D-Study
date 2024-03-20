using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platform_Base : MonoBehaviour
{
    protected bool hasCollided { get; set; } = false;

    private void Awake()
    {
        SetUp();
    }

    public abstract void SetUp();
    public abstract void UponCollision(GameObject player);
}
