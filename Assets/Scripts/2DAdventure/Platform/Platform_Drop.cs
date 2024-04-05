using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Drop : Platform_Base
{
    [SerializeField]
    private bool respawn = false;
    [SerializeField]
    private float timeToRespawn = 3f;

    private Rigidbody2D rigid2D;
    private BoxCollider2D boxCollider;
    private Vector3 startPosition;

    public bool IsHit { get; private set; } = false;

    public override void Setup()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        startPosition = transform.position;
    }

    public override void UponCollision(GameObject player)
    {
        if ( ! player.CompareTag("Player") || IsHit ) return;
        
        IsHit = true;

        float shakingTime = 1f, shakingAngle = 5f, shakingSpeed = 10f;
        StartCoroutine(ShakeOn(shakingTime, shakingAngle, shakingSpeed));
    }

    private IEnumerator ShakeOn(float shakeTime, float shakeAngle, float shakeSpeed)
    {
        float percent = 0;

        while ( percent < 1 )
        {
            percent += Time.deltaTime / shakeTime;

            float z = Mathf.Lerp(-shakeAngle, shakeAngle, Mathf.PingPong(Time.time * shakeSpeed, 1));
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, z));

            yield return null;
        }

        transform.rotation = Quaternion.identity;

        Drop();
    }

    private void Drop()
    {
        rigid2D.isKinematic = false;
        boxCollider.enabled = false;
        Invoke(nameof(Reset), timeToRespawn);
    }

    private void Reset()
    {
        if ( respawn == false ) Destroy(gameObject);
        else
        {
            rigid2D.isKinematic = true;
            boxCollider.enabled = true;
            rigid2D.velocity = Vector2.zero;
            transform.position = startPosition;
            IsHit = false;
        }
    }
}
