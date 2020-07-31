using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMap : MonoBehaviour {

	public PlayerMapDetector detector;
	public GameObject player;

	public GameObject current_pointer_parent;

	public string previous_map = "abc";
	public string current_map;

	public float local_x;
	public float local_y;

	public static bool change_pointer_parent = false;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void LateUpdate () {

		gameObject.transform.position = player.transform.position;
		current_map = detector.nazwa_mapy;
		local_x = transform.localPosition.x;
		local_y = transform.localPosition.y;
		if (current_map != previous_map) 
		{
			SetupTracker ();
			previous_map = current_map;
			change_pointer_parent = true;
		}
		
	}


	//As of right now, it seems like I need to assign current pointer parent to only one transform within the map (i.e. map1 in snusholme - maps 2,3,4 are irrelevant).
	public void SetupTracker()
	{
		gameObject.transform.SetParent (GameObject.Find (current_map).transform);
		current_pointer_parent = GameObject.Find (current_map).GetComponent<MapProps> ().UI_map;
	}
}
