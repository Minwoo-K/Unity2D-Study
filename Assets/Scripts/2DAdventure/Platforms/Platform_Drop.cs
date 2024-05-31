using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Drop : Platform_Base
{
    [SerializeField]
    private float fallingTime;
    [SerializeField]
    private bool respawn;

    private Rigidbody2D rigid2D;
    private Vector3 startPosition;

    public override void Setup()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    public override void UpdateCollision(Transform player)
    {
        if ( player.CompareTag("Player") )
        {
            StartCoroutine(ShakeOn());
        }
    }

    private IEnumerator ShakeOn()
    {
        float shakeTime = 2f, shakeAngle = 10f, shakeIntensity = 0.8f, shakeSpeed = 25f, percent = 0;

        while ( percent < 1 )
        {
            percent += Time.deltaTime / shakeTime;

            float z = Mathf.Lerp(-shakeAngle, shakeAngle, Mathf.PingPong(shakeSpeed * shakeIntensity * Time.time, 1));

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, z));

            yield return null;
        }

        yield return StartCoroutine(Drop());
    }

    private IEnumerator Drop()
    {
        transform.rotation = Quaternion.identity;
        rigid2D.isKinematic = false;

        yield return new WaitForSeconds(fallingTime);

        if ( respawn )
        {
            rigid2D.isKinematic = true;
            rigid2D.velocity = Vector2.zero;
            transform.position = startPosition;
        }
        else
        {
            rigid2D.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }

}
