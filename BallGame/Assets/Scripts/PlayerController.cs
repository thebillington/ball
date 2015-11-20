using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody rb;

	void Start() {
		//Initialise the RigidBody attached to the sphere
		rb = GetComponent<Rigidbody> ();
	}

	//Fixed Update is called just before performing any physics calculation
	//This is where our physics will go
	void FixedUpdate() {

		//Return the Horizontal and Vertical axes as floats
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		rb.AddForce(new Vector3(moveHorizontal, 0.0f, moveVertical) * speed);

	}

}
