using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TyggbarDialogue : MonoBehaviour {

	public static TyggbarDialogue me;

    public Button questDonePaj2;

	private bool helper = false;
	private Coroutine lastRoutine;

	public GameObject fairyButton;

	public AudioClip _dialogue1;
	public AudioClip _dialogue2;
	public AudioClip _dialogue3;
	public AudioClip _dialogue4;

	public static int loader = 0;

	//private bool animHelper = false;

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
			GetComponent<NPC> ().dialoguePrefab.GetComponent<Dialogue> ().ClearDialogueWindow ();
			GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Text> ().text = "1. Agree";
			GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.RemoveAllListeners ();
			GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.AddListener (Dialogue2);
			break;
		case 2:
			GetComponent<NPC> ().dialoguePrefab.GetComponent<Dialogue> ().ClearDialogueWindow ();
			GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Text> ().text = "1. Actually, I was walking around and noticed an angel sitting alone in the mine...";
			GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.RemoveAllListeners ();
			GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.AddListener (Dialogue4);
			break;
        case 3:
            questDonePaj2.interactable = true;
            fairyButton.SetActive(true);
            Destroy(gameObject);
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
		lastRoutine = StartCoroutine (Dial3 ());
	}
	public void Dialogue4()
	{
		lastRoutine = StartCoroutine (Dial4 ());
	}




	public IEnumerator Dial1()
	{
		helper = true;
		SoundEffects.sfx.onAnything (_dialogue1);

		string s1 = "Oh my God, is this a dream? Of course! How could I forget!";
		string s2 = "You are so bright and manly!";
		string s3 = "I'm sorry for asking for it that soon, but can I be your girlfriend?";
		string s4 = "I could even live in the palace with you!";

		GetComponent<NPC> ().dialoguePrefab.SetActive (false);

		InventoryEnabler.me.Subtitles.text = s1;
		yield return new WaitForSeconds (6);
		InventoryEnabler.me.Subtitles.text = s2;
		yield return new WaitForSeconds (2.3f);
		InventoryEnabler.me.Subtitles.text = s3;
		yield return new WaitForSeconds (4.6f);
		InventoryEnabler.me.Subtitles.text = s4;
		yield return new WaitForSeconds (2.4f);
		InventoryEnabler.me.Subtitles.text = " ";

		GetComponent<NPC> ().dialoguePrefab.GetComponent<Dialogue> ().ClearDialogueWindow();
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Text> ().text = "1. Agree";
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.RemoveAllListeners ();
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.AddListener (Dialogue2);
		loader = 1;
		GetComponent<NPC> ().dialoguePrefab.SetActive (true);

		helper = false;
	}


	public IEnumerator Dial2()
	{
		helper = true;
		SoundEffects.sfx.onAnything (_dialogue2);

		string s1 = "That's awesome! To begin the relationship well, we could go have a romantic evening";
		string s2 = "to the Fight Knight Inn in the Gachi Steppes.";
		string s3 = "I'm down to even stay there for the night.";
		string s4 = "I think you are strong enough to carry me for a while.";

		GetComponent<NPC> ().dialoguePrefab.SetActive (false);

		InventoryEnabler.me.Subtitles.text = s1;
		yield return new WaitForSeconds (5.5f);
		InventoryEnabler.me.Subtitles.text = s2;
		yield return new WaitForSeconds (2.9f);
		InventoryEnabler.me.Subtitles.text = s3;
		yield return new WaitForSeconds (2.6f);
		InventoryEnabler.me.Subtitles.text = s4;
		yield return new WaitForSeconds (3.3f);
		InventoryEnabler.me.Subtitles.text = " ";

		QuestBase.questBase.MakeProgress (QuestBase.questList [0]);
        questDonePaj2.interactable = true;
        //GetComponent<NPC> ().dialoguePrefab.SetActive (true);
        loader = 3;
		helper = false;

        InventoryEnabler.me.player.gameObject.GetComponent<PlayerMovement>().enabled = true;
        //start coroutine of Tyggbar entering forsens pants
        StartCoroutine(JoinForsenAnim());
	}

	public IEnumerator Dial3()
	{
		helper = true;
		SoundEffects.sfx.onAnything (_dialogue3);

		string s1 = "Who are you then? And what do you want from me?";

		GetComponent<NPC> ().dialoguePrefab.SetActive (false);

		InventoryEnabler.me.Subtitles.text = s1;
		yield return new WaitForSeconds (3.2f);
		InventoryEnabler.me.Subtitles.text = " ";

		GetComponent<NPC> ().dialoguePrefab.GetComponent<Dialogue> ().ClearDialogueWindow();
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Text> ().text = "1. Actually, I was walking around and noticed an angel sitting alone in the mine...";
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.RemoveAllListeners ();
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.AddListener (Dialogue4);
		loader = 2;
		GetComponent<NPC> ().dialoguePrefab.SetActive (true);

		helper = false;
	}

	public IEnumerator Dial4()
	{
		helper = true;
		SoundEffects.sfx.onAnything (_dialogue4);

		string s1 = "If you are just another admirer with nothing to impress me, you can go already. Take care.";

		GetComponent<NPC> ().dialoguePrefab.SetActive (false);

		InventoryEnabler.me.Subtitles.text = s1;
		yield return new WaitForSeconds (6.5f);
		InventoryEnabler.me.Subtitles.text = " ";

		GetComponent<NPC> ().dialoguePrefab.GetComponent<Dialogue> ().ClearDialogueWindow();
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Text> ().text = "1. Ekhm, I was a prince not so long ago, M'lady.";
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.RemoveAllListeners ();
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (0).GetComponent<Button> ().onClick.AddListener (Dialogue1);
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (1).GetComponent<Text> ().text = "2. That must have been someone else, I am not from here.";
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (1).GetComponent<Button> ().onClick.RemoveAllListeners ();
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (1).GetComponent<Button> ().onClick.AddListener (Dialogue3);
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (2).GetComponent<Text> ().text = "3. Wait a second, I will be right back.";
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (2).GetComponent<Button> ().onClick.RemoveAllListeners ();
		GetComponent<NPC> ().dialoguePrefab.transform.GetChild (2).GetComponent<Button> ().onClick.AddListener (GetComponent<NPC> ().dialoguePrefab.GetComponent<Dialogue>().CloseDialogueWindow);
		GetComponent<NPC> ().dialoguePrefab.SetActive (true);

		helper = false;
	}

	public IEnumerator JoinForsenAnim()
	{
		//animHelper = true;

		Destroy (GetComponent<CapsuleCollider2D> ());

		//part 1
		Vector3 target = new Vector3 (InventoryEnabler.me.player.gameObject.transform.position.x, (InventoryEnabler.me.player.gameObject.transform.position.y + 2.5f));
		Vector3 target_size = new Vector3 (0.25f, 0.25f);
		//Vector3 normalized_target = new Vector3 (InventoryEnabler.me.player.gameObject.transform.position.x, (InventoryEnabler.me.player.gameObject.transform.position.y + 2.85f));
		while (Mathf.Floor((InventoryEnabler.me.player.gameObject.transform.position.y + 2.5f)*10f) != Mathf.Floor(transform.position.y * 10f)) 
		{
			transform.position = Vector3.Lerp (transform.position, new Vector3 (InventoryEnabler.me.player.gameObject.transform.position.x, (InventoryEnabler.me.player.gameObject.transform.position.y + 2.5f)), 1f * Time.deltaTime);
			transform.localScale = Vector3.Lerp (transform.localScale, target_size, 2f * Time.deltaTime);
			//yield return new WaitForSeconds (Time.deltaTime * 1.5f);
			yield return null;
		}

		//part 2
		Destroy (GetComponent<CapsuleCollider2D> ());

		target = InventoryEnabler.me.player.gameObject.transform.position;

		while (Mathf.Floor(transform.position.y * 10) != Mathf.Floor(InventoryEnabler.me.player.gameObject.transform.position.y * 10))
		{
			transform.position = Vector3.Lerp (transform.position, InventoryEnabler.me.player.gameObject.transform.position, 1f * Time.deltaTime);
			transform.localScale = Vector3.Lerp (transform.localScale, target_size, 2f * Time.deltaTime);
			//yield return new WaitForSeconds (Time.deltaTime * 1.5f);
			yield return null;
		}

		SoundEffects.sfx.onLevelUp ();
		InfoStorage.fairy = "Tyggbar";
		fairyButton.SetActive (true);
		//animHelper = false;
		gameObject.SetActive (false);
	}


		
}
