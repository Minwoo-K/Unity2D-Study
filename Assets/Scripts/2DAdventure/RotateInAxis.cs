using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInAxis : MonoBehaviour
{
    [SerializeField]
    private Vector3 direction = Vector3.back;
    [SerializeField]
    private float   rotateSpeed;

    private void Update()
    {
        transform.Rotate(direction * rotateSpeed * Time.deltaTime);
    }
}
