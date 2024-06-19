using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private readonly int    maxHP = 3;
    private readonly float  invincibilityTime = 3f;

    [SerializeField]
    private bool[] stars = { false, false, false };
    [SerializeField]
    private UI_Controller ui_controller;

    private int hp;
    private int coin;
    private SpriteRenderer spriteRenderer;

    public bool IsInvincible { get; private set; } = false;
    public int HP   => hp;
    public int Coin => coin;
    public bool[] Stars => stars;

    private void Awake()
    {
        hp = maxHP;
        coin = 0;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void DecreaseHP()
    {
        if (hp > 0 && !IsInvincible)
        {
            hp--;
            GetInvincible();
            ui_controller.UpdateHP(hp);
        }

        if ( hp == 0 ) PlayerDead();
    }

    public void GetHPPotion()
    {
        hp++;
        if ( hp > maxHP ) hp = maxHP;
        ui_controller.UpdateHP(hp);
    }

    public void GetCoin()
    {
        coin++;
        ui_controller.UpdateCoin();
    }

    public void PlayerDead()
    {
        Debug.Log("Game Over");
    }

    public void GetInvincible()
    {
        StopAllCoroutines();
        StartCoroutine(InvincibilityOn());
    }

    public void FillStar(int index)
    {
        if ( 2 < index || index < 0 ) return;

        stars[index] = true;

        ui_controller.UpdateStar();
    }

    private IEnumerator InvincibilityOn()
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
