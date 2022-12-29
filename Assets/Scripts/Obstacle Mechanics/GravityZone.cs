using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityZone : MonoBehaviour
{
    public GameObject ball;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = ball.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball")
            rb.gravityScale = -1;
        
            
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        rb.gravityScale = 1;
    }
}
