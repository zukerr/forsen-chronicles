using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum weaponType
{
	//the order here is very important --> its used for serialization
	melee_heavy,
	melee_light,
	not_a_weapon,
	ranged
};

public class Equipment : Item {

	public int levelRequirement;

	public weaponType wType;

	public float attack_min = 0;
	public float attack_max = 0;

	public float armor = 0;
	public float magic_resistance = 0;

	public float inteligence = 0;
	public float strength = 0;
	public float agility = 0;
	public float gay_percentage = 0;
	public float vitality = 0;


	public bool DontRandomizeStats = false;

	void Start()
	{
		equipable = true;
		if (DontRandomizeStats == false) 
		{
			EquipmentSetup ();
		}
	}

	public void EquipmentSetup()
	{
		switch(itName)
		{

		case "Dark Souls Hammer":
			attack_min = Random.Range ((int)500, (int)600);
			attack_max = Random.Range ((int)900, (int)1000);

			strength = Random.Range ((int)300, (int)500);
			gay_percentage = Random.Range ((int)-10, (int)-3);

			itProps = 
				"Level: " + levelRequirement + "\n" +
				"Damage: " + attack_min + "-" + attack_max + "\n" +
				"Strength: " + strength + "\n" +
				"Gay %: " + gay_percentage;
			break;

		case "Waifu Pillow":
			itProps = 
				"Level: " + levelRequirement + "\n" +
				"Armor: " + armor + "\n" +
				"Magic Resistance: " + magic_resistance + "\n" +
				"Vitality: " + vitality;
			break;

		case "Tyggbar's Dildo":
		case "Katana":
			itProps = 
				"Level: " + levelRequirement + "\n" +
				"Damage: " + attack_min + "-" + attack_max + "\n" +
				"Strength: " + strength;
			break;

		case "Forsenboys Shirt":
			itProps = 
				"Level: " + levelRequirement + "\n" +
				"Armor: " + armor + "\n" +
				"Magic Resistance: " + magic_resistance + "\n" +
				"Strength: " + strength + "\n" +
				"Vitality: " + vitality;
			break;

		case "Dishwasher Gloves":
			itProps = 
				"Level: " + levelRequirement + "\n" +
				"Armor: " + armor + "\n" +
				"Strength: " + strength + "\n" +
				"Vitality: " + vitality + "\n" +
				"Inteligence: " + inteligence;
			break;

		case "Twitch Expert's Necklace":
			itProps = 
				"Level: " + levelRequirement + "\n" +
				"Magic Resistance: " + magic_resistance + "\n" +
				"Strength: " + strength + "\n" +
				"Inteligence: " + inteligence;
			break;

		case "Noob's Shoulderguards":
			itProps = 
				"Level: " + levelRequirement + "\n" +
				"Armor: " + armor + "\n" +
				"Strength: " + strength + "\n" +
				"Vitality: " + vitality;
			break;

		case "Noob's Helmet":
			itProps = 
				"Level: " + levelRequirement + "\n" +
				"Armor: " + armor + "\n" +
				"Strength: " + strength + "\n" +
				"Inteligence: " + inteligence;
			break;
		}
	}


}
