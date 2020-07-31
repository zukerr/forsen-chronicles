using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBasic : MonoBehaviour {

	//Inheriting classes will be precisized abilities attached to the caster;
	//this component gets enabled by clicking the interface button

	public string trueName;
	public float mana_cost;
	public float damage;
	public BasicUnitFunctions Caster;
	public static BasicUnitFunctions Target;
	public enum target_types{friendly, enemy, all};
	public target_types my_targets;
	public Animator anim;
	Rigidbody2D rbody;
	public static bool _isAnimating = false;
	public static bool animating2 = false;

	public string cost_str;
	public string ability_desc;

	public virtual void Awake()
	{
		Caster = gameObject.GetComponent<BasicUnitFunctions>();
		SetStrings ();

	}

	public virtual void Start()
	{
		
		anim = GetComponent<Animator> ();
		rbody = GetComponent<Rigidbody2D>();
	}

	/*
	public virtual void Update () 
	{
		conditions_met = ConditionCheck ();
	}
	*/


	protected virtual void DamageCalculation(){}

	protected virtual void AbilityCalculation()
	{
		UseMana ();
		DamageCalculation ();
	}


	protected virtual void SetStrings()
	{
		cost_str = mana_cost + " MANA";
	}
		

	public static void ClearTarget()
	{
		AbilityBasic.Target = null;
	}

	public virtual IEnumerator AnimCoroutine (){
		yield return null;
	}

	public virtual void UseMana()
	{
		if (mana_cost <= Caster.mana) 
		{
			Caster.mana -= mana_cost;
		} 
	}

	public virtual bool ConditionCheck()
	{
		if (mana_cost <= Caster.mana) 
		{
			return true;
		} 

		else 
		{
			return false;
		}
	}

	Vector3 self_position_temp;

	public virtual IEnumerator WalkToCoroutine ()
	{
		self_position_temp = transform.position;

		Transform temp;
		temp = AbilityBasic.Target.gameObject.GetComponent<Transform> ();
		float _x = temp.position.x - 1.5f;
		float _y = temp.position.y;
		Vector2 movement = new Vector2 (_x - transform.position.x,_y - transform.position.y);

		anim.SetBool ("iswalking", true);
		while (transform.position.x < _x) 
		{
			rbody.MovePosition (rbody.position + movement * 1f * Time.deltaTime);
			yield return null;
		}

		//Debug.Log ("player moved");
		anim.SetBool ("iswalking", false);
		//yield return null;
	}



	public virtual IEnumerator WalkBackCoroutine ()
	{
		Vector3 temp = self_position_temp;
		float _x = temp.x;
		float _y = temp.y;
		Vector2 movement = new Vector2 (transform.position.x - _x, transform.position.y - _y);

		anim.SetBool ("iswalking", true);
		while (transform.position.x > _x) 
		{
			rbody.MovePosition (rbody.position + (-movement) * 1f * Time.deltaTime);
			yield return null;
		}

		//Debug.Log ("player moved back");
		anim.SetBool ("iswalking", false);
		//yield return null;
	}


	public virtual IEnumerator WalkToCoroutine_enemy ()
	{
		self_position_temp = transform.position;

		Transform temp;
		temp = AbilityBasic.Target.gameObject.GetComponent<Transform> ();
		float _x = temp.position.x + 1.5f;
		float _y = temp.position.y;
		Vector2 movement = new Vector2 (transform.position.x - _x, transform.position.y - _y);

		anim.SetBool ("iswalking", true);
		while (transform.position.x > _x) 
		{
			rbody.MovePosition (rbody.position + (-movement) * 1f * Time.deltaTime);
			yield return null;
		}

		//Debug.Log ("player moved");
		anim.SetBool ("iswalking", false);
		//yield return null;
	}

	public virtual IEnumerator WalkBackCoroutine_enemy ()
	{
		Vector3 temp = self_position_temp;
		float _x = temp.x;
		float _y = temp.y;
		Vector2 movement = new Vector2 (_x - transform.position.x,_y - transform.position.y);

		anim.SetBool ("iswalking", true);
		while (transform.position.x < _x) 
		{
			rbody.MovePosition (rbody.position + movement * 1f * Time.deltaTime);
			yield return null;
		}

		//Debug.Log ("player moved back");
		anim.SetBool ("iswalking", false);
		//yield return null;
	}

	public BasicUnitFunctions SetRandomTarget()
	{
		GameObject[] all_targets;
		all_targets = GameObject.FindGameObjectsWithTag ("target");
		BasicUnitFunctions Outcome;
		GameObject[] random_targets = GameObject.FindGameObjectsWithTag ("target");
		int i = 0;


		foreach (GameObject target in all_targets) 
		{
			if (my_targets == AbilityBasic.target_types.friendly) 
			{
				if (target.GetComponent<BasicUnitFunctions> ().friendly == true) 
				{
					random_targets [i] = target;
					i++;
				}
			}

			if (my_targets == AbilityBasic.target_types.enemy) 
			{
				if (target.GetComponent<BasicUnitFunctions> ().friendly == false) 
				{
					random_targets [i] = target;
					i++;
				}
			}

			if (my_targets == AbilityBasic.target_types.all) 
			{
				random_targets [i] = target;
				i++;
			}
		}

		Outcome = random_targets [Random.Range (0, (i-1))].GetComponent<BasicUnitFunctions> ();
		return Outcome;
	}
}
