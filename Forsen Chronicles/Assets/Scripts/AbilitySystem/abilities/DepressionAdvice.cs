using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepressionAdvice : AbilityBasic {




	// Use this for initialization
	public override void Start () {

		base.Start ();

		//trueName = "Nyanpasu";
		//mana_cost = 5;
		//my_targets = target_types.friendly;


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
		float rldamage = Random.Range((int)(damage-5), (int)damage);
		AbilityBasic.Target.DealMagicalDamage (rldamage);


	}

	public override IEnumerator AnimCoroutine ()
	{
		//yield return WalkToCoroutine_enemy ();
		//change some bool in the anim to trigger animation
		DepressionAdviceSoundEffect();
		UseMana ();
		yield return _DepressionAdvice();
		DamageCalculation ();
		//yield return WalkBackCoroutine_enemy ();
		AbilityBasic.ClearTarget ();
		AbilityBasic.animating2 = false;
		this.enabled = false;
	}

	public bool helper = false;

	protected IEnumerator _DepressionAdvice()
	{
		helper = true;

		anim.SetBool ("depression advice", true);

		while (helper == true) 
		{
			yield return null;
		}

		anim.SetBool ("depression advice", false);
	}

	public void depression_helper()
	{
		helper = false;
	}

	public void DepressionAdviceSoundEffect()
	{
		SoundEffects.sfx.onDepressionAdvice ();
	}

}
