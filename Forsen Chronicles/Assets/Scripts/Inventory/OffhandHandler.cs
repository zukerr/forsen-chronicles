using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffhandHandler : MonoBehaviour {

	public Slot weapSlot;
	private Item prev_item;
	public Sprite normalSprite;
	public Sprite offhand_not_availible;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (weapSlot.IsEmpty == false) 
		{
			if ((weapSlot.CurrentItem.two_handed_weapon == true) && (prev_item != weapSlot.Items.Peek ())) {
				GetComponent<Slot> ().enabled = false;
				GetComponent<Button> ().enabled = false;
				GetComponent<Image> ().sprite = offhand_not_availible;

				prev_item = weapSlot.Items.Peek ();
			}

			if ((weapSlot.Items.Peek ().two_handed_weapon == false) && (prev_item != weapSlot.Items.Peek ())) {
				GetComponent<Slot> ().enabled = true;
				GetComponent<Button> ().enabled = true;
                if (GetComponent<Image>().sprite == offhand_not_availible)
                {
                    GetComponent<Image>().sprite = normalSprite;
                }

				prev_item = weapSlot.Items.Peek ();
			}
		}

		if((weapSlot.IsEmpty)&&(GetComponent<Slot>().enabled == false))
		{
			GetComponent<Slot> ().enabled = true;
			GetComponent<Button> ().enabled = true;
			GetComponent<Image> ().sprite = normalSprite;

			prev_item = null;
		}

	}
}
