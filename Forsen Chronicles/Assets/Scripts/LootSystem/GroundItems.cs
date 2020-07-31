using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItems : MonoBehaviour {

	private bool spriteSetter = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (gameObject.transform.childCount > 0) {
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			spriteSetter = true;
		}

		else if ((gameObject.transform.childCount <= 0)&&(spriteSetter == true))
		{
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			spriteSetter = false;
		}


	}
}
