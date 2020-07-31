using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

	public static bool _active = false;
	public static GameObject obj;
	public GameObject _firstActions;
	public static GameObject[] action_ui;
	public GameObject e1;
	public GameObject e2;
	public GameObject e3;
	public GameObject e4;
	public GameObject _deathScreen;
	public static GameObject firstActions;
	public static GameObject ui_handler;
	public static BigCombatText bigCombatText;
	public BigCombatText _bigCombatText;
	public static GameObject deathScreen;
	public GameObject tooltip;
	public static GameObject loadingScreen;
	public GameObject _loadingScreen;


	// Use this for initialization
	void Start () {

		action_ui = new GameObject[] {e1, e2, e3, e4};
		UI.firstActions = _firstActions;
		ui_handler = e4;
		bigCombatText = _bigCombatText;
		deathScreen = _deathScreen;
		loadingScreen = _loadingScreen;

	}
	
	// Update is called once per frame
	void Update () {

		if ((_active == true) && (Input.GetKeyDown (KeyCode.Escape))) 
		{
			obj.SetActive (false);
			_firstActions.SetActive (true);
			tooltip.SetActive (false);
		}	
	}

	public static void Disable (bool value)
	{
		foreach (GameObject elem in  UI.action_ui) 
		{
			if (elem.activeSelf != value) 
			{
				elem.SetActive (value);
			}
		}
	}

	public static void Activate_interface_on_players_turn()
	{
		UI.firstActions.SetActive (true);
		UI.ui_handler.SetActive (true);
	}

	public static void EnableDeathScreen()
	{
		if (UI.deathScreen.activeSelf == false) {
			UI.deathScreen.SetActive (true);
		} else {
			UI.deathScreen.SetActive (false);
		}
	}
}
