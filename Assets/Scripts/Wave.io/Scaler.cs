using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Waveio
{
    public class Scaler : MonoBehaviour
    {
        private Vector3 startScale;
        [SerializeField]
        private Vector3 endScale;
        [SerializeField]
        private float scaleTime;

        private IEnumerator Start()
        {
            startScale = transform.localScale;

            while ( true )
            {
                yield return StartCoroutine(Scale(startScale, endScale, scaleTime));

                yield return StartCoroutine(Scale(endScale, startScale, scaleTime));
            }
        }

        private IEnumerator Scale(Vector3 start, Vector3 end, float scaleTime)
        {
            float current = 0;
            float percent = 0;

            while ( percent < 1 )
            {
                current += Time.deltaTime;
                percent = current / scaleTime;

                transform.localScale = Vector3.Lerp(start, end, percent);

                yield return null;
            }
        }

    }
}
