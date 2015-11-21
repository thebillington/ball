using UnityEngine;
using System.Collections;

public class GeneratePickups : MonoBehaviour {

	public Transform prefab;

	void Start() {
		for (int i = 0; i < 100; i++) {

			Instantiate(prefab, new Vector3(Random.Range(-20.0F, 20.0F), 2.0f, Random.Range(10.0F, 1985.0F)), Quaternion.identity);
		}
	}
}
