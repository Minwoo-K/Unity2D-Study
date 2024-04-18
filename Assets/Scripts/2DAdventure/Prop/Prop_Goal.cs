using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop_Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player") )
        {
            Debug.Log("Goal reached, the Game ends");
        }
    }
}
