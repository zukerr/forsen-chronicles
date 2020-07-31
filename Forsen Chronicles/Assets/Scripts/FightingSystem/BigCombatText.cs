using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BigCombatText : MonoBehaviour {


	public static BigCombatText me;
	public Text to_display;
	public float time_of_display = 5f;
	public string latest_quest = "xy";


	// Use this for initialization
	void Start () {

		me = this;
		to_display = GetComponent<Text> ();

	}



	// Update is called once per frame
	void Update () {



	}

	public void DisplayBigCombatText(string text)
	{
		Debug.Log ("Displaying big combat text");
		StartCoroutine (Inscription (text));
	}



	IEnumerator Inscription (string _text) {


		float time = 0;
		ScreenFader sf = GetComponent<ScreenFader> ();
		to_display.text = _text;

		yield return StartCoroutine (sf.FadeToClear ());

		while (time < time_of_display) {

			time += Time.deltaTime;

			yield return null;
		}

		yield return StartCoroutine (sf.FadeToBlack ());

	}

	public IEnumerator AnnounceQuest(string str)
	{

		float time = 0;
		latest_quest = str;
		ScreenFader sf = GetComponent<ScreenFader> ();
		to_display.text = str;

		yield return StartCoroutine (sf.FadeToClear ());

		while (time < 2f) 
		{
			time += Time.deltaTime;
			if (latest_quest != str) 
			{
				//time = time_of_display;
			}
			yield return null;
		}

			yield return StartCoroutine (sf.FadeToBlack ());
	}
}
