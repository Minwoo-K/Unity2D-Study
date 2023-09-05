using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCircleManager : MonoBehaviour
{
    [SerializeField]
    private PinSpawner pinSpawner;
    [SerializeField]
    private int numberOfThrowables;
    [SerializeField]
    private int numberOfStucks;


    private void Start()
    {
        pinSpawner.Setup(numberOfThrowables, numberOfStucks);
    }

    private void Update()
    {
        if ( Input.GetMouseButtonDown(0) && pinSpawner.throwablePins.Count != 0 )
        {

        }
    }
}

