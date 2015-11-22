using UnityEngine;
using System.Collections;

public class AddMidpoint : MonoBehaviour {

	public Transform prefab;

	void Start() {
		Instantiate (prefab, new Vector3 (0, 0, this.transform.position.z), Quaternion.identity);
	}
}
