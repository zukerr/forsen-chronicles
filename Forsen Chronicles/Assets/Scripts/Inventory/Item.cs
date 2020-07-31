using UnityEngine;
using System.Collections;


public enum ItemType 
{
	trash,
	mana,
	health,
	weapon,
	helmet,
	shoulder,
	offhand,
	chest,
	gauntlet,
	necklace


};

public class Item : MonoBehaviour {

	public int ID;

	public string itName;
	public string itProps;
	public string itCost;

	public int itCostValue;

	public ItemType type;

	public bool equipable;
	public bool two_handed_weapon;

	//public EquipmentStats my_stats;

	public Sprite spriteNeutral;

	public Sprite spriteHighlighted;

	public int maxSize;

	public void UseItem(){

		switch (type) 
		{

		case ItemType.mana:
			Debug.Log ("mana potion used.");
			break;
		case ItemType.health:
			Debug.Log ("health potion used.");
			break;
		default:
			break;

		}

	}
		

}
