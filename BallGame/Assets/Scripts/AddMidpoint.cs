using UnityEngine;
using System.Collections;

public class AddMidpoint : MonoBehaviour {

	public Transform prefab;
	GameObject g;

	void Start() {
		g = new GameObject ();
		Transform t = (Transform) Instantiate (prefab, new Vector3 (0, 0, this.transform.position.z), Quaternion.identity);
		g = t.gameObject;
		g.transform.parent = this.transform.gameObject.transform;
	}
}
