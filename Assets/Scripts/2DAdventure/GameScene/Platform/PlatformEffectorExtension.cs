using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class PlatformEffectorExtension : MonoBehaviour
    {
        private PlatformEffector2D effector;

        private void Awake()
        {
            effector = GetComponent<PlatformEffector2D>();
        }

        public void OnDownWay()
        {
            StartCoroutine(ReverseRotationalOffset());
        }

        private IEnumerator ReverseRotationalOffset()
        {
            effector.rotationalOffset = 180;

            yield return new WaitForSeconds(0.5f);

            effector.rotationalOffset = 0;
        }
    }
}
