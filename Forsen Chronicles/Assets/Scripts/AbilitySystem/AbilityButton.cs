using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AbilityButton : MonoBehaviour {

	private AbilityBasic ability;
	public enum Abilities 
	{
		BasicAttack,
		Sprinklersen,
		HealingTouch
	};

	public Abilities _ability;
	public static GameObject activePlayer;
	public GameObject _player;
	public GameObject tooltip;
	public Button btn;

	public Text header;
	public Text body;
	public Text cost;


	// Use this for initialization
	void Start () {

		btn = GetComponent<Button> ();
		activePlayer = _player;
		SetAbility (_ability);
	}
	
	// Update is called once per frame
	void Update () {


		
	}

	public void SetAbility(Abilities abi)
	{
		switch (abi) 
		{
		case Abilities.Sprinklersen:
			ability = activePlayer.GetComponent<Sprinklersen> ();
			break;
		case Abilities.HealingTouch:
			ability = activePlayer.GetComponent<HealingTouch> ();
			break;
		case Abilities.BasicAttack:
			ability = activePlayer.GetComponent<BasicAttack> ();
			break;
		}
	}

	public void SetTooltip()
	{
		tooltip.SetActive (true);

		header.text = ability.trueName;
		body.text = ability.ability_desc;
		cost.text = ability.cost_str;
	}

	public void ClearTooltip()
	{
		tooltip.SetActive (false);

		header.text = " ";
		body.text = " ";
		cost.text = " ";
	}

	public void OnMouseEnter()
	{
		SetTooltip ();
	}

	public void OnMouseExit()
	{
		ClearTooltip ();
	}

}
