using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	public GameObject[] spawnableObjects;
	public GameObject tableArea;
	public float spawnTimer = 2f;
	public float startAmount = 7f;
    public float gameTimer = 200f;
	private Vector3 position;
	

	// Use this for initialization
	void Start () {
		Initialize();
        InvokeRepeating("SpawnObject", 2f, spawnTimer);
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

        do
        {
            instance.transform.localPosition = RandomPointInBox(tableArea.GetComponent<RectTransform>().rect.center,
            tableArea.GetComponent<RectTransform>().rect.size);
        } while (!isInsideParent(tableArea.GetComponent<RectTransform>().rect, instance.GetComponent<RectTransform>().rect));
		
	}

    private bool isInsideParent(Rect parent, Rect child)
    {
        return parent.Overlaps(child);
    }

    private static Vector3 RandomPointInBox(Vector3 center, Vector2 size) {
		return center + new Vector3(
			       (Random.value - .5f) * size.x,
			       (Random.value - .5f) * size.y,			       
			       0f
		       );

	}
}

