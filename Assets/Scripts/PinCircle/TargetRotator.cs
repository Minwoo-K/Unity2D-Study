using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PinCircle
{
    public class TargetRotator : MonoBehaviour
    {
        [SerializeField]
        private float rotateSpeed;
        private Vector3 direction = Vector3.forward;

        private void Update()
        {
            transform.Rotate(direction * rotateSpeed * Time.deltaTime);
        }

        public void SetRotationSpeed(float speed)
        {
            rotateSpeed = speed;
        }

        public void Clear()
        {
            SetRotationSpeed(0);
        }
    }
}
