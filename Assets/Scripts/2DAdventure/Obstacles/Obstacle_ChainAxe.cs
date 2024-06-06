using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_ChainAxe : Obstacle_Base
{
    [SerializeField]
    private Transform nut;
    [SerializeField]
    private float swingingAngle;
    [SerializeField]
    private float swingingSpeed;

    private void Update()
    {
        float z = swingingAngle * Mathf.Sin(Time.time * swingingSpeed);
        
        nut.rotation = Quaternion.Euler(new Vector3(0, 0, z));
    }
}
