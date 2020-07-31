using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingTouch : AbilityBasic {





	// Use this for initialization
	public override void Start () {

		base.Start ();

		my_targets = target_types.friendly;


	}

	// Update is called once per frame
	public void Update () {

		if (_isAnimating != false) 
		{
			//start Coroutine of an animation, place the damage calculation in a good spot in the anim
			StartCoroutine(AnimCoroutine());
			_isAnimating = false;
			//end the turn
		}

	}

	public void HealingCalculation ()
	{
		float healing = Mathf.Floor(AbilityBasic.Target.max_health*0.4f);

		AbilityBasic.Target.health += healing;
	}
		

	public override IEnumerator AnimCoroutine ()
	{
		UI.bigCombatText.DisplayBigCombatText (trueName);
		UseMana ();
		SoundEffects.sfx.onAnything (SoundEffects.sfx.healingTouchAbilitySound);
		yield return _HealingTouch ();
		HealingCalculation ();
		AbilityBasic.ClearTarget ();
		AbilityMachine.players_turn = false;
		this.enabled = false;
	}

	public bool touchHelper = false;

	protected IEnumerator _HealingTouch()
	{
		touchHelper = true;

		anim.SetBool ("healing touch", true);

		while (touchHelper == true) 
		{
			yield return null;
		}

		anim.SetBool ("healing touch", false);
	}

	public void touch_helper()
	{
		touchHelper = false;
	}
		

}
