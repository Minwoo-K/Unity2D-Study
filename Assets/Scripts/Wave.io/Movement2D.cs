using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [Header("Horizontal Movement")]
    [SerializeField]
    private float xRange;
    [SerializeField]
    private float xSpeed;
    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        MoveInX();    
    }

    public void MoveInX()
    {
        float x = startPosition.x + xRange * Mathf.Sin(xSpeed * Time.time);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
