using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour {

	public GameObject Element;
	private GameObject FirstActions;


	// Use this for initialization
	void Start () {

		FirstActions = GameObject.Find ("First Actions");

	}
	
	// Update is called once per frame
	void Update () {

		
	}


	public void Enable ()
	{

		if (Element.activeSelf == false) {
			Element.SetActive (true);
			FirstActions.SetActive (false);
			UI._active = true;
			UI.obj = Element;
		} 

		else
		{
			Element.SetActive (false);
			FirstActions.SetActive (true);
			UI._active = false;
		}
	}


}
