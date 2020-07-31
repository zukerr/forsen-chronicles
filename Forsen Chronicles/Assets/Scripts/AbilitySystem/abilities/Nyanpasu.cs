using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nyanpasu : AbilityBasic {




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
		AbilityBasic.Target.DealMagicalDamage (damage);


	}

	public override IEnumerator AnimCoroutine ()
	{
		yield return WalkToCoroutine_enemy ();
		//change some bool in the anim to trigger animation
		nyanpasuSoundEffect();
		yield return _Nyanpasu();
		AbilityCalculation ();
		yield return WalkBackCoroutine_enemy ();
		AbilityBasic.ClearTarget ();
		AbilityBasic.animating2 = false;
		this.enabled = false;
	}

	public bool helper = false;

	protected IEnumerator _Nyanpasu()
	{
		helper = true;

		anim.SetBool ("nyanpasu", true);

		while (helper == true) 
		{
			yield return null;
		}

		anim.SetBool ("nyanpasu", false);
	}

	public void nyan_helper()
	{
		helper = false;
	}

	public void nyanpasuSoundEffect()
	{
		SoundEffects.sfx.onNyanpasu ();
	}

}
