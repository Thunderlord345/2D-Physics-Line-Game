using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPosition : MonoBehaviour
{ 
    Vector2 ballPos;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        ballPos = ball.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Ball"))
        {
            ball.transform.position = ballPos;
            
        }
    }
}
