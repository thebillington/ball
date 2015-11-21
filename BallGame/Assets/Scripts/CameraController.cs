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
		transform.position = player.transform.position + offset;
		offset = Quaternion.AngleAxis (Input.GetAxis ("Vertical") * turnSpeed, Vector3.left) * offset;
		transform.position = player.transform.position + offset;
		transform.LookAt (player.transform.position);
	}
}
