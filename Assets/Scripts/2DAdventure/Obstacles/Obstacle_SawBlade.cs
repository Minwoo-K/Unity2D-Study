using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_SawBlade : MonoBehaviour
{
    private InterpolateBtwnStations itpl;

    private void Awake()
    {
        itpl = GetComponent<InterpolateBtwnStations>();

        itpl.StartInterpolation();
    }
}
