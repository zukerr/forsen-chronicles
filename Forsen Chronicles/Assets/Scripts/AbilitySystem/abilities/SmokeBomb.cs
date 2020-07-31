using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBomb : AbilityBasic {

	public GameObject smokeBombPrefab;
	public Transform target;


	// Use this for initialization
	public override void Start () {

		base.Start ();

		target = GameObject.Find ("Forsen").transform;

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
		float rldamage = Random.Range((int)(damage-8), (int)damage);
		AbilityBasic.Target.DealMagicalDamage (rldamage);
	}

	public override IEnumerator AnimCoroutine ()
	{
		//yield return WalkToCoroutine_enemy ();
		//change some bool in the anim to trigger animation
		UseMana();
		smokebombSoundEffect();
		yield return _Smokebomb();
		//yield return WalkBackCoroutine_enemy ();
		AbilityBasic.ClearTarget ();
		AbilityBasic.animating2 = false;
		this.enabled = false;
	}

	public bool helper = false;

	protected IEnumerator _Smokebomb()
	{
		anim.SetBool ("smokebomb", true);

		helper = true;
		GameObject bomb = Instantiate (smokeBombPrefab, transform);

		while (helper) 
		{
			yield return null;
		}

		while (Mathf.Floor (bomb.transform.position.x * 10f) != Mathf.Floor (target.position.x * 10f)) 
		{
			bomb.transform.position = Vector3.Lerp (bomb.transform.position, target.position, 1f * Time.deltaTime);
			yield return null;
		}

		DamageCalculation ();
		Destroy (bomb);
		anim.SetBool ("smokebomb", false);
	}

	public void smoke_helper()
	{
		helper = false;
	}

	public void smokebombSoundEffect()
	{
		SoundEffects.sfx.onSmokeBomb ();
	}

}
