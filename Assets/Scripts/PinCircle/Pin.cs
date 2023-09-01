using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    private GameObject Bar; // The Pin's Bar Part

    public void ActivateBar(bool isActive)
    {
        Bar.SetActive(isActive);
    }
}
