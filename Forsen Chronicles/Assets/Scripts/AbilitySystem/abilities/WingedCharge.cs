using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingedCharge : AbilityBasic {




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
		AbilityBasic.Target.DealPhisicalDamage (rldamage);
	}

	public override IEnumerator AnimCoroutine ()
	{
		//yield return WalkToCoroutine_enemy ();
		//change some bool in the anim to trigger animation
		UseMana ();
		WingedChargeSoundEffect();
		yield return _WingedCharge();
		DamageCalculation ();
		//yield return WalkBackCoroutine_enemy ();
		AbilityBasic.ClearTarget ();
		AbilityBasic.animating2 = false;
		this.enabled = false;
	}

	public bool helper = false;

	protected IEnumerator _WingedCharge()
	{
		helper = true;

		anim.SetBool ("winged charge", true);

		while (helper == true) 
		{
			yield return null;
		}

		anim.SetBool ("winged charge", false);
	}

	public void winged_helper()
	{
		helper = false;
	}

	public void WingedChargeSoundEffect()
	{
		SoundEffects.sfx.onWingedCharge ();
	}

}
