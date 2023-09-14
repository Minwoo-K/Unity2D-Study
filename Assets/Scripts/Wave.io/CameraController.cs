using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;   // Target Transform for the Camera to follow
    [SerializeField]
    private float yOffset;      // Offset value in Y axis as Camera needs to capture the target at bottom of the camera screen
    [SerializeField]
    private float smoothTime;   // Time to smoothly follow the target
    private Vector3 velocity = Vector3.zero; // The amount of the velocity changing (= the current velocity/speed)

    private void FixedUpdate()
    {
        // World Position == TransformPoint(localPosition);
        // Set the world position to maintain (0, yOffset, -10) in Local Position
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, yOffset, -10));
        targetPosition = new Vector3(0, targetPosition.y, targetPosition.z);

        // A Method when smoothly moving to the target/destination (The destination is the 2nd parameter)
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

}
