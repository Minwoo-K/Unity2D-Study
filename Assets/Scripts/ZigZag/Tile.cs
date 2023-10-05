using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class Tile : MonoBehaviour
    {
        private Rigidbody rigid;

        [SerializeField]
        private float fallingTime;

        private void Awake()
        {
            rigid = GetComponent<Rigidbody>();
        }

        private void OnCollisionExit(Collision collision)
        {
            if ( collision.gameObject.tag.Equals("Player") )
            {
                Debug.Log("Fall Down start");
                StartCoroutine(FallDown());
            }
        }

        private IEnumerator FallDown()
        {
            yield return new WaitForSeconds(0.1f);

            rigid.isKinematic = false;

            yield return new WaitForSeconds(fallingTime);

            rigid.isKinematic = true;
        }
    }
}
