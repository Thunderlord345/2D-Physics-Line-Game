using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineRopeToggle : MonoBehaviour
{
    public Button ropeCutter;
    public Button lineDrawer;

    public Image scissors;
    public Image line;

    Color scissorsAlpha;
    Color lineAlpha;

    private void Start()
    {
        //Assign color to image;
        scissorsAlpha = scissors.color;
        lineAlpha = line.color;

    }
    public void RopeCutter()
    {
        //Buttons enabled & disabled
        ropeCutter.enabled = true;
        lineDrawer.enabled = false;

        //Alpha 
        scissorsAlpha.a = 1f;
        lineAlpha.a = 0.6f;

    }

    public void LineDrawer()
    {
        lineDrawer.enabled = true;
        ropeCutter.enabled = false;

        scissorsAlpha.a = 0.6f;
        lineAlpha.a = 1f;
    }
}
