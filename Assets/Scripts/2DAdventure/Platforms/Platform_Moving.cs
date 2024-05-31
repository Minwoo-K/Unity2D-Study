using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Moving : Platform_Base
{
    [SerializeField]
    private Transform   targetPlatform;
    [SerializeField]
    private Transform[] stations;
    [SerializeField]
    private float       timeSet;            // Time Setter to define how long it takes. The higher the longer time.
    [SerializeField]
    private float       stayingTime;        // Time to stay once reached at a station

    private int index = 0;
    private bool indexIncreasing = true;

    private void Awake()
    {
        transform.position = stations[index].position;

        StartCoroutine(MoveInLoop());
    }

    private IEnumerator MoveInLoop()
    {
        while ( true )
        {
            index = indexIncreasing ? ++index : --index;

            if (index + 1 == stations.Length) indexIncreasing = false;
            else if (index == 0) indexIncreasing = true;

            yield return StartCoroutine(MoveAToB(targetPlatform.position, stations[index].position));
        }
    }

    private IEnumerator MoveAToB(Vector3 A, Vector3 B)
    {
        float distance = Vector3.Distance(A, B);
        float movingTime = distance * timeSet; // Time = Distance * TimeSetter. If distance 5, if timeSet is 2, it takes 10s to move

        float percent = 0;

        while ( percent < 1 )
        {
            percent += Time.deltaTime / movingTime;

            targetPlatform.position = Vector3.Lerp(A, B, percent);

            yield return null;
        }

        yield return new WaitForSeconds(stayingTime);
    }

    public override void UpdateCollision(Transform player)
    {
        if ( player.CompareTag("Player") )
        {
            player.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if ( collision.transform.CompareTag("Player") )
        {
            collision.transform.parent = null;
        }
    }
}
