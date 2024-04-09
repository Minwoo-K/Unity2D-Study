using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInAxis : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private Vector3 rotateDirection = Vector3.forward;

    private void Update()
    {
        transform.Rotate(rotateDirection, rotateSpeed * Time.deltaTime);
    }
}
