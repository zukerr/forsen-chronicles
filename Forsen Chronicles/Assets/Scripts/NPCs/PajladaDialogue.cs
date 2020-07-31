using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PajladaDialogue : MonoBehaviour {

	public static PajladaDialogue me;

	private bool helper = false;
	private Coroutine lastRoutine;

	public GameObject transporter;
    public GameObject pajlada2;

	public GameObject weebQuestReward1;
	public GameObject weebQuestReward2;
	public GameObject weebQuestReward3;

	public AudioClip pajladaDialogue1;
	public AudioClip pajladaDialogue2;
	public AudioClip pajladaDialogue3;
	public AudioClip pajladaDialogue4;
	public AudioClip pajladaDialogue5_1;
	public AudioClip pajladaDialogue5_2;

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
                InventoryEnabler.me.player.gameObject.GetComponent<PlayerMovement>().enabled = true;
                //StartCoroutine (Dial1Part2 ());
                helper = false;
			}
		}
	}

	public void Load()
	{
		switch (loader) 
		{
		case 0:
			{
				break;
			}
		case 1:
			{
				GetComponent<NPC> ().dialoguePrefab.GetComponent<Dialogue> ().ClearDialogueWindow ();
				GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Text> ().text = "1. Can I go now?";
				GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.RemoveAllListeners ();
				GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.AddListener (Dialogue4);
				break;
			}
		case 2:
			{
				GetComponent<NPC> ().dialoguePrefab.GetComponent<Dialogue> ().ClearDialogueWindow ();
				GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Text> ().text = "1. Can I go now?";
				GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.RemoveAllListeners ();
				GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.AddListener (Dialogue4);
				GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().interactable = false;
				GetComponent<NPC> ().dialoguePrefab.transform.GetChild (1).GetComponent<Text> ().text = "2. I dealt with the weebs.";
				GetComponent<NPC> ().dialoguePrefab.transform.GetChild (1).GetComponent<Button> ().onClick.AddListener (Dialogue5);
				break;
			}
        case 3:
            {
                Destroy(GetComponent<NPC>());
                pajlada2.SetActive(true);
                gameObject.SetActive(false);
                break;
            }

		}
	}

	public void Dialogue1()
	{
		lastRoutine = StartCoroutine (Dial1 ());
	}
	public void Dialogue2()
	{
		lastRoutine = StartCoroutine (Dial2 ());
	}
	public void Dialogue3()
	{
		lastRoutine = StartCoroutine (Dial3 ());
	}
	public void Dialogue4()
	{
		lastRoutine = StartCoroutine (Dial4 ());
	}
	public void Dialogue5()
	{
		if (QuestBase.questList [1].state == State.ongoing) 
		{
			lastRoutine = StartCoroutine (Dial5_1 ());
		}

		else if (QuestBase.questList [1].state == State.completed) 
		{
			lastRoutine = StartCoroutine (Dial5_2 ());
		}
	}

	public IEnumerator Dial1()
	{
		helper = true;
		SoundEffects.sfx.onAnything (pajladaDialogue1);

		string s1 = "Strangely enough, it wasn't that hard.";
		string s2 = "I just needed to follow the blood trail and dodge patrols of blizzard's acolytes.";
		string s3 = "And the fact that every inn that came in your way";
		string s4 = "was complaining about a stranger commencing brawls just made it easier.";

		GetComponent<NPC> ().dialoguePrefab.SetActive (false);

		InventoryEnabler.me.Subtitles.text = s1;
		yield return new WaitForSeconds (3);
		InventoryEnabler.me.Subtitles.text = s2;
		yield return new WaitForSeconds (4.75f);
		InventoryEnabler.me.Subtitles.text = s3;
		yield return new WaitForSeconds (2);
		InventoryEnabler.me.Subtitles.text = s4;
		yield return new WaitForSeconds (4.2f);
		InventoryEnabler.me.Subtitles.text = " ";

		Debug.Log ("activating dialog window after dial1");
		GetComponent<NPC> ().dialoguePrefab.SetActive (true);

		helper = false;
	}

	public IEnumerator Dial2()
	{
		helper = true;
		SoundEffects.sfx.onAnything (pajladaDialogue2);

		string s1 = "I'm fairly certain that last patrol that seemed to be intrested in me lost track in treehunting woods.";

		GetComponent<NPC> ().dialoguePrefab.SetActive (false);

		InventoryEnabler.me.Subtitles.text = s1;
		yield return new WaitForSeconds (5.8f);
		InventoryEnabler.me.Subtitles.text = " ";
		Debug.Log ("activating dialog window after dial2");
		GetComponent<NPC> ().dialoguePrefab.SetActive (true);

		helper = false;
	}

	public IEnumerator Dial3()
	{
		helper = true;
		SoundEffects.sfx.onAnything (pajladaDialogue3);

		string s1 = "Well, I was sure that you are already preparing an uprising.";
		string s2 = "But, looking at you, it was not your priority in last weeks.";
		string s3 = "Now I clearly see, that without me, you cannot do anything.";
		string s4 = "Don't worry, I already thought of a plan.";
		string s5 = "First, you need to find yourself a proper girl.";
		string s6 = "She is required to keep you sane, and my plan needs you as the leader.";
		string s7 = "One really pretty chick lives nearby, I think you should talk to her.";

		GetComponent<NPC> ().dialoguePrefab.SetActive (false);

		InventoryEnabler.me.Subtitles.text = s1;
		yield return new WaitForSeconds (4.5f);
		InventoryEnabler.me.Subtitles.text = s2;
		yield return new WaitForSeconds (4.5f);
		InventoryEnabler.me.Subtitles.text = s3;
		yield return new WaitForSeconds (4.25f);
		InventoryEnabler.me.Subtitles.text = s4;
		yield return new WaitForSeconds (3.25f);
		InventoryEnabler.me.Subtitles.text = s5;
		yield return new WaitForSeconds (3.5f);
		InventoryEnabler.me.Subtitles.text = s6;
		yield return new WaitForSeconds (4.8f);
		InventoryEnabler.me.Subtitles.text = s7;
		yield return new WaitForSeconds (4.2f);
		InventoryEnabler.me.Subtitles.text = " ";

		GetComponent<NPC> ().dialoguePrefab.GetComponent<Dialogue> ().StartQ ();
		GetComponent<NPC> ().dialoguePrefab.GetComponent<Dialogue> ().ClearDialogueWindow ();
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Text> ().text = "1. Can I go now?";
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.RemoveAllListeners ();
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.AddListener (Dialogue4);
		loader = 1;
		Debug.Log ("activating dialog window after dial3");
		GetComponent<NPC> ().dialoguePrefab.SetActive (true);

		helper = false;
	}

	public IEnumerator Dial4()
	{
		helper = true;
		SoundEffects.sfx.onAnything (pajladaDialogue4);

		string s1 = "Wait a second, I don't want you to die that soon.";
		string s2 = "You should first remind yourself how to fight, before I hand you a real weapon.";
		string s3 = "See those weebs wandering around?";
		string s4 = "It shouldn't be that hard to show them who is the boss.";
		string s5 = "Kill at least 5 of them and then come back to me for some basic equipment.";

		GetComponent<NPC> ().dialoguePrefab.SetActive (false);

		InventoryEnabler.me.Subtitles.text = s1;
		yield return new WaitForSeconds (4);
		InventoryEnabler.me.Subtitles.text = s2;
		yield return new WaitForSeconds (4.5f);
		InventoryEnabler.me.Subtitles.text = s3;
		yield return new WaitForSeconds (2.5f);
		InventoryEnabler.me.Subtitles.text = s4;
		yield return new WaitForSeconds (3.4f);
		InventoryEnabler.me.Subtitles.text = s5;
		yield return new WaitForSeconds (4.1f);
		InventoryEnabler.me.Subtitles.text = " ";

		GetComponent<NPC> ().dialoguePrefab.GetComponent<Dialogue> ().StartQ2();
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (1).GetComponent<Text> ().text = "2. I dealt with the weebs.";
		//GetComponent<NPC> ().dialoguePrefab.transform.GetChild (1).GetComponent<Button> ().onClick.RemoveAllListeners ();
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (1).GetComponent<Button> ().onClick.AddListener (Dialogue5);
		loader = 2;
		Debug.Log ("activating dialog window after dial4");
		GetComponent<NPC> ().dialoguePrefab.SetActive (true);
        InventoryEnabler.me.player.gameObject.GetComponent<PlayerMovement>().enabled = true;

        helper = false;
	}


	public IEnumerator Dial5_1()
	{
		helper = true;
		SoundEffects.sfx.onAnything (pajladaDialogue5_1);
		//if quest not completed

		string s1 = "You didn't kill enough of them!";
		string s2 = "Now they will replicate and all this efford will go to waste!";
		string s3 = "Go back and finish your job.";
		GetComponent<NPC> ().dialoguePrefab.SetActive (false);

		InventoryEnabler.me.Subtitles.text = s1;
		yield return new WaitForSeconds (2.3f);
		InventoryEnabler.me.Subtitles.text = s2;
		yield return new WaitForSeconds (4);
		InventoryEnabler.me.Subtitles.text = s3;
		yield return new WaitForSeconds (2);
		InventoryEnabler.me.Subtitles.text = " ";

		Debug.Log ("activating dialog window after dial5");
		GetComponent<NPC> ().dialoguePrefab.SetActive (true);
        InventoryEnabler.me.player.gameObject.GetComponent<PlayerMovement>().enabled = true;
        helper = false;
	}

	public IEnumerator Dial5_2()
	{
		helper = true;
		SoundEffects.sfx.onAnything (pajladaDialogue5_2);

		string s1 = "Well done, you still remember how to use your basic attacks. ";
		string s2 = "Now you can take this sword and some armor.";
		string s3 = "I will wait for you at the snusholme border.";
		string s4 = "Dont forget to bring a woman with you!";
		GetComponent<NPC> ().dialoguePrefab.SetActive (false);

		InventoryEnabler.me.Subtitles.text = s1;
		yield return new WaitForSeconds (4.4f);
		InventoryEnabler.me.Subtitles.text = s2;
		yield return new WaitForSeconds (3);
		InventoryEnabler.me.Subtitles.text = s3;
		yield return new WaitForSeconds (3);
		InventoryEnabler.me.Subtitles.text = s4;
		yield return new WaitForSeconds (2);
		InventoryEnabler.me.Subtitles.text = " ";

		InventoryEnabler.me.inventoryBags.GetComponent<InventoryBase> ().AddItemUpdated (weebQuestReward1);
		InventoryEnabler.me.inventoryBags.GetComponent<InventoryBase> ().AddItemUpdated (weebQuestReward2);
		InventoryEnabler.me.inventoryBags.GetComponent<InventoryBase> ().AddItemUpdated (weebQuestReward3);

		QuestBase.questBase.EndQuest (QuestBase.questList [1]);
		//transporter.SetActive (true);
		GetComponent<NPC> ().dialoguePrefab.GetComponent<Dialogue> ().ClearDialogueWindow ();
        //Destroy (GetComponent<CircleCollider2D> ());
        Destroy(GetComponent<NPC>());
        loader = 3;
        InventoryEnabler.me.player.gameObject.GetComponent<PlayerMovement>().enabled = true;
        //	Debug.Log ("activating dialog window after dial4");
        //	GetComponent<NPC> ().dialoguePrefab.SetActive (true);

        helper = false;
        yield return new WaitForSeconds(5);
        pajlada2.SetActive(true);
        gameObject.SetActive(false);

    }
}
