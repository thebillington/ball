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
		if (offset.z < -7.0) {
			offset.z += 0.1f;
		}
		if (offset.z > -5.0) {
			offset.z -= 0.1f;
		}

		print (offset.ToString ());
		transform.position = player.transform.position + offset;
		offset = Quaternion.AngleAxis (Input.GetAxis ("Vertical") * turnSpeed, Vector3.left) * offset;
		if (offset.y > 4.0) {
			offset.y -= 12.0f * Time.deltaTime;
		}
		if (offset.y < 2.0) {
			offset.y += 12.0f * Time.deltaTime;
		}

		print (offset.ToString ());
		transform.position = player.transform.position + offset;
		transform.LookAt (player.transform.position);
	}
}
