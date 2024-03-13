using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile_Base : MonoBehaviour
{
    [Header("Tile Base")]
    [SerializeField]
    protected bool  bounceable;
    
    private float   bouncingTime = 0.2f;
    private float   startY;
    
    public bool Hit { get; protected set; } = false;

    private void Awake()
    {
        Setup();
    }

    public abstract void Setup();

    public virtual void UponCollision()
    {
        if ( Hit ) return;

        Debug.Log($"Tile Collision with {name}");

        Hit = true;

        if ( bounceable )
        {
            startY = transform.position.y;
            StartCoroutine(OnBounce());
        }
    }

    private IEnumerator OnBounce()
    {
        float bouncingAmount = 0.5f;

        yield return StartCoroutine(Bounce(startY, startY + bouncingAmount));

        yield return StartCoroutine(Bounce(startY + bouncingAmount, startY));

        Hit = false;
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
