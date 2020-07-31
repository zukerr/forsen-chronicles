using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinklersen : AbilityBasic {





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
		int maxdmg = (int)Mathf.Floor((Caster.inteligence * 1.5f) + 5);
		int mindmg = Mathf.FloorToInt (0.7f * maxdmg);

		damage = Random.Range (mindmg, (maxdmg + 1));
		AbilityBasic.Target.DealMagicalDamage (damage);
	}

	public override IEnumerator AnimCoroutine ()
	{
		UI.bigCombatText.DisplayBigCombatText (trueName);
		UseMana ();
		yield return WalkToCoroutine ();
		//change some bool in the anim to trigger animation
		yield return Sprinkler();
		DamageCalculation ();
		yield return WalkBackCoroutine ();
		AbilityBasic.ClearTarget ();
		AbilityMachine.players_turn = false;
		this.enabled = false;
	}

	public bool sprinklerHelper = false;

	protected IEnumerator Sprinkler()
	{
		sprinklerHelper = true;

		anim.SetBool ("_sprinkler", true);

		while (sprinklerHelper == true) 
		{
			yield return null;
		}

		anim.SetBool ("_sprinkler", false);
	}

	public void sprinkler_helper()
	{
		sprinklerHelper = false;
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
