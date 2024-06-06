using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private readonly int    maxHP = 3;
    private readonly float  invincibilityTime = 3f;

    private int hp;
    private int coin;
    private SpriteRenderer spriteRenderer;

    public int HP   => hp;
    public int Coin => coin;

    private void Awake()
    {
        hp = maxHP;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void DecreaseHP()
    {
        if (hp > 0)
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
        float timer = 0; 
        Color color = spriteRenderer.color;

        while ( timer < invincibilityTime )
        {
            timer += Time.deltaTime;

            color.a = 0;
            spriteRenderer.color = color;
            color.a = 1; 
            spriteRenderer.color = color;

            yield return null;
        }

        color.a = 1;
        spriteRenderer.color = color;
    }
}
