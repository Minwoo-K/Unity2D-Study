using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Drop : Platform_Base
{
    [SerializeField]
    private bool respawn = true;
    
    private float respawnTime = 2f;
    private Vector3 startPosition;

    public override void SetUp()
    {
        startPosition = transform.position;
    }

    public override void UponCollision(GameObject player)
    {
        
    }

    private IEnumerator ShakeAndDrop()
    {
        // Shaking Parameters/Configuration
        float shakeTime = 2f, shakeAngle = 5f, shakeIntensity = 0.2f, timer = 0;

        while ( timer < shakeTime )
        {
            timer += Time.deltaTime / shakeTime;

            float z = Mathf.Lerp(-shakeAngle, shakeAngle, Mathf.PingPong(Time.time * shakeIntensity, 1));
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, z));

            yield return null;
        }

        yield return StartCoroutine(DropAndReset());
    }

    private IEnumerator DropAndReset()
    {
        yield return null;
    }
}
