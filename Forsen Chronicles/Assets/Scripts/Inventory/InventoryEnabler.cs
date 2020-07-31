using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryEnabler : MonoBehaviour {

	public BasicUnitFunctions player;
	public GameObject loadingScr;
	public GameObject inventory;
	public GameObject inventoryBags;
	public static InventoryEnabler me;
	public GameObject miniMenu;
	public GameObject quickMenu;
	public GameObject abilityScreen;
	public GameObject vendorScreen;
	public GameObject questScreen;
	public GameObject optionsScreen;
	public Text Subtitles;

	void Awake()
	{
		me = this;
	}

	// Use this for initialization
	void Start () {

		//source = GetComponent<AudioSource> ();
		//EnableInventory ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (((Input.GetKeyDown (KeyCode.I)) || (Input.GetKeyDown (KeyCode.B)))&&(!quickMenu.activeSelf)) {

            SoundEffects.sfx.OnInventoryOpen();
			EnableInventory ();
		}

		if ((Input.GetKeyDown (KeyCode.K))&&(!quickMenu.activeSelf)) {

            SoundEffects.sfx.OnInventoryOpen();
            EnableAbilityScreen ();
		}
			
		if ((Input.GetKeyDown (KeyCode.L)) && (!quickMenu.activeSelf)) 
		{
            SoundEffects.sfx.OnInventoryOpen();
            EnableQuestScreen ();
		}

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			EnableQuickMenu ();
		}
		
	}


	public void EnableInventory()
	{
		if (inventory.activeSelf) 
		{
			inventory.SetActive (false);
		//	miniMenu.SetActive (true);
		} 

		else 
		{
			if (GetComponent<MapHandler> ().map.activeSelf) 
			{
				GetComponent<MapHandler> ().map.SetActive (false);
			} 

			else if (abilityScreen.activeSelf) 
			{
				abilityScreen.SetActive (false);
			}

			else if (vendorScreen.activeSelf) 
			{
				VendorProps.MoveToVendorScreen (false);
				vendorScreen.SetActive (false);
			} 

			else if (questScreen.activeSelf) 
			{
				questScreen.SetActive (false);
			}



			inventory.SetActive (true);
			//miniMenu.SetActive (false);
			InventoryBase.playersEqChanged = true;
		}
	}

	public void EnableQuickMenu()
	{
		if (!quickMenu.activeSelf) 
		{
			if (GetComponent<MapHandler> ().map.activeSelf) 
			{
				GetComponent<MapHandler> ().EnableMap ();
			} 
			else if (inventory.activeSelf) 
			{
                SoundEffects.sfx.OnInventoryOpen();
                EnableInventory ();
			} 
			else if (abilityScreen.activeSelf) 
			{
                SoundEffects.sfx.OnInventoryOpen();
                EnableAbilityScreen ();
			} 
			else if (NPCHandler.vendorScreen.activeSelf) 
			{
				VendorProps.MoveToVendorScreen (false);
				NPCHandler.vendorScreen.SetActive (false);
			} 
			else if (questScreen.activeSelf) 
			{
                SoundEffects.sfx.OnInventoryOpen();
                EnableQuestScreen ();
			}
			else 
			{
				quickMenu.SetActive (true);
				Time.timeScale = 0.0f;
                SoundEffects.sfx.PauseOrUnpause();
			}
		}
		else if (optionsScreen.activeSelf) 
		{
			optionsScreen.SetActive (false);
		}

		else 
		{
			quickMenu.SetActive (false);
			Time.timeScale = 1.0f;
            SoundEffects.sfx.PauseOrUnpause();
        }
	}

	public void EnableAbilityScreen()
	{
		if (abilityScreen.activeSelf) 
		{
			abilityScreen.SetActive (false);
		} 

		else 
		{
			if (GetComponent<MapHandler> ().map.activeSelf) {
				GetComponent<MapHandler> ().map.SetActive (false);
			} else if (inventory.activeSelf) {
				inventory.SetActive (false);
			} else if (vendorScreen.activeSelf) {
				VendorProps.MoveToVendorScreen (false);
				vendorScreen.SetActive (false);
			} else if (questScreen.activeSelf) {
				questScreen.SetActive (false);
			}

			abilityScreen.SetActive (true);
		}
	}

	public void EnableQuestScreen()
	{
		if (questScreen.activeSelf) {
			questScreen.SetActive (false);
		} else {
			if (GetComponent<MapHandler> ().map.activeSelf) 
			{
				GetComponent<MapHandler> ().map.SetActive (false);
			} 

			else if (inventory.activeSelf) 
			{
				inventory.SetActive (false);
			}

			else if (abilityScreen.activeSelf) 
			{
				abilityScreen.SetActive (false);
			}

			else if (vendorScreen.activeSelf) 
			{
				VendorProps.MoveToVendorScreen (false);
				vendorScreen.SetActive (false);
			}

			questScreen.SetActive (true);
		}
	}


}
