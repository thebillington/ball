using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public float turnSpeed = 4.0f;

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Late Update is called after everything in update has been called
	void LateUpdate () {

		offset = Quaternion.AngleAxis (Input.GetAxis ("Horizontal") * turnSpeed, Vector3.up) * offset;
		if (offset.x > 0.5) {
			offset.x -= 5.0f * Time.deltaTime;
		}
		if (offset.x < -0.5) {
			offset.x += 5.0f * Time.deltaTime;
		}
		offset.y = 2.0f;
		offset.z = -6.0f;
		transform.position = player.transform.position + offset;
		transform.LookAt (player.transform.position);
	}
}