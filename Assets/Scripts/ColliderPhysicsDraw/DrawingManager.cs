using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ColliderTypeChoice {PolygonCollider, EdgeCollider}

public class DrawingManager : MonoBehaviour {
	private LineRenderer pathLineRenderer;
	private EdgeCollider2D pathEdgeCollider;
	private PolygonCollider2D pathPolygonCollider;
	private Rigidbody2D pathRigidbody;
	private Color c1, c2;
	Gradient gradient;
	private int posCount;
	private float destroyCounter;
	static public int cloneNumber;
	private float colliderAngle;
	[HideInInspector]
	public List<Vector2> newVerticies = new List<Vector2>();
	private List<Vector2> newVerticesPolygon = new List<Vector2>();
	public GameObject path;
	public GameObject massCenter;
	GameObject massCenterClone;
	GameObject clone;
	[HideInInspector]
	public Vector2 centerOfMass = Vector2.zero;
	private int centerOfMassCount = 0;
	private GameObject[] lines;

	// Inspector settings
	[Header("Line Settings")]
	public Color colorStart; // Start and final color of the line
	public Color colorEnd;
	public PhysicsMaterial2D material; // Physics material attached to the collider
	[Range(0.0f, 10.0f)]
	public float widthStart; // Start and final width of the line
	[Range(0.0f, 10.0f)]
	public float widthEnd;
	[Range(0.0f, 5.0f)]
	public float verticesDistance; // Minimun distance between vertices of the line
	public bool fixedPosition; // Either object will have fixed position when set to true or it will be gravity driven when false
	public bool isPermanent; // Drawn object will be destroyed after lifeTime seconds
	public float lifeTime; // Time after destruction of a non-permanent drawn object
	public ColliderTypeChoice colliderType; // Choice between 2D polygon collider or 2D edge collider
	// Note: edge collider 2D do not collider with each other cause they don't have volume

	public bool showMassCenter; // Show mass center
	public int massCenterPrecision; // Multiplier to make center of mass calculation more precise relative to the width of the line
	public bool dynamicMass; // Either mass is calculated relative to the width of line when set to true or it has a fixed mass when false
	[Range(0.0f, 10.0f)]
	public float massScale; // Define mass scale when dynamicMass is set to true or fixed mass when false
	[Range(-10.0f, 10.0f)]
	public float gravityScale; // Objects float when < 0, sink when > 0
	
	/// <summary>
	/// Variables are initalized and set here
	/// </summary>   
	void Start() {
		cloneNumber = 1;
		verticesDistance = 0.2f;
		lifeTime = 2f;
		isPermanent = true;
		fixedPosition = false;
		showMassCenter = false; 
		massCenterPrecision = 6;
		dynamicMass = true;
		massScale = 1f;
		gravityScale = 1f;

		pathLineRenderer = path.GetComponent<LineRenderer>();
		pathLineRenderer.useWorldSpace = false;

		// Define line material
		pathLineRenderer.material = new Material(Shader.Find("Particles/Standard Unlit"));
		pathLineRenderer.startColor = colorStart;
		pathLineRenderer.endColor = colorEnd;
		posCount = 0;
	}

	void Update() {
		if(Input.GetMouseButtonDown(0)) {
			GeneratePath();
		}

		if(Input.GetMouseButton(0)) {
			DrawVisibleLine();
		}

		if(Input.GetMouseButtonUp(0)) {
			centerOfMassCount = 0;
			centerOfMass = Vector2.zero;
			
			if(colliderType == ColliderTypeChoice.EdgeCollider) { // Check the chosen collider
				for(int i = 0; i < newVerticies.Count - 1; i++) {
					// Obtain width of the line for each point
					float tempWidth = Mathf.Lerp(widthStart, widthEnd, (float)i / (newVerticies.Count - 2));
					
					ComputePreviousCenterOfMassAndMass(i, tempWidth);
				}

				if(newVerticies.Count > 2)
					pathEdgeCollider.points = newVerticies.ToArray();

				pathEdgeCollider.sharedMaterial = material;
			} else {
				newVerticies.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition) - clone.transform.position);

				for(int i = 0; i < newVerticies.Count - 1; i++) {
					if(i < newVerticies.Count - 2) {
						// Calculates angle of each edge in the line
						colliderAngle = Mathf.Atan2(newVerticies[i].y - newVerticies[i + 1].y, newVerticies[i].x - newVerticies[i + 1].x);
						colliderAngle = colliderAngle + (Mathf.Deg2Rad * 90f);
					} else {
						// Since two points are required to make an edge and angle calculation is not done for the last edge, the last point is not required same angle from previous is preserved, 
					}

					float cos = Mathf.Cos(colliderAngle); // Calculate cosine value
					float sin = Mathf.Sin(colliderAngle); // Calculate sine value

					// Obtain width of the line for each point of it
					float tempWidth = Mathf.Lerp(widthStart, widthEnd, (float)i / (newVerticies.Count - 2));

					// To make 2D polygon collider follow the line, each side of the line adds one point to the beginning and one to the end of the list
					newVerticesPolygon.Add(new Vector2((newVerticies[i].x) + ((tempWidth / 2) * cos), (newVerticies[i].y) + ((tempWidth / 2) * sin)));
					newVerticesPolygon.Insert(0, new Vector2((newVerticies[i].x) - ((tempWidth / 2) * cos), (newVerticies[i].y) - ((tempWidth / 2) * sin)));

					ComputePreviousCenterOfMassAndMass(i, tempWidth);
				}

				pathPolygonCollider.points = newVerticesPolygon.ToArray();
				pathPolygonCollider.sharedMaterial = material;
			}

			if(dynamicMass == true)
				pathRigidbody.mass *= massScale;
			else
				pathRigidbody.mass = massScale;

			centerOfMass /= centerOfMassCount;
			if(newVerticies.Count > 2 && (widthStart != 0 || widthEnd != 0))
				pathRigidbody.centerOfMass = centerOfMass;

			// Set showMassCenter if to display center of mass during gameplay and instantiate the prefab in the proper position
			// Note: mass center prefab can be personalized with an image or any object
			if(showMassCenter) {
				massCenterClone = (GameObject)Instantiate(massCenter, this.transform.position, Quaternion.identity);
				massCenterClone.transform.parent = pathRigidbody.transform;
				massCenterClone.transform.position = centerOfMass;
			}

			pathRigidbody.isKinematic = fixedPosition;
			posCount = 0;

			// Check if drawn line is too small
			// If there is no visual volume, destroy the prefab
			if(newVerticies.Count <= 2 || (widthStart == 0 && widthEnd == 0)) {
				cloneNumber--;
				Destroy(clone);
			}
		}
	}

	/// <summary>
	/// Instantiate prefab and initialize variables for the drawing construction
	/// </summary>
	void GeneratePath() {
		clone = (GameObject)Instantiate(path, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity); // Instantiate prefab
		clone.name = "Line " + cloneNumber; // Rename instantiated object for ease of tracking
		//clone.tag = "DynamicLine"; // Add tag to each drawn line for removal when clear button is pressed
		cloneNumber++; // Add 1 to the variable for renaming of drawn lines
		pathLineRenderer = clone.GetComponent<LineRenderer>();
		pathRigidbody = clone.GetComponent<Rigidbody2D>();
		pathRigidbody.isKinematic = true; // Set rigidbody kinematic so it will not move during the drawing process
		pathRigidbody.gravityScale = gravityScale; // Adjust gravity for drawing
		clone.transform.position = Vector3.zero;
		clone.transform.rotation = Quaternion.identity;
		pathRigidbody.centerOfMass = Vector2.zero; // Initialize center of mass before calculating actual position
		pathLineRenderer.startColor = colorStart; // Set start color
		pathLineRenderer.endColor = colorEnd; // Set end color
		pathLineRenderer.startWidth = widthStart; // Set start width
		pathLineRenderer.endWidth = widthEnd; // Set end width
		newVerticies.Clear(); // Clear list before adding new points for new drawing
		newVerticesPolygon.Clear(); // List used to create the 2D polygon collider
		pathLineRenderer.positionCount = 1;
		pathLineRenderer.SetPosition(0, Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position); // Add first point to the line renderer
		newVerticies.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition) - clone.transform.position); // Add first point to the array used to create the colliders

		// Check if chosen collider is edge or polygon and destroy the one that is not in use
		if(colliderType == ColliderTypeChoice.EdgeCollider) {
			Destroy(clone.GetComponent<PolygonCollider2D>());
			pathEdgeCollider = clone.GetComponent<EdgeCollider2D>();
		} else {
			Destroy(clone.GetComponent<EdgeCollider2D>());
			pathPolygonCollider = clone.GetComponent<PolygonCollider2D>();
		}
	}
	
	/// <summary>
	/// Draw the line using mouse position and adding the points to the Line Renderer
	/// </summary>
	void DrawVisibleLine() {
		// Check if minimun distance (verticesDistance) from the previous vertex is reached and add to the next point
		if(Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), newVerticies[posCount]) > verticesDistance) {
			posCount++;
			pathLineRenderer.positionCount = posCount + 1;
			pathLineRenderer.SetPosition(posCount, Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position);
			newVerticies.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition) - clone.transform.position);
		}
	}

	/// <summary>
	/// For each point, sum up the values of the center of mass position and mass of the drawing
	/// </summary>
	/// <param name = "n">Index of the points</param>
	/// <param name = "width">Half of the width of the line in each point</param>
	void ComputePreviousCenterOfMassAndMass(int n, float width) {
		// Calculates center of mass related to width and precision set
		for(int j = 0; j < width * massCenterPrecision; j++) {
			centerOfMass += newVerticies[n];
			centerOfMassCount++;
		}
		
		// Adds mass for each point of the line
		if(dynamicMass == true && newVerticies.Count > 2)
			pathRigidbody.mass += width;
	}

	public void ClearPaths() {
		if(lines == null)
			lines = GameObject.FindGameObjectsWithTag("Line");

		foreach(GameObject line in lines) {
			Destroy(line);
		}
	}
}