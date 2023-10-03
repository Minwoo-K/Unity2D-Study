using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Transform target;   // The Target to cpature

        private float distance;     // Distance value between the target and the given camera

        private void Start()
        {
            // Get the Distance from the target to the Camera
            distance = (target.position - transform.position).magnitude;
        }

        private void LateUpdate()
        {
            // if No target, do nothing
            if ( target == null ) return;

            // Based on the target's position, the camera follows it with the distance
            // "transform.rotation" is the direction Vector
            transform.position = target.position + transform.rotation * new Vector3(0, 0, -distance);
        }
    }
}
