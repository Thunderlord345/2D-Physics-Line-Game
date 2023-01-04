using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    public GameObject loseScreen;

    private void Start()
    {
        loseScreen.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider other)
    {
        if(other.tag == "Ball")
        {
            loseScreen.SetActive(true);
        }
    }
}
