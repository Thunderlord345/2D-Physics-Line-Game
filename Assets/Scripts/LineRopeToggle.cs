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

    public GameObject cutter;
    public GameObject lineFact;

    private void Start()
    {
        //Assign color to image;
        scissorsAlpha = scissors.color;
        lineAlpha = line.color;

        LineDrawer();

    }
    public void RopeCutter()
    {
        cutter.SetActive(true);
        lineFact.SetActive(false);

        //Buttons enabled & disabled
        ropeCutter.interactable = false;
        lineDrawer.interactable = true;

        //Alpha 
        scissorsAlpha.a = 1f;
        lineAlpha.a = 0.6f;

    }

    public void LineDrawer()
    {
        lineFact.SetActive(true);
        cutter.SetActive(false);

        lineDrawer.interactable = false;
        ropeCutter.interactable = true;

        scissorsAlpha.a = 0.6f;
        lineAlpha.a = 1f;
    }
}
