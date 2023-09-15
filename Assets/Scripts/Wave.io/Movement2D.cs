using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [Header("Horizontal(X axis) Movement")]
    [SerializeField]
    private float xRange;
    [SerializeField]
    private float xSpeed;
    private Vector3 startPosition;

    [Header("Vertical(Y axis) Movement")]
    [SerializeField]
    private float ySpeed;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        startPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveInX()
    {
        float x = startPosition.x + xRange * Mathf.Sin(xSpeed * Time.time);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public void MoveInY()
    {
        rigidbody.AddForce(Vector2.up * ySpeed, ForceMode2D.Impulse);
    }
}
