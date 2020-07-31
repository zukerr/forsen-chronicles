using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {

	private bool triggered = false;

	public GameObject dialoguePrefab;

	//private GameObject g1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (triggered && Input.GetKeyDown (KeyCode.Space)) 
		{
			triggered = false;
	
			//display dialogue window
			NPCHandler.pressSpace.SetActive (false);
            InventoryEnabler.me.player.gameObject.GetComponent<PlayerMovement>().enabled = false;
			//g1 = Instantiate(dialoguePrefab, NPCHandler.dialogueWindow.transform);
			dialoguePrefab.SetActive (true);
			if (GetComponent<VendorNPC> () != null) {
				dialoguePrefab.GetComponent<Dialogue> ().dontAssignThis = gameObject.GetComponent<VendorNPC> ();
			}
			//1. Trade:
			//InventoryBase.vendorScreen.SetActive(true);
		}
	}

	private void OnTriggerEnter2D (Collider2D other)
	{
		triggered = true;
		NPCHandler.pressSpace.SetActive (true);
	}

	private void OnTriggerExit2D (Collider2D other)
	{
		triggered = false;
		NPCHandler.pressSpace.SetActive (false);
		/*
		if (g1 != null) 
		{
			Destroy (g1);
		}
		*/
		if (dialoguePrefab.activeSelf) {
			dialoguePrefab.SetActive (false);
		}

	}
}
