using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogBox : MonoBehaviour {

	public static LogBox logs;
	public Text logText;
	private bool isFading = false;

	// Use this for initialization
	void Start () {
		logs = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void Log(string txt)
	{
		HighlightLogbox ();
		
		logText.text += "\n" + txt;

		FadeTextOut ();
	}

	public bool helper;

	public IEnumerator _FadeTextOut()
	{
		if (!isFading) 
		{
			isFading = true;
			helper = true;

			int i = 0;
			while ((i < 3)&&(helper)) 
			{
				yield return new WaitForSecondsRealtime (1f);
				i++;
			}
				
			float alpha;
			alpha = 1;

			while ((logText.color.a > 0f)&&(helper))
			{
				logText.color = new Color (logText.color.r, logText.color.g, logText.color.b, alpha);
				alpha -= 0.01f;
				yield return new WaitForSecondsRealtime (0.02f);
				//Debug.Log ("faded 1 alpha point");
			}
			isFading = false;
		}
	}

	public void HighlightLogbox()
	{
		if (isFading) 
		{
			helper = false;
			StopCoroutine (_FadeTextOut ());

		} 

		logText.color = new Color (logText.color.r, logText.color.g, logText.color.b, 1f);
	}

	public void FadeTextOut()
	{
		StartCoroutine (_FadeTextOut ());
	}

}
