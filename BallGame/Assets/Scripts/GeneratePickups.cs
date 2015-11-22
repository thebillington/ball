using UnityEngine;
using System.Collections;

public class GeneratePickups : MonoBehaviour {

	public Transform prefab;

	void Start() {
		for (int i = 0; i < 25; i++) {

			Instantiate(prefab, new Vector3(Random.Range(-18.0F, 18.0F), 2.0f, this.transform.position.z + Random.Range(-240.0F, 260.0F)), Quaternion.identity);
		}
	}
}
