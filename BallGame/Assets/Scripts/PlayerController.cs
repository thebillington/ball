using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start() {
		//Initialise the RigidBody attached to the sphere
		rb = GetComponent<Rigidbody> ();
		count = 0;
		setCountText ();
		winText.text = "";
	}

	//Fixed Update is called just before performing any physics calculation
	//This is where our physics will go
	void FixedUpdate() {

		//Return the Horizontal and Vertical axes as floats
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		rb.AddForce(new Vector3(moveHorizontal, 0.0f, moveVertical) * speed);

	}

	//This wil be called when a Trigger object (the player) first triggers the collider
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive(false);
			count ++;
			setCountText();
		}

	}

	void setCountText() {
		countText.text = "Score: " + count.ToString();
		if (count == 14) {
			winText.text = "You win!";
		}
	}


}