using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text scoreText;
	public Text levelText;

	float speedCount = 0.1f;

	private bool jumping = false;
	private int sinceJump = 0;

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

		if(speedCount > 10.0f * Mathf.Log(level + 1)) {// * speedCount) * level) {
			speedCount = 10.0f * Mathf.Log(level + 1);// * speedCount * level;
		}

		//Return the Horizontal and Vertical axes as floats
		float moveHorizontal = Input.GetAxis ("Horizontal");

		if (jumping) {
			sinceJump++;
		}
		if (!jumping && Input.GetKeyDown ("space")) {
			rb.AddForce (new Vector3 (moveHorizontal, 20.0f, 0.1f * speedCount) * speed);
			jumping = true;
			sinceJump ++;
		}
		else if (jumping && sinceJump < 10) {
			rb.AddForce (new Vector3 (moveHorizontal, 20.0f, 0.1f * speedCount) * speed);
		} else {
			rb.AddForce (new Vector3 (0, -20.0f, 0) * speed);
			if(sinceJump > 20) {
				sinceJump = 0;
				jumping = false;
			}
		}

		rb.velocity = (new Vector3 (moveHorizontal, 0, 0.1f * speedCount) * speed);

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