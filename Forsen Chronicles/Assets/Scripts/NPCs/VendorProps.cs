using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorProps : MonoBehaviour {

	public GameObject vendorBags;

	public static VendorProps me;
	// Use this for initialization
	void Awake () {
		me = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable()
	{
		MoveToVendorScreen (true);
	}

	private IEnumerator waitout()
	{
		MoveToVendorScreen (true);
		yield return new WaitForSeconds (0.001f);
		ClearVendorBags ();
	}

	public void ClearVendorBags()
	{
		int vendorSlotCount = vendorBags.transform.childCount;

		for (int i = 0; i < vendorSlotCount; i++) 
		{
			if (!vendorBags.transform.GetChild (i).gameObject.GetComponent<Slot> ().IsEmpty) 
			{
				vendorBags.transform.GetChild (i).gameObject.GetComponent<Slot> ().ClearSlot ();
			}
		}
	}

	public void PlaceEmpty(Item itm)
	{
		int vendorSlotCount = vendorBags.transform.childCount;

		for (int i = 0; i < vendorSlotCount; i++) 
		{
			if (vendorBags.transform.GetChild (i).gameObject.GetComponent<Slot> ().IsEmpty) 
			{
				vendorBags.transform.GetChild (i).gameObject.GetComponent<Slot> ().AddItem (itm);
				i = vendorSlotCount;
			}
		}
	}
		
	public static void MoveToVendorScreen(bool yes)
	{
		if (yes) 
		{
			InventoryEnabler.me.inventoryBags.transform.SetParent (InventoryEnabler.me.vendorScreen.transform);
			InventoryEnabler.me.inventoryBags.transform.localPosition = new Vector3 (153.25f, -413f, 0f);
		} 

		else 
		{
			InventoryEnabler.me.inventoryBags.transform.SetParent (InventoryEnabler.me.inventory.transform);
			InventoryEnabler.me.inventoryBags.transform.localPosition = InventoryBase.inventoryMainPosition;
		}
	}
}
