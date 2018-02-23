using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

	public GameObject card;
	public float spawnTime = 2f;
	public Transform[] spawnPoints;

	void Start () {
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

	void Spawn () {

		Debug.Log("Spawning");

		int spawnPointIndex = Random.Range(0, spawnPoints.Length);

		Instantiate(card, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
