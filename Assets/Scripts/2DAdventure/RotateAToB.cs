using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAToB : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float rotateAngle;

    private void Update()
    {
        float angleZ = rotateAngle * Mathf.Sin(Time.time * rotateSpeed);

        transform.rotation = Quaternion.Euler(new Vector3 (0, 0, angleZ));
    }
}
