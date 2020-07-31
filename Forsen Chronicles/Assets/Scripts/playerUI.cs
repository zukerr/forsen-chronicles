using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerUI : MonoBehaviour {


	public void DeathScreenOn()
	{
		UI.EnableDeathScreen ();
		StartCoroutine (FadeDeathscreenIn ());
		SoundEffects.sfx.OnDeath ();
	}

	public void SprinklerSound()
	{
		SoundEffects.sfx.OnSprinkler ();
	}

	public void NeverLuckySound()
	{
		SoundEffects.sfx.onAnything (SoundEffects.sfx.neverLucky);
	}

	public void BasicAttackSound()
	{
		SoundEffects.sfx.OnBasicAttack ();
	}

	public IEnumerator FadeDeathscreenIn()
	{
		float temp;
		Image g1, g2;
		Text g3;
		g1 = UI.deathScreen.GetComponent<Image> ();
		g2 = UI.deathScreen.GetComponentInChildren<Image> ();
		g3 = UI.deathScreen.transform.GetChild (0).GetComponentInChildren<Text> ();
		//Color c1 = new Color (50, 50, 50, temp);
		while (UI.deathScreen.GetComponent<Image> ().color.a != 255f) 
		{
			temp = UI.deathScreen.GetComponent<Image> ().color.a + 0.1f * Time.deltaTime;

			g1.color = new Color (g1.color.r, g1.color.g, g1.color.b, temp);
			g2.color = new Color (g2.color.r, g2.color.g, g2.color.b, temp); 
			g3.color = new Color (g3.color.r, g3.color.g, g3.color.b, temp);
			yield return null;
		}
	}
}
