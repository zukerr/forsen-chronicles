using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorTooltip : MonoBehaviour {

	/*
	Vector2 upperRight;
	Vector2 upperLeft;
	Vector2 lowerRight;
	Vector2 lowerLeft;
*/
	Vector2 middleDown;
	Vector2 middleUp;

	public bool helper1 = false;
	public bool helper2 = false;

	// Use this for initialization
	void Awake () {
		/*
		upperRight = new Vector2 (1f, 1f);
		upperLeft = new Vector2 (0f, 1f);
		lowerRight = new Vector2 (1f, 0f);
		lowerLeft = new Vector2 (0f, 0f);
		*/
		middleDown = new Vector2 (0.5f, 1.2f);
		middleUp = new Vector2 (0.5f, -0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<RectTransform> ().offsetMax.y > 0) {
			helper1 = true;
		}
		if (GetComponent<RectTransform> ().offsetMax.y < 0) {
			helper1 = false;
		}
		if (GetComponent<RectTransform> ().offsetMin.y < 0) {
			helper2 = true;
		}
		if (GetComponent<RectTransform> ().offsetMin.y > 0) {
			helper2 = false;
		}

		if (helper2) {
			GetComponent<RectTransform> ().pivot = middleUp;
		}
		if (helper1) {
			GetComponent<RectTransform> ().pivot = middleDown;
		}

		transform.position = Input.mousePosition;
	}
}
