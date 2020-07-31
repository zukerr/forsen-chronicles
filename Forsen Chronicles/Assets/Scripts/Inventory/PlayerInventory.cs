using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {


	public InventoryBase inventory;
	public GameObject last_pickedup_item;
	public bool can_be_pickedup = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if ((can_be_pickedup == true)&&(Input.GetKeyDown("z"))) {

			if (InventoryBase.EmptySlots > 0) {
				GameObject item1 = last_pickedup_item.transform.GetChild (0).gameObject;
				item1.transform.SetParent (inventory.itemsBox.transform);
				inventory.AddItem (item1.GetComponent<Item> ());
			}
		}
	
	}

	private void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Item") {
			if (other.gameObject.transform.childCount > 0) 
			{
				last_pickedup_item = other.gameObject;
				can_be_pickedup = true;
			}
		}

	}

	private void OnTriggerExit2D(Collider2D other) 
	{
		if (other.tag == "Item") {

			can_be_pickedup = false;
		}

	}
}
