using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platform_Base : MonoBehaviour
{
    private void Awake()
    {
        Setup();
    }

    public abstract void Setup();

    public abstract void UponCollision(GameObject player);
}
