using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBase : MonoBehaviour
{
    [SerializeField]
    private bool bounceable = false;                    // whether this Tile is bounceable or not

    private Vector3 startPosition;                      // Start Position to be saved

    public bool IsHit { private set; get;} = false;     // A Flag to avoid bouncing multiple times upon one collision

    private void Awake()
    {
        // Save the start position
        startPosition = transform.position;
    }

    public virtual void UpdateCollsiion()
    {
        // only if bounceable
        if ( bounceable )
        {
            // Bounce process
            IsHit = true;

            StartCoroutine(Bounce());
        }
    }

    private IEnumerator Bounce()
    {
        float bounceAmount = 0.35f;
        // Bounce up
        yield return StartCoroutine(MoveInY(startPosition.y, startPosition.y + bounceAmount));
        // Bounce back down
        yield return StartCoroutine(MoveInY(startPosition.y + bounceAmount, startPosition.y));
        // A Bounce process is done
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
