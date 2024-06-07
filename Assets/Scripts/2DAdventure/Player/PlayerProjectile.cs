using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private RigidbodyMovement2D movement;
    private float               startSpeed;

    public void Spawned(float direction)
    {
        movement = GetComponent<RigidbodyMovement2D>();
        movement.Move(direction);

        startSpeed = Mathf.Abs(movement.Velocity.x);
    }

    private void Update()
    {
        if (movement.IsOnGround) movement.Jump();

        if ( movement.Velocity.x < startSpeed ) // when colliding with something
        {
            Destroy(gameObject);
        }
    }

}
