using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {


	public Transform warptarget;

	IEnumerator OnTriggerEnter2D(Collider2D other) {


		Debug.Log ("An object collided");

		ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();

		yield return StartCoroutine (sf.FadeToBlack ());

		other.gameObject.transform.position = warptarget.position;
		//Camera.main.transform.position = warptarget.position;



		yield return StartCoroutine (sf.FadeToClear ());
	}

}
