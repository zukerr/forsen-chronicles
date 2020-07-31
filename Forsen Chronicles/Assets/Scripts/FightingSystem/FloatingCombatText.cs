using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingCombatText : MonoBehaviour {
	
	//public string current_FloatingText_player;
	public Text to_display;
	public float time_of_display = 5f;
	//bool Is_displaying = false;
	public string previous_combat_text = "abc";
	public BasicUnitFunctions player;


	// Use this for initialization
	void Start () {

		to_display = GetComponent<Text> ();
		//player = GameObject.Find ("player").GetComponent<BasicUnitFunctions> ();
	}




	void LateUpdate () {

		/*

		to_display.text = player.hp_change_str;

		if (player.prev_hp != player.health){
			Debug.Log ("Displaying floating combat text for player");
			StartCoroutine (Inscription ());
		}

*/


	}



	public IEnumerator Inscription () {

		//Is_displaying = true;
		float time = 0;
		previous_combat_text = player.hp_change_str;
		ScreenFader sf = GetComponent<ScreenFader> ();
		//to_display.text = player.hp_change_str;
		yield return StartCoroutine (sf.FadeToClear ());

		while (time < time_of_display) {

			time += Time.deltaTime;

			if (previous_combat_text != player.hp_change_str) {
				time = time_of_display;
			}

			yield return null;
		}
		//Is_displaying = false;
		yield return StartCoroutine (sf.FadeToBlack ());

	}
}
