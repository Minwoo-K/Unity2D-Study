using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop_Sign : MonoBehaviour
{
    [SerializeField]
    private GameObject guideObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player") )
        {
            guideObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player") )
        {
            guideObject.SetActive(false);
        }
    }
}
