using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyPath : MonoBehaviour {
	public bool isPermanent;
	private  List<Vector2> newVerticies = new List<Vector2>();
	public float destroyCounter;
	//private bool canDestroy = false;
	private Vector2 centerOfMass = Vector2.zero;
	private DrawingManager drawManager;
	private bool dynamicMass;
	private float massScale;

	void Start() {
		drawManager = GameObject.Find("Draw Controller").GetComponent<DrawingManager>();
		newVerticies = drawManager.newVerticies;
		destroyCounter = drawManager.lifeTime;
		isPermanent = drawManager.isPermanent;
	}
	
	void Update() {
		if(Input.GetMouseButtonUp(0) && this.name.Equals("Line " + (DrawingManager.cloneNumber - 1))) {
			foreach(Vector2 positions in newVerticies) {
				centerOfMass += positions;
			}

			centerOfMass /= newVerticies.Count;
			//canDestroy = true;
		}

		//if(destroyCounter > 0 && isPermanent == false && canDestroy == true) { // Timed destruction of path
		//	destroyCounter -= Time.deltaTime;

		//	if(destroyCounter <= 0) {
		//		Destroy(this.gameObject);
		//	}
		//}
	}
}