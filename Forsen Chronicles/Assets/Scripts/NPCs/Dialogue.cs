using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

	public VendorNPC dontAssignThis;
	public bool doesItGiveQuests;
	public int questNumber;
	public int quest2Number = -1;
	public int questButtonChildNumber;
	public int quest2ButtonChildNumber;
	public int option1ChildNumber = -1;
	public int option2ChildNumber = -1;
	public int option3ChildNumber = -1;
	public int option4ChildNumber = -1;
	public int option5ChildNumber = -1;
	public bool doesItHaveWelcomeText;
	public bool displayWelcomeTextOnce;
	public string welcomeText;
	public float welcomeTextTime;
	public AudioClip welcomeTextAudio;


	// Use this for initialization
	void Awake () {
		if (doesItGiveQuests) {
			if (QuestBase.questList [questNumber].state != State.fresh) {
				gameObject.transform.GetChild (questButtonChildNumber).GetComponent<Button> ().interactable = false;
			}
		}
	}

	void OnEnable()
	{
		if (doesItGiveQuests) {
			if ((QuestBase.questList [questNumber].state == State.fresh)&&(gameObject.transform.GetChild (questButtonChildNumber).GetComponent<Button> ().interactable != true)) 
			{
				gameObject.transform.GetChild (questButtonChildNumber).GetComponent<Button> ().interactable = true;
			}
			if (quest2Number != -1) {
				if ((QuestBase.questList [quest2Number].state == State.fresh) && (gameObject.transform.GetChild (quest2ButtonChildNumber).GetComponent<Button> ().interactable != true)) {
					gameObject.transform.GetChild (quest2ButtonChildNumber).GetComponent<Button> ().interactable = true;
				}
			}
		}
		if ((doesItHaveWelcomeText) && (!displayWelcomeTextOnce)) {
			DisplayWelcomeText ();
		} else if ((doesItHaveWelcomeText) && (displayWelcomeTextOnce)) {
			DisplayWelcomeText ();
			doesItHaveWelcomeText = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

		KeyboardOption (option1ChildNumber, 1);
		KeyboardOption (option2ChildNumber, 2);
		KeyboardOption (option3ChildNumber, 3);
		KeyboardOption (option4ChildNumber, 4);
		KeyboardOption (option5ChildNumber, 5);

	}

	public void KeyboardOption(int childNumber, int optionNumber)
	{
		if (childNumber != -1) 
		{
			
			KeyCode key;

			switch (optionNumber)
			{
			case 1:
				key = KeyCode.Alpha1;
				break;
			case 2:
				key = KeyCode.Alpha2;
				break;
			case 3:
				key = KeyCode.Alpha3;
				break;
			case 4:
				key = KeyCode.Alpha4;
				break;
			case 5:
				key = KeyCode.Alpha5;
				break;
			default:
				key = KeyCode.F1;
				break;
			}

			if (Input.GetKeyDown (key)) 
			{
				if (transform.GetChild (childNumber).GetComponent<Button> ().interactable) 
				{
					transform.GetChild (childNumber).GetComponent<Button> ().onClick.Invoke ();
				}
			}
		}
	}

	public void VendorOption()
	{
		NPCHandler.vendorScreen.SetActive (true);
		VendorProps.me.ClearVendorBags ();
		dontAssignThis.AddItemsToSlots ();
	}

	public void StartQ()
	{
		QuestBase.questBase.StartQuest (QuestBase.questList [questNumber]);
		Debug.Log ("Quest Started!");
		gameObject.transform.GetChild(questButtonChildNumber).GetComponent<Button> ().interactable = false;

	}
	public void StartQ2()
	{
		QuestBase.questBase.StartQuest (QuestBase.questList [quest2Number]);
		Debug.Log ("Quest Started!");
		gameObject.transform.GetChild(quest2ButtonChildNumber).GetComponent<Button> ().interactable = false;

	}

	public void CloseDialogueWindow()
	{
		//Destroy (gameObject);
		gameObject.SetActive(false);
	}

	public void ClearDialogueWindow()
	{
		for (int i = 0; i < 5; i++) {
			transform.GetChild (i).GetComponent<Text> ().text = "";
			transform.GetChild (i).GetComponent<Button> ().onClick = new Button.ButtonClickedEvent ();
			transform.GetChild (i).GetComponent<Button> ().interactable = true;
		}
	}

	public void ClearDialogueOption(int i)
	{
		transform.GetChild (i).GetComponent<Text> ().text = "";
		transform.GetChild (i).GetComponent<Button> ().onClick = new Button.ButtonClickedEvent ();
		transform.GetChild (i).GetComponent<Button> ().interactable = true;
	}

	public void DisplayWelcomeText()
	{
		StartCoroutine (WelcomeTextCoroutine ());
	}

	public IEnumerator WelcomeTextCoroutine()
	{
		SoundEffects.sfx.onAnything (welcomeTextAudio);
		InventoryEnabler.me.Subtitles.text = welcomeText;
		yield return new WaitForSeconds (welcomeTextTime);
		InventoryEnabler.me.Subtitles.text = " ";
	}
		
}
