using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BigMapName : MonoBehaviour {


	public static BigMapName me;

	public MapName t1;
	public Text to_display;
	public float time_of_display = 5f;
	bool Is_displaying = false;
	public string poprzednia_mapa = "abc";
	public string latest_quest = "xy";


	// Use this for initialization
	void Start () {

		to_display = GetComponent<Text> ();
		me = this;

	}



	// Update is called once per frame
	void Update () {




		if ((poprzednia_mapa != t1.name_of_map.text)&& (Is_displaying == false)){
			Debug.Log ("Displaying big map name");
			StartCoroutine (Inscription ());
		}
			
			
	}
		


	IEnumerator Inscription () {

		Is_displaying = true;
		float time = 0;
		poprzednia_mapa = t1.name_of_map.text;
		ScreenFader sf = GetComponent<ScreenFader> ();
		to_display.text = t1.name_of_map.text;
		yield return StartCoroutine (sf.FadeToClear ());

		while (time < time_of_display) {

			time += Time.deltaTime;

			if (poprzednia_mapa != t1.name_of_map.text) {
				time = time_of_display;
			}
			yield return null;
		}
		Is_displaying = false;
		yield return StartCoroutine (sf.FadeToBlack ());

	}


	public IEnumerator AnnounceQuest(string str)
	{
		if (!Is_displaying) 
		{
			Is_displaying = true;
			float time = 0;
			latest_quest = str;
			ScreenFader sf = GetComponent<ScreenFader> ();
			to_display.text = str;
			yield return StartCoroutine (sf.FadeToClear ());

			while (time < time_of_display) {

				time += Time.deltaTime;

				if (latest_quest != str) {
					time = time_of_display;
				}
				yield return null;
			}
			Is_displaying = false;
			yield return StartCoroutine (sf.FadeToBlack ());
		}
	}
}
