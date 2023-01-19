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

	public Button switchButt;

	public bool hasSwitched;

	

	LineFactory lf;
	private void Start()
    {
		lf = FindObjectOfType<LineFactory>();
		lf.isRunning = true;

		switchButt.interactable = true;
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
		if (hasSwitched)
			lf.isRunning = false;
    }
    public void SwitchModes()
    {
		bgLineAlpha.a = 0.6f;
		lineAlpha.a = 0.6f;
		line.color = lineAlpha;
		bgLine.color = bgLineAlpha;

		bgAlpha.a = 1f;
		scissorsAlpha.a = 1f;
		bg.color = bgAlpha;
		scissors.color = scissorsAlpha;

		cutter.SetActive(true);

		switchButt.interactable = false;
		hasSwitched = true;
		
	}

	
}
