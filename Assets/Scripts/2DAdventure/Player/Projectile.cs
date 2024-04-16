using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private RigidMovement2D movement;
    private float           initialSpeed;

    public void Setup(float direction)
    {
        movement = GetComponent<RigidMovement2D>();
        movement.Move(direction);

        initialSpeed = Mathf.Abs(movement.Velocity.x);
    }

    private void Update()
    {
        // When Hitting the ground
        if ( movement.IsOnGround ) movement.Jump();
        // When colliding with something
        if ( Mathf.Abs(movement.Velocity.x) < initialSpeed ) Destroy(gameObject);
    }
}
