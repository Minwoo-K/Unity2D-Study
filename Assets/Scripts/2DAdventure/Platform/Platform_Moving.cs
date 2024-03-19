using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Moving : Platform_Base
{
    [SerializeField]
    private Transform   target;         // The Target to move
    [SerializeField]
    private Transform[] stations;       // Stations that the Target stays for waitingTime
    [SerializeField]
    private float       waitingTime;    // Time that the Target stays in a station
    [SerializeField]
    private float       timeOffset;     // TimeOffset to add when calculating moving time of the target

    private int         index;          // The Current Index
    private bool        increasing;     // Whether the index increases or not

    public override void Setup()
    {
        target.position = stations[0].position;
        index = 1;
        increasing = true;

        StartCoroutine(MovingInLoop());
    }

    private IEnumerator MovingInLoop()
    {
        while ( true )
        {
            yield return StartCoroutine(MoveAToB(target.position, stations[index].position));

            yield return new WaitForSeconds(waitingTime);

            if (index == stations.Length - 1) increasing = false;
            else if (index == 0) increasing = true;
            index = increasing ? ++index : --index;
        }
    }

    private IEnumerator MoveAToB(Vector3 A, Vector3 B)
    {
        float distance = Vector3.Distance(A, B);
        float movingTime = distance * timeOffset;
        float percent = 0;

        while ( percent < 1 )
        {
            percent += Time.deltaTime / movingTime;

            target.position = Vector3.Lerp(A, B, percent);

            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.parent = target;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
    }

    public override void UponCollision()
    {
        
    }
}
