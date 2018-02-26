using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	public GameObject[] spawnableObjects;
	public GameObject tableArea;
	public RectTransform centerSpawn;
	public float spawnTimer = 2f;
	public float startAmount = 7f;
	private Vector3 position;
	

	// Use this for initialization
	void Start () {
		Initialize();
	}


	private void Initialize() {
		//Removes all children of transform object.
		foreach (Transform child in tableArea.transform) {
			Destroy(child.gameObject);
		}

		while (tableArea.transform.childCount < startAmount) {
			SpawnObject();	
		}



	}

	private void SpawnObject() {
		GameObject toInstansiate = spawnableObjects[Random.Range(0, spawnableObjects.Length)];
		GameObject instance = Instantiate(toInstansiate, Vector3.zero, Quaternion.identity, tableArea.transform);
		instance.transform.position = RandomPointInBox(centerSpawn.position,
			tableArea.GetComponent<RectTransform>().sizeDelta, instance);
	}

	private static Vector3 RandomPointInBox(Vector3 center, Vector2 size, GameObject instance) {
		return center + new Vector3(
			       (Random.value - .5f) * size.x,
			       (Random.value - .5f) * size.y,			       
			       0f
		       );

	}
}

