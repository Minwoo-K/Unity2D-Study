using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBase : MonoBehaviour
{
    [SerializeField]
    private bool bounceable = false;

    private Vector3 startPosition;
    private float bouncingAmount = 0.35f;

    public bool isBouncing { private set; get; } = false;

    private void Awake()
    {
        startPosition = transform.position;
    }

    public virtual void UpdateCollsion()
    {
        if ( bounceable )
        {
            isBouncing = true;

            StartCoroutine( OnBounce() );
        }
    }

    public IEnumerator OnBounce()
    {
        yield return StartCoroutine(MoveInY(startPosition.y, startPosition.y + bouncingAmount));

        yield return StartCoroutine(MoveInY(startPosition.y + bouncingAmount, startPosition.y ));

        isBouncing = false;
    }

    private IEnumerator MoveInY(float startY, float endY)
    {
        float movingTime = 0.2f;
        float percent = 0;

        while ( percent < 1 )
        {
            percent += Time.deltaTime / movingTime;

            Vector3 position = transform.position;
            position.y = Mathf.Lerp(startY, endY, percent);
            transform.position = position;

            yield return null;
        }
    }
}
