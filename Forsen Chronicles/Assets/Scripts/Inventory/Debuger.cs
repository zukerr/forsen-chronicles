using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (InventoryBase.from != null) {
			Debug.Log ("FROM FULL");
		}
		
	}
}
