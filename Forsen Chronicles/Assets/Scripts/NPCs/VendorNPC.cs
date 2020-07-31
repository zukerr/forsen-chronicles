using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorNPC : MonoBehaviour {

	public Item item1;
	public Item item2;
	public Item item3;
	public Item item4;
	public Item item5;
	public Item item6;
	public Item item7;
	public Item item8;
	public Item item9;
	public Item item10;

	public Slot slot1;
	public Slot slot2;
	public Slot slot3;
	public Slot slot4;
	public Slot slot5;
	public Slot slot6;
	public Slot slot7;
	public Slot slot8;
	public Slot slot9;
	public Slot slot10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddItemsToSlots()
	{
		SlotAdder (slot1, item1);
		SlotAdder (slot2, item2);
		SlotAdder (slot3, item3);
		SlotAdder (slot4, item4);
		SlotAdder (slot5, item5);
		SlotAdder (slot6, item6);
		SlotAdder (slot7, item7);
		SlotAdder (slot8, item8);
		SlotAdder (slot9, item9);
		SlotAdder (slot10, item10);
	}

	private void SlotAdder(Slot s1, Item i1)
	{
		if (s1 != null) {
			s1.AddItem (i1);
		}
	}

}
