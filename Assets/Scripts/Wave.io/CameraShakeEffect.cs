using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeEffect : MonoBehaviour
{
    private static CameraShakeEffect instance;

    public static CameraShakeEffect Instance => instance;

    private float shakeIntensity = 0.1f;
    private float shakeTime = 0.1f;

    private CameraShakeEffect()
    {
        instance = this;
    }

    public void ShakeCamera(float shakeIntensity = 0.1f, float shakeTime = 0.1f)
    {
        this.shakeIntensity = shakeIntensity;
        this.shakeTime = shakeTime;

        StopCoroutine(ShakeByRotation());
        StartCoroutine(ShakeByRotation());
    }

    private IEnumerator ShakeByRotation()
    {
        Vector3 startRotation = transform.eulerAngles;

        float power = 10f;

        while ( shakeTime > 0 )
        {
            float x = 0;
            float y = 0;
            float z = Random.Range(-1f, 1f);

            transform.rotation = Quaternion.Euler(startRotation + new Vector3(x, y, z) * shakeIntensity * power);

            shakeTime -= Time.deltaTime;

            yield return null;
        }

        transform.rotation = Quaternion.Euler(startRotation);
    }
}
