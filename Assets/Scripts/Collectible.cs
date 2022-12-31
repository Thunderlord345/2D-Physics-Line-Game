using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    ScoreManager sc;
    public int scoreValue = 10;
    public GameObject coin;
    public GameObject scoreManager;

    public Vector3 rotationRate;
    private void Start()
    {
        sc = scoreManager.GetComponent<ScoreManager>();
    }
    private void Update()
    {
        transform.Rotate(rotationRate * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ball")
        {
            sc.AddScore(scoreValue);

            Destroy(gameObject);
        }
    }
}
