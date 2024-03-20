using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Drop : Platform_Base
{
    [SerializeField]
    private bool respawn = true;
    
    private float respawnTime = 2f;
    private Rigidbody2D rigid2D;
    private Vector3 startPosition;
    
    public override void SetUp()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    public override void UponCollision(GameObject player)
    {
        if ( hasCollided ) return;

        hasCollided = true;

        StartCoroutine(ShakeAndDrop());
    }

    private IEnumerator ShakeAndDrop()
    {
        // Shaking Parameters/Configuration
        float shakeTime = 1.5f, shakeAngle = 5f, shakeIntensity = 8f, timer = 0;

        while ( timer < shakeTime )
        {
            timer += Time.deltaTime / shakeTime;

            float z = Mathf.Lerp(-shakeAngle, shakeAngle, Mathf.PingPong(Time.time * shakeIntensity, 1));
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, z));

            yield return null;
        }

        DropAndReset();
    }

    private void DropAndReset()
    {
        // Drop
        rigid2D.isKinematic = false;

        if ( respawn )
        {
            Invoke(nameof(Reset), respawnTime);
        }
        else
        {
            Destroy(gameObject, respawnTime);
        }
    }

    private void Reset()
    {
        rigid2D.isKinematic = true;
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        rigid2D.velocity = Vector3.zero;
        hasCollided = false;
    }
}
