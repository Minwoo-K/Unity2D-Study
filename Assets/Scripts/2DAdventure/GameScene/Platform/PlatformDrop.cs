using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RespawnType { AfterTime, PlayerDead }

namespace Adventure_2D
{
    public class PlatformDrop : PlatformBase
    {
        [SerializeField]
        private RespawnType respawnType = RespawnType.AfterTime;
        [SerializeField]
        private float respawnTime = 2;

        private BoxCollider2D boxCollider;
        private Rigidbody2D rigid2D;
        private Vector3 originalPosition;

        private void Awake()
        {
            boxCollider = GetComponent<BoxCollider2D>();
            rigid2D = GetComponent<Rigidbody2D>();
            originalPosition = transform.position;
        }

        public override void UpdateCollision(GameObject other)
        {
            if ( IsHit ) return;

            IsHit = true;

            StartCoroutine(Process());
        }

        private void OnDrop()
        {
            boxCollider.enabled = false;
            rigid2D.isKinematic = false;
        }

        private IEnumerator Process()
        {
            yield return StartCoroutine(OnShake());

            OnDrop();

            if ( respawnType == RespawnType.AfterTime )
            {
                yield return StartCoroutine(OnRespawn());
            }
            else
            {
                Destroy(gameObject, respawnTime);
            }
        }

        private IEnumerator OnShake()
        {
            float percent = 0;
            float shakeAngle = 5;
            float shakeSpeed = 10;
            float shakeTime = 2;

            while ( percent < 1 )
            {
                percent += Time.deltaTime / shakeTime;

                float z = Mathf.Lerp(-shakeAngle, shakeAngle, Mathf.PingPong(Time.time * shakeSpeed, 1));
                transform.rotation = Quaternion.Euler(0, 0, z);

                yield return null;
            }

            transform.rotation = Quaternion.identity;
        }

        private IEnumerator OnRespawn()
        {
            yield return new WaitForSeconds(respawnTime);

            IsHit = false;

            boxCollider.enabled = true;
            rigid2D.isKinematic = true;
            transform.position = originalPosition;
            rigid2D.velocity = Vector2.zero;
        }
    }
}
