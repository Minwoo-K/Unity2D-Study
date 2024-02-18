using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlower : MonoBehaviour
{
    [SerializeField]
    private float firingRate;
    
    private Animator animator;
    private float currentTime = 0;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private IEnumerator Start()
    {
        while ( true )
        {
            if ( Time.time - currentTime > firingRate )
            {
                animator.SetTrigger("OnFire");

                currentTime = Time.time;
            }

            yield return null;
        }
    }
}
