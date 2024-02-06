using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInAxis : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 axis = Vector3.forward;
    [SerializeField]
    private float rotateSpeed = 200;

    private void Update()
    {
        target.Rotate(Time.deltaTime * axis * rotateSpeed);
    }
}
