using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class RotateBetweenAandB : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        [SerializeField]
        private float rotateAngle = 40;
        [SerializeField]
        private float rotateSpeed;

        private void Update()
        {
            float angle = rotateAngle * Mathf.Sin(Time.time * rotateSpeed);

            target.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
