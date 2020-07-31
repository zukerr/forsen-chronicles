using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour {

	private bool pickup = false;
	public GameObject _item;
    public int ID;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ((pickup) && (Input.GetKeyDown (KeyCode.Z))) 
		{
            SoundEffects.sfx.OnItemPickup();
			InventoryEnabler.me.inventoryBags.GetComponent<InventoryBase> ().AddItemUpdated (_item);
            WorldItemData.worldItemsBools[ID] = false;
			Destroy (gameObject);
			pickup = false;
		}
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		pickup = true;
	}

	public void OnTriggerExit2D(Collider2D other)
	{
		pickup = false;
	}
}
