﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_enemyBasicAttack : AbilityBasic {




	// Use this for initialization
	public override void Start () {

		base.Start ();

		trueName = "Test Ability";
		mana_cost = 0;
		my_targets = target_types.friendly;


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

		//damage = 10;
		AbilityBasic.Target.DealMagicalDamage (damage);


	}

	public override IEnumerator AnimCoroutine ()
	{
			yield return WalkToCoroutine_enemy ();
			//change some bool in the anim to trigger animation

			AbilityCalculation ();
			yield return WalkBackCoroutine_enemy ();
			AbilityBasic.ClearTarget ();
			AbilityBasic.animating2 = false;
			this.enabled = false;
	}

}
