using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Waveio
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        [SerializeField]
        private float yOffset;
        [SerializeField]
        private float smoothTime;
        private Vector3 velocity;

        private void FixedUpdate()
        {
            // World Position = TransformPoint(LocalPosition)
            Vector3 targetWorldPosition = target.TransformPoint(new Vector3(0, yOffset, -10));

            targetWorldPosition = new Vector3(0, targetWorldPosition.y, targetWorldPosition.z);

            transform.position = Vector3.SmoothDamp(transform.position, targetWorldPosition, ref velocity, smoothTime);
        }
    }
}
