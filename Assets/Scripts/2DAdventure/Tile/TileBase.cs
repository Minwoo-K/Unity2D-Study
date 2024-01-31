using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBase : MonoBehaviour
{
    [SerializeField]
    private bool bounceable = false;

    private Vector3 startPosition;

    public bool IsHit { private set; get;} = false;

    private void Awake()
    {
        startPosition = transform.position;
    }

    public virtual void UpdateCollsiion()
    {
        if ( bounceable )
        {
            IsHit = true;

            StartCoroutine(Bounce());
        }
    }

    private IEnumerator Bounce()
    {
        float bounceAmount = 0.35f;

        yield return StartCoroutine(MoveInY(startPosition.y, startPosition.y + bounceAmount));

        yield return StartCoroutine(MoveInY(startPosition.y + bounceAmount, startPosition.y));
        
        IsHit = false;
    }

    private IEnumerator MoveInY(float startY, float endY)
    {
        float percent = 0;
        float bounceTime = 0.2f;

        while ( percent < 1 )
        {
            percent += Time.deltaTime / bounceTime;

            Vector3 position = transform.position;
            position.y = Mathf.Lerp(startY, endY, percent);
            transform.position = position;

            yield return null;
        }
    }
}
