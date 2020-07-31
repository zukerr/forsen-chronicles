using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerGuard1Dialogue : MonoBehaviour {

	public static TowerGuard1Dialogue me;
	private bool helper = false;
	private Coroutine lastRoutine;

	public GameObject adviceFagsQuestReward;

	public AudioClip _dialogue1;
	public AudioClip _dialogue2;
	public AudioClip _dialogue3_1;
	public AudioClip _dialogue3_2;

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
			GetComponent<NPC> ().dialoguePrefab.GetComponent<Dialogue> ().ClearDialogueOption (0);
			GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Text> ().text = "1. I'm done with advice fags.";
			GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.RemoveAllListeners ();
			GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.AddListener (Dialogue3);
			break;
        case 2:
            GetComponent<NPC>().dialoguePrefab.GetComponent<Dialogue>().ClearDialogueOption(0);
            GetComponent<NPC>().dialoguePrefab.transform.GetChild(0).GetComponent<Text>().text = "1. I'm done with advice fags.";
            GetComponent<NPC>().dialoguePrefab.transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
            GetComponent<NPC>().dialoguePrefab.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(Dialogue3);
            GetComponent<NPC>().dialoguePrefab.transform.GetChild(0).GetComponent<Button>().interactable = false;
            break;

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
		if (QuestBase.questList [2].state == State.ongoing) 
		{
			lastRoutine = StartCoroutine (Dial3_1 ());
		}

		else if (QuestBase.questList [2].state == State.completed) 
		{
			lastRoutine = StartCoroutine (Dial3_2 ());
		}
	}

	public IEnumerator Dial1()
	{
		helper = true;
		SoundEffects.sfx.onAnything (_dialogue1);

		string s1 = "Well, actually you could do a favor for both of us and deal with those advice fags.";
		string s2 = "They already gathered around the way to the home of the pretty lady of Snusholme, as some people call her.";
		string s3 = "It's easier to teach them a lesson one by one, than fight them all together after they spotted their prey.";
		string s4 = "I can give you something useful after you're done.";

		GetComponent<NPC> ().dialoguePrefab.SetActive (false);

		InventoryEnabler.me.Subtitles.text = s1;
		yield return new WaitForSeconds (5.3f);
		InventoryEnabler.me.Subtitles.text = s2;
		yield return new WaitForSeconds (5.9f);
		InventoryEnabler.me.Subtitles.text = s3;
		yield return new WaitForSeconds (6.2f);
		InventoryEnabler.me.Subtitles.text = s4;
		yield return new WaitForSeconds (2.8f);
		InventoryEnabler.me.Subtitles.text = " ";

		//GetComponent<NPC> ().dialoguePrefab.GetComponent<Dialogue> ().StartQ ();
        QuestBase.questBase.StartQuest(QuestBase.questList[2]);
        GetComponent<NPC> ().dialoguePrefab.GetComponent<Dialogue> ().ClearDialogueOption (0);
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Text> ().text = "1. I'm done with advice fags.";
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.RemoveAllListeners ();
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.AddListener (Dialogue3);
		loader = 1;
		GetComponent<NPC> ().dialoguePrefab.SetActive (true);

		helper = false;
	}

	public IEnumerator Dial2()
	{
		helper = true;
		SoundEffects.sfx.onAnything (_dialogue2);

		string s1 = "Nothing, and no.";

		GetComponent<NPC> ().dialoguePrefab.SetActive (false);

		InventoryEnabler.me.Subtitles.text = s1;
		yield return new WaitForSeconds (1.7f);
		InventoryEnabler.me.Subtitles.text = " ";

		GetComponent<NPC> ().dialoguePrefab.SetActive (true);

		helper = false;
	}

	public IEnumerator Dial3_1()
	{
		helper = true;
		SoundEffects.sfx.onAnything (_dialogue3_1);

		string s1 = "I can still see them there! Come back after the job is finished.";

		GetComponent<NPC> ().dialoguePrefab.SetActive (false);

		InventoryEnabler.me.Subtitles.text = s1;
		yield return new WaitForSeconds (4.2f);
		InventoryEnabler.me.Subtitles.text = " ";

		GetComponent<NPC> ().dialoguePrefab.SetActive (true);
        InventoryEnabler.me.player.gameObject.GetComponent<PlayerMovement>().enabled = true;
        helper = false;
	}

	public IEnumerator Dial3_2()
	{
		helper = true;
		SoundEffects.sfx.onAnything (_dialogue3_2);

		string s1 = "Good job! Take this as the reward.";

		GetComponent<NPC> ().dialoguePrefab.SetActive (false);

		InventoryEnabler.me.Subtitles.text = s1;
		yield return new WaitForSeconds (2.8f);
		InventoryEnabler.me.Subtitles.text = " ";

		InventoryEnabler.me.inventoryBags.GetComponent<InventoryBase> ().AddItemUpdated (adviceFagsQuestReward);
		QuestBase.questBase.EndQuest (QuestBase.questList [2]);
		GetComponent<NPC> ().dialoguePrefab.SetActive (true);
        InventoryEnabler.me.player.gameObject.GetComponent<PlayerMovement>().enabled = true;
        GetComponent<NPC>().dialoguePrefab.transform.GetChild(0).GetComponent<Button>().interactable = false;
        loader = 2;

        helper = false;
	}
}
