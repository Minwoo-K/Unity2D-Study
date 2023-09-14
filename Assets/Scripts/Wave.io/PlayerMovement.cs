using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("X axis Movement")]
    [SerializeField]
    private float xSpeed;           // Speed for X axis
    [SerializeField]
    private float xRange;           // The Range in X axis to move

    private Vector3 startPosition;  // The Starting Position

    [Header("Y axis Movement")]
    [SerializeField]
    private float ySpeed;           // Speed for Y axis
    private Rigidbody2D rigidBody;  // Rigidbody to use AddForce

    private void Awake()
    {
        startPosition = transform.position;     // Initialize by saving the starting position
        rigidBody = GetComponent<Rigidbody2D>();// Fetch the Rigidbody2D component
    }

    public void MoveInX()
    {
        // Time.time always increases over time that makes the Sin value to change from 1 ~ -1
        // Multiplying by xRange expands the max & min values
        float x = startPosition.x + xRange * Mathf.Sin(xSpeed * Time.time);
        // Set the x value
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public void MoveUpY()
    {
        // Add force onto the rigidbody for the Position to move up
        rigidBody.AddForce(transform.up * ySpeed, ForceMode2D.Impulse);
    }
}
