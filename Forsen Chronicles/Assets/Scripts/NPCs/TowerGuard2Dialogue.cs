using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerGuard2Dialogue : MonoBehaviour {

	public static TowerGuard2Dialogue me;

	private bool helper = false;
	private Coroutine lastRoutine;

	public GameObject wingmansQuestReward;

	public AudioClip _dialogue1;
	public AudioClip _dialogue2_1;
	public AudioClip _dialogue2_2;

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
			GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Text> ().text = "1. I'm done with wingmans.";
			GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.RemoveAllListeners ();
			GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.AddListener (Dialogue2);
            GetComponent<NPC>().dialoguePrefab.transform.GetChild(0).GetComponent<Button>().interactable = true;
            break;
        case 2:
            GetComponent<NPC>().dialoguePrefab.GetComponent<Dialogue>().ClearDialogueOption(0);
            GetComponent<NPC>().dialoguePrefab.transform.GetChild(0).GetComponent<Text>().text = "1. I'm done with wingmans.";
            GetComponent<NPC>().dialoguePrefab.transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
            GetComponent<NPC>().dialoguePrefab.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(Dialogue2);
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
		if (QuestBase.questList [3].state == State.ongoing) 
		{
			lastRoutine = StartCoroutine (Dial2_1 ());
		}

		else if (QuestBase.questList [3].state == State.completed) 
		{
			lastRoutine = StartCoroutine (Dial2_2 ());
		}
	}

	public IEnumerator Dial1()
	{
		helper = true;
		SoundEffects.sfx.onAnything (_dialogue1);

		string s1 = "Why are people so interested in the towers lately?";
		string s2 = "It's not your problem.";
		string s3 = "If you want to do something useful, get rid of those wingmans.";

		GetComponent<NPC> ().dialoguePrefab.SetActive (false);

		InventoryEnabler.me.Subtitles.text = s1;
		yield return new WaitForSeconds (3.4f);
		InventoryEnabler.me.Subtitles.text = s2;
		yield return new WaitForSeconds (1.5f);
		InventoryEnabler.me.Subtitles.text = s3;
		yield return new WaitForSeconds (3.7f);
		InventoryEnabler.me.Subtitles.text = " ";

        //GetComponent<NPC> ().dialoguePrefab.GetComponent<Dialogue> ().StartQ ();
        QuestBase.questBase.StartQuest(QuestBase.questList[3]);
        GetComponent<NPC> ().dialoguePrefab.GetComponent<Dialogue> ().ClearDialogueOption (0);
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Text> ().text = "1. I'm done with wingmans.";
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.RemoveAllListeners ();
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.AddListener (Dialogue2);
		loader = 1;
		GetComponent<NPC> ().dialoguePrefab.SetActive (true);

		helper = false;
	}
		

	public IEnumerator Dial2_1()
	{
		helper = true;
		SoundEffects.sfx.onAnything (_dialogue2_1);

		string s1 = "I can still see them there! Come back after the job is finished.";

		GetComponent<NPC> ().dialoguePrefab.SetActive (false);

		InventoryEnabler.me.Subtitles.text = s1;
		yield return new WaitForSeconds (4.1f);
		InventoryEnabler.me.Subtitles.text = " ";

		GetComponent<NPC> ().dialoguePrefab.SetActive (true);
        InventoryEnabler.me.player.gameObject.GetComponent<PlayerMovement>().enabled = true;

        helper = false;
	}

	public IEnumerator Dial2_2()
	{
		helper = true;
		SoundEffects.sfx.onAnything (_dialogue2_2);

		string s1 = "Good job! Take this as the reward.";

		GetComponent<NPC> ().dialoguePrefab.SetActive (false);

		InventoryEnabler.me.Subtitles.text = s1;
		yield return new WaitForSeconds (2.7f);
		InventoryEnabler.me.Subtitles.text = " ";

		InventoryEnabler.me.inventoryBags.GetComponent<InventoryBase> ().AddItemUpdated (wingmansQuestReward);
		QuestBase.questBase.EndQuest (QuestBase.questList [3]);
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().interactable = false;
		GetComponent<NPC> ().dialoguePrefab.SetActive (true);
        InventoryEnabler.me.player.gameObject.GetComponent<PlayerMovement>().enabled = true;
        loader = 2;
        helper = false;
	}
}
