using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_SawBlade : Obstacle_Base
{
    private InterpolateBtwnStations itpl;

    private void Awake()
    {
        itpl = GetComponentInParent<InterpolateBtwnStations>();

        itpl.StartInterpolation();
    }
}
