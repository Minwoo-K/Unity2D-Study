using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Flower : MonoBehaviour
{
    [SerializeField]
    private float       attackCoolTime;

    private Animator    animator;
    private float       coolTimer;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        coolTimer = 0;
    }

    private void Update()
    {
        coolTimer += Time.deltaTime;

        if ( coolTimer >= attackCoolTime )
        {
            animator.SetTrigger("Attack");
            coolTimer = 0;
        }
    }
}
