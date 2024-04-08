using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [SerializeField]
    private int currentLife;

    private readonly int maxLife = 3;
    private SpriteRenderer spriteRenderer;

    public bool IsInvincible { get; private set; } = false;
    public int CurrentLife => currentLife;

    private void Awake()
    {
        currentLife = maxLife;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DecreaseLife()
    {
        if ( currentLife > 1 && ! IsInvincible )
        {
            currentLife--;

            StartCoroutine(Invincibility(2f));

            if ( currentLife == 0 )
            {
                Debug.Log("Player Dead, Game Over");
            }
        }
    }

    public IEnumerator Invincibility(float time)
    {
        IsInvincible = true;

        yield return new WaitForSeconds(time);

        IsInvincible = false;
    }
}
