using UnityEngine;

public class Rope : MonoBehaviour {

	public Rigidbody2D hook;

	public GameObject linkPrefab;

	public Weight weigth;

	public int links = 7;

	void Start () {
		GenerateRope();
	}

	void GenerateRope ()
	{
		Rigidbody2D previousRB = hook;
		for (int i = 0; i < links; i++)
		{
			GameObject link = Instantiate(linkPrefab, transform);
			HingeJoint2D joint = link.GetComponent<HingeJoint2D>(); //Where the link is attached
			joint.connectedBody = previousRB;

			//
			if (i < links - 1)
			{
				previousRB = link.GetComponent<Rigidbody2D>(); //One side is attached to joint
			} else
			{
				weigth.ConnectRopeEnd(link.GetComponent<Rigidbody2D>()); //Other side attached to weight
			}

			
		}
	}

}
