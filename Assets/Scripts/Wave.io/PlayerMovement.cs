using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("X axis Movement")]
    [SerializeField]
    private float xSpeed;
    [SerializeField]
    private float xRange;

    private Vector3 startPosition;

    [Header("Y axis Movement")]
    [SerializeField]
    private float ySpeed;
    [SerializeField]
    private float yRange;

    private void Awake()
    {
        startPosition = transform.position;
    }

    public void MoveInX()
    {
        float x = startPosition.x + xRange * Mathf.Sin(xSpeed * Time.time);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public void MoveInY()
    {
        float y = startPosition.y + yRange * Mathf.Cos(ySpeed * Time.time);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
