using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Transform target;   // The Target to follow

        private float distance;     // Distance between the target and the Camera

        private void Start()
        {
            // Calculate the distance in the Start
            distance = (target.position - transform.position).magnitude;
        }

        private void LateUpdate()
        {
            // Update Camera's position based on the distance and direction
            transform.position = target.position + transform.rotation * new Vector3(0, 0, -distance);
        }
    }
}
