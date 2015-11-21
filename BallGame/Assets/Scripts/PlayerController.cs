using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text scoreText;
	public Text levelText;

	float speedCount = 0.1f;

	private Rigidbody rb;
	private int score;
	private int level = 1;

	void Start() {
		//Initialise the RigidBody attached to the sphere
		rb = GetComponent<Rigidbody> ();
		score = 0;
		setText ();
	}

	//Fixed Update is called just before performing any physics calculation
	//This is where our physics will go
	void FixedUpdate() {

		speedCount += 0.1f;

		if(speedCount > 10.0f * level) {// * speedCount) * level) {
			speedCount = 10.0f * level;// * speedCount * level;
		}

		//Return the Horizontal and Vertical axes as floats
		float moveHorizontal = Input.GetAxis ("Horizontal");

		rb.velocity = (new Vector3(moveHorizontal, -1.0f, 0.1f * speedCount) * speed);
		setText ();

	}

	//This wil be called when a Trigger object (the player) first triggers the collider
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive(false);
			score ++;
			if(score % 10 == 0) {
				level++;
			}
			setText();
		}

	}

	void setText() {
		scoreText.text = "Score: " + score.ToString();
		levelText.text = "Level " + level.ToString();
	}
}