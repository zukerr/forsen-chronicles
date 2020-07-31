using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWorldMobs : MonoBehaviour {

	public int index;
	public int numberOfPrefabs;
	public GameObject prefab1;
	public GameObject prefab2;
	public GameObject prefab3;
	public GameObject prefab4;
	public GameObject prefab5;
	private int rng;

	// Use this for initialization
	void Start () {

		SpawnMobs ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnMobs()
	{
		rng = Random.Range (1, numberOfPrefabs);
		GameObject g1 = new GameObject();

		switch (rng) 
		{
		case 1:
			g1 = Instantiate (prefab1, gameObject.GetComponent<Transform> ());
			break;
		case 2:
			g1 = Instantiate (prefab2, gameObject.GetComponent<Transform> ());
			break;
		case 3:
			g1 = Instantiate (prefab3, gameObject.GetComponent<Transform> ());
			break;
		case 4:
			g1 = Instantiate (prefab4, gameObject.GetComponent<Transform> ());
			break;
		case 5:
			g1 = Instantiate (prefab5, gameObject.GetComponent<Transform> ());
			break;
		}

		g1.transform.position = gameObject.transform.position;
	}
}
