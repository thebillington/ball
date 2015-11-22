using UnityEngine;
using System.Collections;

public class GenerateObstacles : MonoBehaviour {
	
	public Transform prefab;

	void Start() {
		for (int i = 0; i < 25; i++) {
			
			Instantiate(prefab, new Vector3(Random.Range(-17.0F, 17.0F), 3.0f, this.transform.position.z + Random.Range(-230.0F, 270.0F)), Quaternion.identity);
		}
	}
}
