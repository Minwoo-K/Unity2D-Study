using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTransform2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Vector3 direction;

    private void Update()
    {
        transform.position += moveSpeed * direction * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        this.direction = direction;
    }
}
