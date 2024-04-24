using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMovement2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Vector3 direction = Vector3.zero;

    private void Update()
    {
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }
}
