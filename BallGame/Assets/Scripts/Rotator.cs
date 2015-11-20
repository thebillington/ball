using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

		//Rotates by a new eulerVector, and times the result by the Delta time to make the object frame rate independent
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);

	}
}
