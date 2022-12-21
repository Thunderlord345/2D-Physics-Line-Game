using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputCollider : MonoBehaviour
{
    CircleCollider2D col;
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            col.enabled = true;
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            col.transform.position = touchPosition;
        }
        else
        {
            col.enabled = false;
        }
    }
}
