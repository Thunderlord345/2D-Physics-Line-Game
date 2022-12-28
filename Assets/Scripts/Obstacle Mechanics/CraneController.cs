using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    public GameObject crane;
    Rigidbody2D craneRB;
    // Start is called before the first frame update
    void Start()
    {
        craneRB = crane.GetComponent<Rigidbody2D>();
        craneRB.isKinematic = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        craneRB.isKinematic = false;
    }
}
