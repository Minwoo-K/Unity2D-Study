using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Base : MonoBehaviour
{
    [SerializeField]
    protected bool instantKill;

    private void Awake()
    {
        Setup();
    }

    public virtual void Setup()
    {

    }
}
