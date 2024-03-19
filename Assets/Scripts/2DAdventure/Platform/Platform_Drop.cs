using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Drop : Platform_Base
{
    [SerializeField]
    private bool  respawn;
    [SerializeField]
    private float shakeAngle;
    [SerializeField]
    private float shakingTime;
    [SerializeField]
    private float shakingSpeed;
    [SerializeField]
    private float respawnCoolTime;

    private Vector3     startPosition;
    private Rigidbody2D rigid2D;

    public override void Setup()
    {
        startPosition = transform.position;
        rigid2D = GetComponent<Rigidbody2D>();
    }

    public override void UponCollision()
    {
        if ( hasCollided ) return;

        hasCollided = true;

        StartCoroutine(ShakeAndDrop());
    }

    private IEnumerator ShakeAndDrop()
    {
        float percent = 0;

        while ( percent < 1 )
        {
            percent += Time.deltaTime / shakingTime;
            
            float z = Mathf.Lerp(-shakeAngle, shakeAngle, Mathf.PingPong(Time.time * shakingSpeed, 1));
            transform.rotation = Quaternion.Euler(0, 0, z);

            yield return null;
        }

        yield return StartCoroutine(DropAndRespawn());
    }

    private IEnumerator DropAndRespawn()
    {
        rigid2D.isKinematic = false;

        yield return new WaitForSeconds(respawnCoolTime);

        if ( respawn )
        {
            rigid2D.isKinematic = true;
            transform.position = startPosition;
            rigid2D.velocity = Vector3.zero;
            hasCollided = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
