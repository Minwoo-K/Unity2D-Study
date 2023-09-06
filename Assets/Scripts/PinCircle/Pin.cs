using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    private GameObject bar; // The Bar object
    [SerializeField]
    private float moveTime; // Time of Moving Stand-by Pins

    private PinCircleManager pinCircleManager;

    public void Setup(PinCircleManager pinCircleManager)
    {
        this.pinCircleManager = pinCircleManager;
    }

    public void SetItStuck()
    {
        // If the given Pin was a throwable pin, 
        StopCoroutine("MoveTo");
        // Activaate the Bar object when stuck in the target
        bar.SetActive(true);
    }

    public void MoveUp(float distance)
    {
        StartCoroutine(MoveTo(distance));
    }

    private IEnumerator MoveTo(float distance)
    {
        Vector3 start = transform.position;
        Vector3 end = transform.position + Vector3.up * distance;

        float current = 0;
        float percent = 0;

        while ( percent < 1 )
        {
            current += Time.deltaTime;
            percent = current / moveTime;

            transform.position = Vector3.Lerp(start, end, percent);

            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if a collision happens with a Pin, Game over
        if ( collision.transform.GetComponent<Pin>() != null )
        {
            Debug.Log("Game Over!");
        }
    }
}
