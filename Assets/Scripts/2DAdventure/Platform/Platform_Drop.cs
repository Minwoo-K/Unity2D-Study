using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Drop : Platform_Base
{
    [SerializeField]
    private bool respawn;
    [SerializeField]
    private float respawningTime;
    [SerializeField]
    private float shakingTime, shakingAngle, shakingSpeed;

    private Vector3 startPosition;
    private Rigidbody2D rigid2D;
    private BoxCollider2D boxCollider;

    public override void Setup()
    {
        startPosition = transform.position;
        rigid2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public override void UponCollision(GameObject player)
    {
        shakingTime = 0.5f;
        shakingAngle = 5f;
        shakingSpeed = 0.3f;

        StartCoroutine(ShakeOn(shakingTime, shakingAngle, shakingSpeed));
    }

    private IEnumerator ShakeOn(float shakingTime, float shakingAngle, float shakingSpeed)
    {
        float percent = 0;

        while ( percent < 1 )
        {
            percent += Time.deltaTime / shakingTime;

            float z = Mathf.Lerp(-shakingAngle, shakingAngle, Mathf.PingPong(Time.time * shakingSpeed, 1));
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, z));

            yield return null;
        }

        transform.rotation = Quaternion.identity;

        Drop();
    }

    private void Drop()
    {
        boxCollider.enabled = false;
        rigid2D.isKinematic = false;
        Invoke("Reset", respawningTime);
    }

    private void Reset()
    {
        rigid2D.velocity = Vector2.zero;
        rigid2D.isKinematic = true;
        boxCollider.enabled = true;
        transform.position = startPosition;

        if ( !respawn ) gameObject.SetActive(false);
    }
}
