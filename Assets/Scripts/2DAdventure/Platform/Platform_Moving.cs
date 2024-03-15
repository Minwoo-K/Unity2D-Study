using System.Collections;
using UnityEngine;


public class Platform_Moving : MonoBehaviour
{
    [SerializeField]
    private Transform[] stops;
    [SerializeField]
    private float       moveTime;

    private float       waitTime;
    private bool        indexUp = true;

    private int Index
    {
        get { return Index; } 

        set 
        {
            Index = indexUp ? Index + 1 : Index - 1;

            if (Index == stops.Length - 1) indexUp = false;
            if (Index == 0) indexUp = true;
        }
    }

    private void Awake()
    {
        transform.position = stops[0].position;
        Index = 1;
    }

    private IEnumerator Start()
    {
        while ( true )
        {
            yield return MoveAtoB(transform.position, stops[Index].position);

            yield return new WaitForSeconds(waitTime);

            Index++;
        }
    }

    private IEnumerator MoveAtoB(Vector3 start, Vector3 end)
    {
        Vector3 direction = end - start;

        float current = 0, percent = 0;

        while ( percent < 1 )
        {
            current = direction.normalized.magnitude / moveTime;
            percent += current;

            transform.position = Vector3.Lerp(start, end, percent);

            yield return null;
        }
    }
}
