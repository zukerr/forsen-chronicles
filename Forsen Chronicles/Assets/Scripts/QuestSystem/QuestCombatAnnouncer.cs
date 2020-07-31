using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestCombatAnnouncer : MonoBehaviour {

	public static QuestCombatAnnouncer me;
	public Text to_display;
	public float time_of_display = 3f;
	//public string latest_quest = "xy";


	// Use this for initialization
	void Start () {

		me = this;
		to_display = GetComponent<Text> ();

	}



	// Update is called once per frame
	void Update () {



	}
		


	public IEnumerator AnnounceQuest(string str)
	{

		float time = 0;
		ScreenFader sf = GetComponent<ScreenFader> ();
		to_display.text = str;

		yield return StartCoroutine (sf.FadeToClear ());

		while (time < 2f) 
		{
			time += Time.deltaTime;
			yield return null;
		}

		yield return StartCoroutine (sf.FadeToBlack ());
	}
}
