using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAToB : MonoBehaviour
{
    [SerializeField]
    private Transform   target;
    [SerializeField]
    private float       rotateSpeed;
    [SerializeField]
    private float       rotateAngle;

    private void Update()
    {
        float z = rotateAngle * Mathf.Sin(Time.time * rotateSpeed);
        target.rotation = Quaternion.Euler(0, 0, z);
    }
}
