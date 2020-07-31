using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHandler : MonoBehaviour {

	public static bool mapActive = false;
	public static GameObject currentMap;
	public static GameObject prevoiusMap;
	public GameObject map;
	public GameObject miniMenu;

	//private AudioSource source;
	// Use this for initialization
	void Start () {

		//source = GetComponent<AudioSource> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if ((Input.GetKeyDown (KeyCode.M))&&(!GetComponent<InventoryEnabler>().quickMenu.activeSelf))
		{
			
			EnableMap ();

		}
		if ((mapActive)&&(Input.GetKeyDown (KeyCode.Mouse1))) {
			if (currentMap != null) {
				currentMap.SetActive (false);
				currentMap = prevoiusMap;
			}

		}
	}

	public void EnableContinent(GameObject cont)
	{
		cont.SetActive (true);
		currentMap = cont;
		if (prevoiusMap == null) {
			prevoiusMap = cont;
		}
	}

	public void EnableMap()
	{
		if (!map.activeInHierarchy) 
		{
			if (GetComponent<InventoryEnabler> ().inventory.activeSelf) {
				GetComponent<InventoryEnabler> ().inventory.SetActive (false);
			} else if (GetComponent<InventoryEnabler> ().abilityScreen.activeSelf) {
				GetComponent<InventoryEnabler> ().abilityScreen.SetActive (false);
			} else if (GetComponent<InventoryEnabler> ().vendorScreen.activeSelf) {
				VendorProps.MoveToVendorScreen (false);
				GetComponent<InventoryEnabler> ().vendorScreen.SetActive (false);
			} else if (GetComponent<InventoryEnabler> ().questScreen.activeSelf) {
				GetComponent<InventoryEnabler> ().questScreen.SetActive (false);
			}

			map.SetActive (true);
			mapActive = true;
			//miniMenu.SetActive (false);
		} 

		else 
		{
			map.SetActive (false);
			mapActive = false;
			//miniMenu.SetActive (true);
		}

        SoundEffects.sfx.OnMapOpen();
	}
}
