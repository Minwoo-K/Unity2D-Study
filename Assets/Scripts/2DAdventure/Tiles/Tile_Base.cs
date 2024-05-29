using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Base : MonoBehaviour
{
    [SerializeField]
    private bool bounceable;

    public bool IsHit { get; protected set; } = false;

    public virtual void UpdateCollision()
    {
        if ( bounceable )
        {
            if (IsHit) return;

            IsHit = true;

            StartCoroutine(OnBounce());
        }
    }

    private IEnumerator OnBounce()
    {
        float bouncingAmount = 0.5f;
        float bouncingTime = 0.3f;

        yield return StartCoroutine(MoveInY(transform.position.y, transform.position.y+bouncingAmount, bouncingTime / 2f));

        yield return StartCoroutine(MoveInY(transform.position.y, transform.position.y-bouncingAmount, bouncingTime / 2f));

        IsHit = false;
    }

    private IEnumerator MoveInY(float startY, float endY, float time)
    {
        float percent = 0;

        while ( percent < 1 )
        {
            percent += Time.deltaTime / time;
            float y = startY;

            y = Mathf.Lerp(startY, endY, percent);
            transform.position = new Vector3(transform.position.x, y, 0);

            yield return null;
        }
    }
}
