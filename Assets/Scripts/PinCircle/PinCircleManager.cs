using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCircleManager : MonoBehaviour
{
    [SerializeField]
    private PinSpawner pinSpawner;

    //private float pinAngle = 270;

    void Start()
    {
        
    }

    void Update()
    {
        if ( Input.GetMouseButtonDown(0) )
        {
            pinSpawner.ThrowPin();
        }
    }

    public void ThrowPin()
    {

    }
}
