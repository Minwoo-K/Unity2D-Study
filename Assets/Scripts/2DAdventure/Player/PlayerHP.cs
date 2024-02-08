using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private int max = 3;
    [SerializeField]
    private int current;

    private SpriteRenderer spriteRenderer;
    private Color          originalColor;

    [SerializeField]
    private float invinciblilityTime;
    private bool isInvincible = false;

    private void Awake()
    {
        current = max;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void IncreaseHP()
    {
        if ( current < max )
        {
            current ++;
        }
    }

    public void DecreaseHP()
    {
        if ( isInvincible ) return;

        // when damaged, make Player invincible for 1 second
        TurnOnInvincible(1);

        current --;

        if ( current == 0 )
        {
            Debug.Log("Player Dead");
        }
    }

    public void TurnOnInvincible(float timeFrame)
    {
        // Invincibility Overlapping situation
        if ( isInvincible )
        {
            invinciblilityTime += timeFrame;
        }
        // when just got an invincibility
        else
        {
            StartCoroutine(OnInvincible(timeFrame));
        }
    }

    private IEnumerator OnInvincible(float timeFrame)
    {
        isInvincible = true;
        invinciblilityTime = timeFrame;

        float blinkSpeed = 10f;

        while( invinciblilityTime > 0 )
        {
            invinciblilityTime -= Time.deltaTime;
            Color color = spriteRenderer.color;

            color.a = Mathf.SmoothStep(0, 1, Mathf.PingPong(Time.time * blinkSpeed, 1));
            spriteRenderer.color = color;

            yield return null;
        }

        spriteRenderer.color = originalColor;
        isInvincible = false;
    }
}
