using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text scoreText;
	public Text levelText;

	public Transform groundPrefab;

	float speedCount = 0.1f;

	private Rigidbody rb;
	private int score;
	private int level = 1;

	GameObject thisGround;
	GameObject prevGround;
	GameObject prevprevGround;

	void Start() {
		//Initialise the RigidBody attached to the sphere
		rb = GetComponent<Rigidbody> ();
		score = 0;
		setText ();

		//Initialise the ground
		thisGround = Instantiate(groundPrefab, new Vector3(0, 0, transform.position.z + 240), Quaternion.identity) as GameObject;
	}

	void Update() {
		print (transform.position.z.ToString ());
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

		if (other.gameObject.CompareTag ("Midpoint")) {
			prevprevGround = prevGround;
			prevGround = thisGround;
			thisGround = Instantiate(groundPrefab, new Vector3(0, 0, transform.position.z + 500), Quaternion.identity) as GameObject;
			Destroy(prevprevGround);
		}

	}

	void setText() {
		scoreText.text = "Score: " + score.ToString();
		levelText.text = "Level " + level.ToString();
	}
}