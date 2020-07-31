using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : AbilityBasic {





	// Use this for initialization
	public override void Start () {

		base.Start ();

		//mana_cost = 10;
		my_targets = target_types.enemy;


	}

	// Update is called once per frame
	public void Update () {

		//base.Update ();

		if (_isAnimating != false) 
		{
			//start Coroutine of an animation, place the damage calculation in a good spot in the anim
			StartCoroutine(AnimCoroutine());
			_isAnimating = false;
			//end the turn
		}

	}

	protected override void DamageCalculation ()
	{
		base.DamageCalculation ();

		float dmg = Random.Range (Caster.attack_min, Caster.attack_max);
		AbilityBasic.Target.DealPhisicalDamage (Mathf.Floor(dmg));
	}

	public override IEnumerator AnimCoroutine ()
	{
		UI.bigCombatText.DisplayBigCombatText (trueName);
		//UseMana ();
		yield return WalkToCoroutine ();
		//change some bool in the anim to trigger animation
		yield return _BasicAttack();
		DamageCalculation ();
		yield return WalkBackCoroutine ();
		AbilityBasic.ClearTarget ();
		AbilityMachine.players_turn = false;
		this.enabled = false;
	}

	public bool basicAttackHelper = false;

	protected IEnumerator _BasicAttack()
	{
		basicAttackHelper = true;

		anim.SetBool ("basic attack", true);

		while (basicAttackHelper == true) 
		{
			yield return null;
		}

		anim.SetBool ("basic attack", false);
	}

	public void BasicAttack_helper()
	{
		basicAttackHelper = false;
	}

	/*
	protected override void SetStrings()
	{
		base.SetStrings ();

		trueName = "Sprinklersen";
		ability_desc = "Spit water on your enemy dealing magical single target damage.";
	}
*/

}
