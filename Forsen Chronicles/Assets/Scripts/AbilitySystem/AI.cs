using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {


	public CameraController maincam;
	public AbilityMachine machine;
	GameObject[] all_targets;
	GameObject[] enemies;
	int enemies_count;
	public GameObject lootbox;
	private bool fightFinished = false;

	// Use this for initialization
	void Start () {

		all_targets = GameObject.FindGameObjectsWithTag ("target");
		enemies = GameObject.FindGameObjectsWithTag ("target");
		SetEnemies ();
	}
	
	// Update is called once per frame
	void Update () {

		if (AbilityMachine.players_turn == false) 
		{
			//turn off players interface
			//start turn of first opponent: give control to the AI: choose the move, execute animations, give turn to the next enemy or player(turn the interface back on) if there is no more enemies
			StartCoroutine(ExecuteEnemyTurns());
			AbilityMachine.players_turn = true;
		}
		
	}


	private void SetEnemies()
	{
		int i = 0;

		foreach (GameObject target in all_targets)
		{
			if (target.GetComponent<BasicUnitFunctions> ().friendly == false) 
			{
				enemies [i] = target;
				Debug.Log (enemies [i].name);
				i++;
			}
		}

		enemies_count = i;
	}

	private void CheckFightResult()
	{
		int j = 0;
		
		for (int i = 0; i < enemies_count; i++) 
		{
			if (enemies [i].GetComponent<BasicUnitFunctions> ().IsDead == true) 
			{
				j++;
			}
		}

		if (j == enemies_count) 
		{
			InfoStorage.fightResult = true;
			DropItems ();
			lootbox.GetComponent<LootboxHandler> ().EnablePages ();
			lootbox.SetActive(true);
			SoundEffects.sfx.OnWin ();
			fightFinished = true;
		}

	}

	private void DropItems()
	{
		Lootable.lootboxItemsIndex = 0;
		for (int i = 0; i < enemies_count; i++) 
		{
			enemies[i].GetComponent<Lootable> ().GenerateLoot ();
			Debug.Log ("loot generated");
		}
	}

	private IEnumerator ExecuteEnemyTurns()
	{
		CheckFightResult ();
		for (int i = 0; i < enemies_count; i++) 
		{
			if (enemies [i].GetComponent<BasicUnitFunctions> ().IsDead == false) 
			{
				Debug.Log ("Executor of this enemies' turn: " + enemies [i].name);
				BarsHandle.AdjustBars (enemies [i].GetComponent<BasicUnitFunctions> ());
				EnemyTurn (enemies [i]);
				//yield return new WaitForSeconds (3);
				//yield return null;

				while (AbilityBasic.animating2 == true) {
					yield return null;
				}

			}
		}

		maincam.ZoomCamIn ();
		BarsHandle.rightBars.SetActive (false);
		BarsHandle.displayRightBars = false;
		if (fightFinished == false) 
		{
			UI.Activate_interface_on_players_turn ();
		} 
		else 
		{
			fightFinished = false;
		}
	}

	private void EnemyTurn(GameObject villain)
	{
		switch (villain.GetComponent<BasicUnitFunctions>().unitType) 
		{

		case BasicUnitFunctions.UnitType.test_enemy:
			{
				test_enemyTurn(villain);
				break;
			}
		case BasicUnitFunctions.UnitType.weeb:
			{
				weeb_turn (villain);
				break;
			}
		case BasicUnitFunctions.UnitType.advice_fag:
			{
				advice_fag_turn(villain);
				break;
			}
		case BasicUnitFunctions.UnitType.wingman:
			{
				wingman_turn(villain);
				break;
			}


		}
	}

	private void test_enemyTurn(GameObject _villain)
	{
		//"if statements" tree, but to simplipfy the test there is only 1 possible turn
		machine.test_enemyBasicAttackAbilityFunction(_villain);
		AbilityBasic.animating2 = true;
	}

	private void weeb_turn(GameObject _villain)
	{
		machine.NyanpasuAbilityFunction (_villain);
		AbilityBasic.animating2 = true;
	}

	private void advice_fag_turn(GameObject _villain)
	{
		int temp_mana = (int)_villain.GetComponent<BasicUnitFunctions> ().mana;
		int rng;


		switch (temp_mana) 
		{
		case 20:
		case 30:
			{
				rng = Random.Range (1, 4);
				switch (rng) 
				{
				case 1:
					{
						machine.DatingAdviceAbilityFunction (_villain);
						break;
					}
				case 2:
					{
						machine.DepressionAdviceAbilityFunction (_villain);
						break;
					}
				case 3:
					{
						machine.StreamAdviceAbilityFunction (_villain);
						break;
					}
				}
				break;
			}
		case 10:
			{
				machine.DatingAdviceAbilityFunction (_villain);
				break;
			}
		case 0:
			{
				machine.StreamAdviceAbilityFunction (_villain);
				break;
			}
		}


		AbilityBasic.animating2 = true;
	}


	private void wingman_turn(GameObject _villain)
	{
		int temp_mana = (int)_villain.GetComponent<BasicUnitFunctions> ().mana;

		if (temp_mana > 0) 
		{
			machine.SmokeBombAbilityFunction (_villain);
		}
		else 
		{
			machine.WingedChargeAbilityFunction (_villain);
		}
		AbilityBasic.animating2 = true;
	}



}
