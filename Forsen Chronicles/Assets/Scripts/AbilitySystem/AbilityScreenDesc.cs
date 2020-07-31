using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityScreenDesc : MonoBehaviour {

	public string title;
	public string description;
	public string cost;

	public GameObject rightPage;

	private Text t1;
	private Text t2;
	private Text t3;


	// Use this for initialization
	void Start () {
		t1 = rightPage.transform.GetChild (0).GetComponent<Text> ();
		t2 = rightPage.transform.GetChild (1).GetComponent<Text> ();
		t3 = rightPage.transform.GetChild (2).GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DisplayAbility()
	{
		t1.text = title;
		t2.text = description;
		t3.text = cost;
	}

	public void TurnOffDescription()
	{
		t1.text = " ";
		t2.text = " ";
		t3.text = " ";
	}
}
