using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower_Animator : MonoBehaviour
{
    [SerializeField]
    private GameObject  projectile;
    [SerializeField]
    private Transform   attackSpawningPoint;
    [SerializeField]
    private Vector3     attackDirection = Vector3.down;

    public void OnAttack()
    {
        GameObject attack = Instantiate(projectile, attackSpawningPoint.position, Quaternion.identity);
        attack.GetComponent<TransformMovement2D>().SetDirection(attackDirection);
    }
}
