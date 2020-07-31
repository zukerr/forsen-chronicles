using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PajladaDialogue2 : MonoBehaviour {

	public static PajladaDialogue2 me;

    public GameObject creditsTrigger;

	private bool helper = false;
	private Coroutine lastRoutine;

	public AudioClip _dialogue1;

	public static int loader = 0;

	// Use this for initialization
	void Awake () {
		me = this;
	}

	// Update is called once per frame
	void Update () {
		if (helper) {
			if ((Input.GetKeyDown (KeyCode.Return)) || (Input.GetKeyDown (KeyCode.Space))) {
				StopCoroutine (lastRoutine);
				InventoryEnabler.me.Subtitles.text = " ";
                //StartCoroutine (Dial1Part2 ());
                InventoryEnabler.me.player.gameObject.GetComponent<PlayerMovement>().enabled = true;
                helper = false;
			}
		}
	}

	public void Load()
	{
		switch (loader) 
		{
		case 0:
			break;
		case 1:
			GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().interactable = false;
			break;

		}
	}

	public void Dialogue1()
	{
		lastRoutine = StartCoroutine (Dial1 ());
	}

	public IEnumerator Dial1()
	{
		helper = true;
		SoundEffects.sfx.onAnything (_dialogue1);

		string s1 = "I knew you would succeed. That's great. We can focus on our mission now.";
		string s2 = "I heard some rumours that a man called Zeus the Potato,";
		string s3 = "one of the most famous members of Dank Knights Order,";
		string s4 = "already started to gather people for the rebellion. ";
		string s5 = "He is now most likely somewhere in the Gachi Steppes.";
		string s6 = "We should go there apart, to not raise any suspicions.";
		string s7 = "Let's meet in the nearest Inn, its not far from here.";

		GetComponent<NPC> ().dialoguePrefab.SetActive (false);

		InventoryEnabler.me.Subtitles.text = s1;
		yield return new WaitForSeconds (5.8f);
		InventoryEnabler.me.Subtitles.text = s2;
		yield return new WaitForSeconds (3.2f);
		InventoryEnabler.me.Subtitles.text = s3;
		yield return new WaitForSeconds (2.8f);
		InventoryEnabler.me.Subtitles.text = s4;
		yield return new WaitForSeconds (2.8f);
		InventoryEnabler.me.Subtitles.text = s5;
		yield return new WaitForSeconds (3.7f);
		InventoryEnabler.me.Subtitles.text = s6;
		yield return new WaitForSeconds (3.7f);
		InventoryEnabler.me.Subtitles.text = s7;
		yield return new WaitForSeconds (3.5f);
		InventoryEnabler.me.Subtitles.text = " ";


		QuestBase.questBase.EndQuest (QuestBase.questList [0]);
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().interactable = false;
        creditsTrigger.SetActive(true);
		loader = 1;
		GetComponent<NPC> ().dialoguePrefab.SetActive (true);
        InventoryEnabler.me.player.gameObject.GetComponent<PlayerMovement>().enabled = true;

        helper = false;
	}
}