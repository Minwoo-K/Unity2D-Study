using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Flower : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float attackCoolTime;
    
    private Animator animator;
    private Vector2 projectileVelocity = new Vector2(0, -10);

}
