using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ModeSwitch : MonoBehaviour
{
	[Header("RopeCutter")]
	public Image bg;
	public Image scissors;
	Color bgAlpha;
	Color scissorsAlpha;
	public GameObject cutter;

	[Header("LineDrawer")]
	public Image bgLine;
	public Image line;
	Color bgLineAlpha;
	Color lineAlpha;


	public Button lineDrawer;

	LineFactory lf;
	private void Start()
    {
		lf = FindObjectOfType<LineFactory>();
		lineDrawer.interactable = true;
		 //RopeCutter color
		bgAlpha = bg.color;
		scissorsAlpha = scissors.color;

		bgAlpha.a = 0.6f;
		scissorsAlpha.a = 0.6f;

		bg.color = bgAlpha;
		scissors.color = scissorsAlpha;

		//LineFact color
		bgLineAlpha = bgLine.color;
		lineAlpha = line.color;

		bgLineAlpha.a = 1f;
		lineAlpha.a = 1f;

		line.color = lineAlpha;
		bgLine.color = bgLineAlpha;
	}
    private void Update()
    {
        if(lineDrawer.interactable == false)
        {
			lf.isRunning = false;
        }
    }
    public void RopeCutter()
    {
		bgLineAlpha.a = 0.6f;
		lineAlpha.a = 0.6f;

		bgAlpha.a = 1f;
		scissorsAlpha.a = 1f;

		cutter.SetActive(true);
		lineDrawer.interactable = false;
	}

	public void LineDrawer()
    {
		lf.isRunning = true;
    }
}
