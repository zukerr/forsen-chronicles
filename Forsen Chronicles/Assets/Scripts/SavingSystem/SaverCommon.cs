using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaverCommon : MonoBehaviour {

	public static SaverCommon saver;

	public GameObject destination;

	//database of all items availible in the game, needed to load the game
	public GameObject item0;
	public GameObject item1;
	public GameObject item2;
	public GameObject item3;
	public GameObject item4;
	public GameObject item5;
	public GameObject item6;
	public GameObject item7;
	public GameObject item8;
	public GameObject item9;
	public GameObject item10;
	public GameObject item11;
	public GameObject item12;
	public GameObject item13;
	public GameObject item14;
	public GameObject item15;
	public GameObject item16;
	public GameObject item17;
	public GameObject item18;
	public GameObject item19;
	public GameObject item20;

	public GameObject[] itemsArray;

	void Start()
	{
		saver = this;
	}

	public static void LoadAndInstantiateInv(SerialInventory[] tableInput)
	{
		//GameObject destination = GameObject.Find ("Items");

		//make sure the destination is empty and ready to be filled with loaded items
		/*
		if (saver.destination.transform.childCount > 0) {
			while (saver.destination.transform.childCount > 0) {
				Destroy (saver.destination.transform.GetChild (0));
			}
		}
*/
		GameObject go1;
		InventoryBase.everySlotData = new Slot[40];
		//just to create reference
		WorldSetup._inventory.PrepareToSaveInventory ();
		//instantiate objects by their id
		for (int i = 0; i < 40; i++) 
		{
			if (tableInput [i] != null) 
			{
				go1 = Instantiate (saver.TurnIntoRealItem (tableInput [i]), saver.destination.transform);
				if (go1.GetComponent<Item> ().equipable == true) 
				{
					go1.GetComponent<Equipment> ().DontRandomizeStats = true;
					DeserializeEquipment (go1.GetComponent<Equipment> (), tableInput [i].equipmentData);
				}
				for (int j = 0; j < tableInput[i].stacksize; j++)
				{
					InventoryBase.everySlotData [i].AddItem (go1.GetComponent<Item> ());
				}
			}
		}
		WorldSetup._inventory.LoadInventory ();
	}

	public static void ClearItemsBox()
	{
		GameObject destination = GameObject.Find ("Items");

		if (destination.transform.childCount > 0) 
		{
			Destroy (destination.transform.GetChild (0));
		}
	}

	public static void LoadAndInstantiateEqPiece(SerialInventory dataInput, Slot target)
	{
		target.ClearSlot ();
		if (dataInput != null) 
		{
			GameObject destination = GameObject.Find ("Items");

			//Debug.Log (dataInput.equipmentData.strength);

			GameObject obj = Instantiate (saver.TurnIntoRealItem (dataInput), destination.transform);
			obj.GetComponent<Equipment> ().DontRandomizeStats = true;
			DeserializeEquipment (obj.GetComponent<Equipment> (), dataInput.equipmentData);
			//obj.GetComponent<Equipment> ().strength = dataInput.equipmentData.strength;


			target.AddItem (obj.GetComponent<Item> ());
		}
	}
		


	public GameObject TurnIntoRealItem(SerialInventory s1)
	{
		itemsArray = new GameObject[] 
		{
			item0,
			item1,
			item2,
			item3,
			item4,
			item5,
			item6,
			item7,
			item8,
			item9,
			item10,
			item11,
			item12,
			item13,
			item14,
			item15,
			item16,
			item17,
			item18,
			item19,
			item20
		};
			
		if (s1 != null) 
		{
			return itemsArray [s1.ID];
		} 
		else 
		{
			return null;
		}

	}

	public static SerialInventory[] InventoryTable()
	{
		SerialInventory[] table = new SerialInventory[40];

		for (int i = 0; i < 40; i++) 
		{
			table [i] = new SerialInventory ();

			if (InventoryBase.everySlotData [i].CurrentItem != null) 
			{
				table [i].ID = InventoryBase.everySlotData [i].CurrentItem.ID;
				table [i].equipable = InventoryBase.everySlotData [i].CurrentItem.equipable;
				table [i].stacksize = InventoryBase.everySlotData [i].Items.Count;
				if (table [i].equipable == true) 
				{
					table [i].equipmentData = SerializeEquipment ((Equipment)InventoryBase.everySlotData [i].CurrentItem);
					Debug.Log ("serialized equipment from inventory for place in table number: " + i);
				} 
				else 
				{
					table [i].equipmentData = null;
				}
			} 
			else 
			{
				table [i] = null;
			}
				
		}


		return table;
	}

	public static SerialInventory SaveablePieceOfEq(Equipment e2)
	{
		SerialInventory result = new SerialInventory ();

		if (e2 != null) {
			result.equipable = e2.equipable;
			result.ID = e2.ID;
			result.equipmentData = SerializeEquipment (e2);

			return result;
		} 
		else 
		{
			return null;
		}
	}


	public static SerializeIt SerializeEquipment (Equipment e1)
	{
		SerializeIt saveablePiece = new SerializeIt();

		saveablePiece.itName = e1.itName;
		saveablePiece.itProps = e1.itProps;
		saveablePiece.itCost = e1.itCost;

		saveablePiece.levelRequirement = e1.levelRequirement;

		switch (e1.wType) 
		{
		case weaponType.melee_heavy:
			saveablePiece.wType = 1;
			break;
		case weaponType.melee_light:
			saveablePiece.wType = 2;
			break;
		case weaponType.not_a_weapon:
			saveablePiece.wType = 3;
			break;
		case weaponType.ranged:
			saveablePiece.wType = 4;
			break;
		}

		saveablePiece.attack_min = e1.attack_min;
		saveablePiece.attack_max = e1.attack_max;

		saveablePiece.armor = e1.armor;
		saveablePiece.magic_resistance = e1.magic_resistance;

		saveablePiece.inteligence = e1.inteligence;
		saveablePiece.strength = e1.strength;
		saveablePiece.agility = e1.agility;
		saveablePiece.gay_percentage = e1.gay_percentage;
		saveablePiece.vitality = e1.vitality;

		return saveablePiece;
	}


	//this function loads the data from SerializeIt object, and sets up given equipment object, which was earlier instantiated using the unique ID assinged to it.
	public static void DeserializeEquipment (Equipment target, SerializeIt stream)
	{
		//Equipment target = new Equipment();

		target.itName = stream.itName;
		target.itProps = stream.itProps;
		target.itCost = stream.itCost;

		target.levelRequirement = stream.levelRequirement;

		switch (stream.wType) 
		{
		case 1:
			target.wType = weaponType.melee_heavy;
			break;
		case 2:
			target.wType = weaponType.melee_light;
			break;
		case 3:
			target.wType = weaponType.not_a_weapon;
			break;
		case 4:
			target.wType = weaponType.ranged;
			break;
		}

		target.attack_min = stream.attack_min;
		target.attack_max = stream.attack_max;

		target.armor = stream.armor;
		target.magic_resistance = stream.magic_resistance;

		target.inteligence = stream.inteligence;
		target.strength = stream.strength;
		target.agility = stream.agility;
		target.gay_percentage = stream.gay_percentage;
		target.vitality = stream.vitality;

		//return target;
	}




}
