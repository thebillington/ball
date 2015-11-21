using UnityEngine;
using System.Collections;

public class GenerateObstacles : MonoBehaviour {
	
	public Transform prefab;

	void Start() {
		for (int i = 0; i < 100; i++) {
			
			Instantiate(prefab, new Vector3(Random.Range(-15.0F, 15.0F), 3.0f, Random.Range(10.0F, 1985.0F)), Quaternion.identity);
		}
	}
}
