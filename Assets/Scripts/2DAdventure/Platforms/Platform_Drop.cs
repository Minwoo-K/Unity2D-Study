using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Drop : Platform_Base
{
    [SerializeField]
    private float fallingTime;
    [SerializeField]
    private bool respawn;

    public override void UpdateCollision(Transform player)
    {
        if ( player.CompareTag("Player") )
        {
            StartCoroutine(ShakeOn());
        }
    }

    private IEnumerator ShakeOn()
    {
        float shakeTime = 3f, shakeAngle = 10f, shakeIntensity = 0.8f, shakeSpeed = 12f, percent = 0;

        while ( percent < 1 )
        {
            percent += Time.deltaTime / shakeTime;

            float z = Mathf.Lerp(-shakeAngle, shakeAngle, Mathf.PingPong(shakeSpeed * shakeIntensity * Time.time, 1));

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, z));

            yield return null;
        }
    }
}
