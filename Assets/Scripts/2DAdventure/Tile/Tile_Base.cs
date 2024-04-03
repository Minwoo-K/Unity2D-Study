using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile_Base : MonoBehaviour
{
    [Header("Tile_Base Component")]
    [SerializeField]
    protected bool bounceable = false;

    // Properties
    public bool IsBouncing  { get; protected set; } = false;
    public bool IsHit       { get; protected set; } = false;

    private void Awake()
    {
        
    }

    public virtual void UponCollision()
    {
        if (IsHit) return;

        else
        { 
            IsHit = true;

            StartCoroutine(BounceOn());
        }
    }

    private IEnumerator BounceOn()
    {
        if (bounceable && !IsBouncing)
        {
            float bouncingAmount = 0.35f;

            IsBouncing = true;

            yield return StartCoroutine(Bounce(transform.position.y, transform.position.y + bouncingAmount));

            yield return StartCoroutine(Bounce(transform.position.y, transform.position.y - bouncingAmount));

            IsBouncing = false;

            IsHit = false;
        }
    }

    private IEnumerator Bounce(float startY, float endY)
    {
        float percent = 0;
        float bouncingTime = 0.2f;

        while ( percent < 1 )
        {
            percent += Time.deltaTime / bouncingTime;

            float y = Mathf.Lerp(startY, endY, percent);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);

            yield return null;
        }
    }
}
