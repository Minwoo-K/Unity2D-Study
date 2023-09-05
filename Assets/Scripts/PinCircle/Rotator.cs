using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    private Vector3 direction = Vector3.forward;

    void Update()
    {
        transform.Rotate(direction * rotateSpeed * Time.deltaTime);
    }
}
