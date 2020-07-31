using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour {

	public BasicUnitFunctions player;

	public Text offenseNamesText;
	public Text offenseValuesText;

	public Text defenseNamesText;
	public Text defenseValuesText;

	public Text basicStatsNames;
	public Text basicStatsValues;

	public Text dpsName;
	public Text dpsValue;

	private bool helper = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if ((BasicUnitFunctions.startingSetupHelper == true) && (helper == false)) {
			SetStats ();
			helper = true;
		}
		
	}

	public void SetStats()
	{
		offenseNamesText.text =
			"Attack Damage: " + "\n";

		offenseValuesText.text = 
			player.attack_min + "-" + player.attack_max + "\n";


		defenseNamesText.text =
			"Max. HP: " + "\n" +
			"Armor: " + "\n" +
			"Magic Resistance: " +  "\n";

		defenseValuesText.text = 
			player.max_health + "\n" +
			player.armor + "\n" +
			player.magic_resistance + "\n";

		basicStatsNames.text =
			"Level: " + "\n" +
			"Inteligence: " + "\n" +
			"Strength: " + "\n" +
			"Agility: " + "\n" +
			"Gay %: " + "\n" +
			"Vitality: " +  "\n";

		basicStatsValues.text = 
			player.level + "\n" +
			player.inteligence + "\n" +
			player.strength + "\n" +
			player.agility + "\n" +
			player.gay_percentage + "\n" +
			player.vitality + "\n";

		//dpsName.text = 
			

	}
}
