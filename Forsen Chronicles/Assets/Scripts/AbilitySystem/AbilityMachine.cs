using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityMachine : MonoBehaviour {



	public Camera maincam;
	//public BigCombatText bigCombatText;
	public GameObject Player;
	private AbilityBasic sprinklersen;
	private AbilityBasic healingTouch;
	private AbilityBasic basicAttack;
	GameObject[] targets;

	public static bool players_turn = true;



	// Use this for initialization
	void Start () {

		targets = GameObject.FindGameObjectsWithTag ("target");
		sprinklersen = Player.GetComponent<Sprinklersen> ();
		healingTouch = Player.GetComponent<HealingTouch> ();
		basicAttack = Player.GetComponent<BasicAttack> ();
	}
	
	// Update is called once per frame
	void Update () {


		
	}

	//Players abilities
	public void SprinklersenAbilityFunction()
	{
		if (sprinklersen.ConditionCheck () == true) {
			//camera zoom out
			maincam.gameObject.GetComponent<CameraController> ().ZoomCamOut ();
			//enable ability component
			sprinklersen.enabled = true;
			//disable ui
			UI.Disable (false);
			//enable viable targets
			TurnOnTargets (sprinklersen);
		}

		else 
		{
			UI.bigCombatText.DisplayBigCombatText ("NOT ENOUGH MANA!");
		}

	}

	public void BasicAttackAbilityFunction()
	{
		if (basicAttack.ConditionCheck () == true) {
			//camera zoom out
			maincam.gameObject.GetComponent<CameraController> ().ZoomCamOut ();
			//enable ability component
			basicAttack.enabled = true;
			//disable ui
			UI.Disable (false);
			//enable viable targets
			TurnOnTargets (basicAttack);
		}

		else 
		{
			UI.bigCombatText.DisplayBigCombatText ("NOT ENOUGH MANA!");
		}

	}

	//Fairies' abilities

	public void HealingTouchAbilityFunction()
	{
		if (healingTouch.ConditionCheck () == true) {
			//camera zoom out
			maincam.gameObject.GetComponent<CameraController> ().ZoomCamOut ();
			//enable ability component
			healingTouch.enabled = true;
			//disable ui
			UI.Disable (false);
			//enable viable targets
			TurnOnTargets (healingTouch);
		}

		else 
		{
			UI.bigCombatText.DisplayBigCombatText ("NOT ENOUGH MANA!");
		}

	}

	//AI abilities
	public void test_enemyBasicAttackAbilityFunction(GameObject villain)
	{
		maincam.gameObject.GetComponent<CameraController>().ZoomCamOut();
		villain.GetComponent<test_enemyBasicAttack> ().enabled = true;
		UI.bigCombatText.DisplayBigCombatText(villain.GetComponent<test_enemyBasicAttack> ().trueName);
		AbilityBasic.Target = villain.GetComponent<test_enemyBasicAttack> ().SetRandomTarget ();
		Debug.Log (AbilityBasic.Target.gameObject.name);
		AbilityBasic._isAnimating = true;
	}

	public void NyanpasuAbilityFunction(GameObject villain)
	{
		maincam.gameObject.GetComponent<CameraController>().ZoomCamOut();
		villain.GetComponent<Nyanpasu> ().enabled = true;
		UI.bigCombatText.DisplayBigCombatText(villain.GetComponent<Nyanpasu> ().trueName);
		AbilityBasic.Target = villain.GetComponent<Nyanpasu> ().SetRandomTarget ();
		Debug.Log (AbilityBasic.Target.gameObject.name);
		AbilityBasic._isAnimating = true;
	}

	public void DatingAdviceAbilityFunction(GameObject villain)
	{
		maincam.gameObject.GetComponent<CameraController>().ZoomCamOut();
		villain.GetComponent<DatingAdvice> ().enabled = true;
		UI.bigCombatText.DisplayBigCombatText(villain.GetComponent<DatingAdvice> ().trueName);
		AbilityBasic.Target = villain.GetComponent<DatingAdvice> ().SetRandomTarget ();
		Debug.Log (AbilityBasic.Target.gameObject.name);
		AbilityBasic._isAnimating = true;
	}

	public void DepressionAdviceAbilityFunction(GameObject villain)
	{
		maincam.gameObject.GetComponent<CameraController>().ZoomCamOut();
		villain.GetComponent<DepressionAdvice> ().enabled = true;
		UI.bigCombatText.DisplayBigCombatText(villain.GetComponent<DepressionAdvice> ().trueName);
		AbilityBasic.Target = villain.GetComponent<DepressionAdvice> ().SetRandomTarget ();
		Debug.Log (AbilityBasic.Target.gameObject.name);
		AbilityBasic._isAnimating = true;
	}

	public void StreamAdviceAbilityFunction(GameObject villain)
	{
		maincam.gameObject.GetComponent<CameraController>().ZoomCamOut();
		villain.GetComponent<StreamAdvice> ().enabled = true;
		UI.bigCombatText.DisplayBigCombatText(villain.GetComponent<StreamAdvice> ().trueName);
		AbilityBasic.Target = villain.GetComponent<StreamAdvice> ().SetRandomTarget ();
		Debug.Log (AbilityBasic.Target.gameObject.name);
		AbilityBasic._isAnimating = true;
	}

	public void SmokeBombAbilityFunction(GameObject villain)
	{
		maincam.gameObject.GetComponent<CameraController>().ZoomCamOut();
		villain.GetComponent<SmokeBomb> ().enabled = true;
		UI.bigCombatText.DisplayBigCombatText(villain.GetComponent<SmokeBomb> ().trueName);
		AbilityBasic.Target = villain.GetComponent<SmokeBomb> ().SetRandomTarget ();
		Debug.Log (AbilityBasic.Target.gameObject.name);
		AbilityBasic._isAnimating = true;
	}

	public void WingedChargeAbilityFunction(GameObject villain)
	{
		maincam.gameObject.GetComponent<CameraController>().ZoomCamOut();
		villain.GetComponent<WingedCharge> ().enabled = true;
		UI.bigCombatText.DisplayBigCombatText(villain.GetComponent<WingedCharge> ().trueName);
		AbilityBasic.Target = villain.GetComponent<WingedCharge> ().SetRandomTarget ();
		Debug.Log (AbilityBasic.Target.gameObject.name);
		AbilityBasic._isAnimating = true;
	}

	public void TurnOnTargets(AbilityBasic ability)
	{
		foreach (GameObject target in targets) 
		{
			if (ability.my_targets == AbilityBasic.target_types.friendly) 
			{
				if ((target.GetComponent<BasicUnitFunctions> ().friendly == true)&&(target.GetComponent<BasicUnitFunctions> ().IsDead == false))
				{
					target.AddComponent<TargetProperties> ();
				}
			}

			if (ability.my_targets == AbilityBasic.target_types.enemy) 
			{
				if ((target.GetComponent<BasicUnitFunctions> ().friendly == false)&&(target.GetComponent<BasicUnitFunctions> ().IsDead == false))
				{
					target.AddComponent<TargetProperties> ();
				}
			}

			if ((ability.my_targets == AbilityBasic.target_types.all)&&(target.GetComponent<BasicUnitFunctions> ().IsDead == false))
			{
				target.AddComponent<TargetProperties> ();
			}

		}
	}



	public static void TurnOffTargets()
	{
		GameObject[] targets;
		targets = GameObject.FindGameObjectsWithTag ("target");

		foreach (GameObject target in targets) 
		{
			Destroy (target.GetComponent<TargetProperties> ());
		}
	}
		

}
