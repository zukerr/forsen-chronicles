using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBombInst : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void smoke_helper()
	{
		transform.parent.gameObject.GetComponent<SmokeBomb> ().helper = false;
	}
}
