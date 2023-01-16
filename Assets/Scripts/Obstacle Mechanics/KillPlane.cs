using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    public GameObject loseScreen;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip deathSound;

    private void Start()
    {
        loseScreen.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ball")
        {
            audioSource.PlayOneShot(deathSound);
            loseScreen.SetActive(true);
        }
    }
}
