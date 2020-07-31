using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCtransporter : MonoBehaviour {

	public static NPCtransporter me;

	public GameObject toActivate;
	public GameObject toDisable;

	// Use this for initialization
	void Start () {
		me = this;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void OnTriggerEnter2D (Collider2D other)
	{
		MoveNpc ();
	}

	public void MoveNpc()
	{
		toActivate.SetActive (true);
		toDisable.SetActive (false);
		gameObject.SetActive (false);
	}

}
