using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile_Base : MonoBehaviour
{
    [Header("Tile Base")]
    [SerializeField]
    protected bool  bounceable;
    
    private bool    bouncing = false;
    private float   bouncingTime = 0.2f;
    

    public abstract void Setup();

    public virtual void UponCollision()
    {
        Debug.Log($"Tile Collision with {name}");

        if ( bounceable )
        {
            if ( !bouncing )
            {
                bouncing = true;

                StartCoroutine(OnBounce());
            }
        }
    }

    private IEnumerator OnBounce()
    {
        float startY = transform.position.y;
        float bouncingAmount = 0.5f;

        yield return StartCoroutine(Bounce(startY, startY+ bouncingAmount));

        yield return StartCoroutine(Bounce(startY+ bouncingAmount, startY));

        bouncing = false;
    }

    private IEnumerator Bounce(float start, float end)
    {
        float percent = 0;

        while ( percent < 1 )
        {
            percent += Time.deltaTime / bouncingTime;

            Vector3 position = transform.position;
            position.y = Mathf.Lerp(start, end, percent);

            transform.position = position;

            yield return null;
        }
    }
}
