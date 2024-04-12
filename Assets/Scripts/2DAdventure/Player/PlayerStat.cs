using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    // HP section
    [SerializeField]
    private int currentLife;
    private readonly int    maxLife = 3;
    public int CurrentLife => currentLife;
    
    // Item - Invincibility
    private readonly float  invincibleTime = 3f;
    public bool IsInvincible { get; private set; } = false;

    private SpriteRenderer  spriteRenderer;
    private Color           originalColor;

    // Item - Coin
    [SerializeField]
    private int coin;
    public int Coin
    {
        set { coin = Mathf.Clamp(value, 0, 9999); }
        get => coin;
    }

    private void Awake()
    {
        currentLife = maxLife;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        coin = 0;
    }

    public void DecreaseLife()
    {
        if ( IsInvincible ) return;

        if ( currentLife >= 1 )
        {
            currentLife--;

            StartCoroutine(Invincibility(2f));

            if ( currentLife == 0 )
            {
                PlayerDead();
            }
        }
    }

    public void InvincibilityOn()
    {
        StopCoroutine("Invincibility");
        StartCoroutine(Invincibility(invincibleTime));
    }

    private IEnumerator Invincibility(float time)
    {
        IsInvincible = true;

        float timeLasting = invincibleTime;
        
        while ( timeLasting > 0 )
        {
            timeLasting -= Time.deltaTime;

            float blinkSpeed = 10;

            Color color = spriteRenderer.color;
            color.a = Mathf.SmoothStep(0, 1, Mathf.PingPong(Time.time * blinkSpeed, 1));

            spriteRenderer.color = color;

            yield return null;
        }

        spriteRenderer.color = originalColor;

        IsInvincible = false;
    }

    public void PlayerDead()
    {
        if ( IsInvincible ) return; 

        Debug.Log("Player Dead, Game Over");
    }
}
