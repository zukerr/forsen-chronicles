using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPointer : MonoBehaviour {

	public GameObject tracker;

	public float my_x;
	public float my_y;

	// Use this for initialization
	void OnEnable () {

		if (TrackMap.change_pointer_parent) 
		{
			gameObject.transform.SetParent (tracker.GetComponent<TrackMap> ().current_pointer_parent.transform);
			TrackMap.change_pointer_parent = false;
		}

		SetupCords ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (TrackMap.change_pointer_parent) 
		{
			gameObject.transform.SetParent (tracker.GetComponent<TrackMap> ().current_pointer_parent.transform);
			TrackMap.change_pointer_parent = false;
		}

		SetupCords ();


	}

	public void SetupCords()
	{
		my_x = (tracker.GetComponent<TrackMap> ().local_x / (tracker.transform.parent.gameObject.GetComponent<MapProps> ().sizeInPixels.x / 100)) * transform.parent.GetComponent<RectTransform> ().rect.width;
		my_y = (tracker.GetComponent<TrackMap> ().local_y / (tracker.transform.parent.gameObject.GetComponent<MapProps> ().sizeInPixels.y / 100)) * transform.parent.GetComponent<RectTransform> ().rect.height;

		transform.localPosition = new Vector3 (my_x, my_y);
	}
}
