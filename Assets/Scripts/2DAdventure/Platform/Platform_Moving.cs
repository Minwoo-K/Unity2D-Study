using System.Collections;
using UnityEngine;


public class Platform_Moving : MonoBehaviour
{
    [SerializeField]
    private Transform   targetPlatform;     // The Platform targeted
    [SerializeField]
    private Transform[] stops;              // Stop stations
    [SerializeField]
    private float       waitTime;           // Waiting Time each station
    [SerializeField]
    private float       timeOffset;         // 
    
    private int         index;
    private bool        indexUp = true;

    private int Index
    {
        get { return index; }

        set
        {
            if (index == stops.Length - 1) indexUp = false;
            if (index == 0) indexUp = true;

            index = indexUp ? index + 1 : index - 1;
        }
    }

    private void Awake()
    {
        targetPlatform.position = stops[0].position;
        index = 1;
    }

    private IEnumerator Start()
    {
        while ( true )
        {
            yield return MoveAtoB(targetPlatform.position, stops[Index].position);

            yield return new WaitForSeconds(waitTime);

            Index++;
        }
    }

    private IEnumerator MoveAtoB(Vector3 start, Vector3 end)
    {
        float distance = Vector3.Distance(start, end);
        float moveTime = distance * timeOffset;
        float percent = 0;

        while ( percent < 1 )
        {
            percent += Time.deltaTime / moveTime;

            targetPlatform.position = Vector3.Lerp(start, end, percent);

            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.collider.CompareTag("Player") ) collision.transform.SetParent(targetPlatform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) collision.transform.SetParent(null);
    }
}
