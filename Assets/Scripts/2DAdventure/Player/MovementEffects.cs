using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEffects : MonoBehaviour
{
    [SerializeField]
    private GameObject landingEffect;

    private MovementRigid2D movement;

    private bool wasOnGround = false;

    private void Awake()
    {
        movement = GetComponent<MovementRigid2D>();
    }

    private void Update()
    {
        if ( !wasOnGround && movement.IsOnGround ) 
            Instantiate(landingEffect, movement.FeetPosition, Quaternion.identity);

        wasOnGround = movement.IsOnGround;
    }
}
