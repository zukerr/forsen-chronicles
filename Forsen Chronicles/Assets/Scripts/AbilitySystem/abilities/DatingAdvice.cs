using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatingAdvice : AbilityBasic {




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
		UseMana ();
		DatingAdviceSoundEffect();
		yield return _DatingAdvice();
		DamageCalculation ();
		//yield return WalkBackCoroutine_enemy ();
		AbilityBasic.ClearTarget ();
		AbilityBasic.animating2 = false;
		this.enabled = false;
	}

	public bool helper = false;

	protected IEnumerator _DatingAdvice()
	{
		helper = true;

		anim.SetBool ("dating advice", true);

		while (helper == true) 
		{
			yield return null;
		}

		anim.SetBool ("dating advice", false);
	}

	public void dating_helper()
	{
		helper = false;
	}

	public void DatingAdviceSoundEffect()
	{
		int rng = Random.Range (1, 4);

		switch (rng) 
		{
		case 1:
			SoundEffects.sfx.onDatingAdvice ();
			break;
		case 2:
			SoundEffects.sfx.onDatingAdvice2 ();
			break;
		case 3:
			SoundEffects.sfx.onDatingAdvice3 ();
			break;
		}
	}

}
