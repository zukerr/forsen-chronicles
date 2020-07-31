using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetProperties : MonoBehaviour {

	//This component gets enabled on each enemy ([] by tag) by clicking the button of ability in the interface; also clicking it zooms the camera out and shades out the rest of the screen(besides availible targets)


	//public Sprite Targeted;
	//private Sprite normalState;
	private Animator anim;



	// Use this for initialization
	void Start () {

		//normalState = gameObject.GetComponent<SpriteRenderer> ().sprite;
		//Targeted = gameObject.GetComponent<BasicUnitFunctions> ().targetedSprite;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		
	}


	void OnMouseEnter()
	{
		//Debug.Log ("test");
		//gameObject.GetComponent<SpriteRenderer> ().sprite = Targeted;
		anim.SetBool ("targeted", true);
		//display hp bar - in different script
		BarsHandle.AdjustBars(GetComponent<BasicUnitFunctions>());
	}

	void OnMouseExit()
	{
		//Debug.Log ("test");
		//gameObject.GetComponent<SpriteRenderer> ().sprite = normalState;
		anim.SetBool ("targeted", false);
		Debug.Log ("Players cursor exited the enemy.");
		//turn of hp bar - in different script
		BarsHandle.rightBars.SetActive (false);
	}
		
	void OnMouseDown()
	{
		Debug.Log ("Using an Ability.");
		//gameObject.GetComponent<SpriteRenderer> ().sprite = normalState;
		anim.SetBool ("targeted", false);
		Debug.Log ("PLAYER CLICKED ON AN ENEMY, TURNING OFF HIGHLIGHT");
		if (anim.GetBool ("targeted")) {
			anim.SetBool ("targeted", false);
		}
		//Trigger ability(set target as this)
		BarsHandle.AdjustBars(GetComponent<BasicUnitFunctions>());
		BarsHandle.displayRightBars = true;
		AbilityBasic.Target = gameObject.GetComponent<BasicUnitFunctions>();
		Debug.Log (AbilityBasic.Target.gameObject.name);
		AbilityBasic._isAnimating = true;
		AbilityMachine.TurnOffTargets ();
	}


}
