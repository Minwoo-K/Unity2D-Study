using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private readonly int    maxHP = 3;
    private readonly float  invincibilityTime = 3f;

    [SerializeField]
    private int hp;
    private int coin;
    private SpriteRenderer spriteRenderer;
    
    public bool IsInvincible { get; private set; } = false;
    public int HP   => hp;
    public int Coin => coin;

    private void Awake()
    {
        hp = maxHP;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void DecreaseHP()
    {
        if (hp > 0 && !IsInvincible)
        {
            hp--;
            StartCoroutine(GetInvincible());
        }

        if ( hp == 0 ) PlayerDead();
    }

    public void GetCoin()
    {
        coin++;
    }

    public void PlayerDead()
    {
        Debug.Log("Game Over");
    }

    public IEnumerator GetInvincible()
    {
        float timer = 0, blinkSpeed = 10f;
        Color color = spriteRenderer.color;

        while ( timer < invincibilityTime )
        {
            IsInvincible = true;

            timer += Time.deltaTime;

            color.a = Mathf.SmoothStep(1, 0, Mathf.PingPong(Time.time * blinkSpeed, 1));
            spriteRenderer.color = color;

            yield return null;
        }

        IsInvincible = false;
        color.a = 1;
        spriteRenderer.color = color;
    }
}
