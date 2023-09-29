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
        private Vector3 captureOffset = new Vector3(0, 8, -10);
        [SerializeField]
        private float smoothTime;

        private Vector3 velocity = Vector3.zero;
        private Camera mainCamera = null;
        private Color initialBackgroundColor;

        private void Start()
        {
            mainCamera = GetComponent<Camera>();
            initialBackgroundColor = mainCamera.backgroundColor;
        }

        private void FixedUpdate()
        {
            // To get a position value for the camera, BASED ON the target's position
            // -> target is (standard) | TransformPoint(captureOffset) is the local position for camera with the offset position
            Vector3 capturePosition = target.TransformPoint(captureOffset);
            capturePosition.x = 0;
            transform.position = Vector3.SmoothDamp(transform.position, capturePosition, ref velocity, smoothTime);
        }

        public void ChangeBackgroundColour()
        {
            float hue = Random.Range(0, 10);
            hue *= 0.1f;

            mainCamera.backgroundColor = Color.HSVToRGB(hue, 0.6f, 0.8f);
        }

        public void Reset()
        {
            mainCamera.backgroundColor = initialBackgroundColor;
        }
    }
}
