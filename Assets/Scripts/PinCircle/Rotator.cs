using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;

    private Vector3 direction = Vector3.forward; // Rotation Direction

    void Update()
    {
        transform.Rotate(direction * rotationSpeed * Time.deltaTime);
    }
}
