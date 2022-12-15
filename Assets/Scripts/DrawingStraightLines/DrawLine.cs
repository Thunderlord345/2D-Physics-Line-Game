using UnityEngine;
using System.Collections;
 
public class DrawLine : MonoBehaviour {
	// Reference to LineRenderer component
	private LineRenderer line;
	// Container to store mouse position on the screen
	private Vector3 mousePos;
	// Assign a material to the Line Renderer in the Inspector
	public Material material;
	// Number of lines drawn
	private int totalLines;

	private void Start() {
		totalLines = 0;
	}

	void Update() {
		// Create new line on left mouse is depressed
		if(Input.GetMouseButtonDown(0)) {
			// Check if there is no line renderer created
			if (line == null) {
				CreateLine();
			}
			// Get mouse position
			mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane));
			// Set z co-ordinate to 0 on 2D plane
			mousePos.z = 0;
			// Set the start point and end point of the line renderer
			line.SetPosition(0, mousePos);
		}

		// Line renderer exists and left mouse button is released (exited)
		if(Input.GetMouseButtonUp(0) && line) {
			mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane));
			mousePos.z = 0;
			// Set end point of the line renderer to current mouse position
			line.SetPosition(1, mousePos);
			// Set line as null once line is created
			line = null;
			totalLines++;
			print(totalLines);
		}

		// Mouse button is held and line exists
		if(Input.GetMouseButton(0) && line) {
			mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane));
			mousePos.z = 0;
			// Set end position as current position but don't set line as null since mouse has not exited
			line.SetPosition(1, mousePos);
		}
	}

	// Method to create line
	private void CreateLine() {
		// Create a new empty gameobject and line renderer component
		line = new GameObject("Line " + totalLines).AddComponent<LineRenderer>();
		// Assign the material to the line
		line.material = material;
		// Set the number of points in the line
		line.positionCount = 2;
		// Set line renderer starting and ending width
		line.startWidth = 0.15f;
		line.endWidth = 0.15f;
		// Render line to the world origin and not to the object's position
		line.useWorldSpace = true;
	}
}