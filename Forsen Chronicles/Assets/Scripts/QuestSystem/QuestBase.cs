using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestBase : MonoBehaviour {

	public BigMapName BigAnnouncingText;
	//public GameObject _ScrollbarContent;
	public static GameObject ScrollbarContent;
	public static GameObject[] QuestLogs;

	public static QuestBase questBase;
	public static Quest[] questList;
	public static int questsTaken = 0;
	public static Quest[] questsTakenTab;
	public static int questLimit = 15;


	// Use this for initialization
	void Awake () {
		//ScrollbarContent = _ScrollbarContent;
		questBase = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static Quest[] SaveQuests(Quest[] source, int elements)
	{
		Quest[] target = new Quest[elements];

		for (int i = 0; i < elements; i++) 
		{
			target [i] = new Quest ();
			target [i].ID = source [i].ID;
			target [i].state = source [i].state;
			target [i].progress = source [i].progress;
			target [i].name = source [i].name;
			target [i].maxProgress = source [i].maxProgress;
			target [i].expReward = source [i].expReward;
            target[i].task = source[i].task;
            target[i].questGiver = source[i].questGiver;
        }

		return target;
	}

	public static void SetupQuestJournal()
	{
		for (int i = 0; i < questLimit; i++) 
		{
			QuestLogs [i] = ScrollbarContent.transform.GetChild (i).gameObject;
			QuestLogs [i].SetActive (false);
		}
	}

	public static void LoadQuestJournal()
	{
		//SetupQuestJournal ();

		for (int i = 0; i < questLimit; i++) 
		{
			if (questsTakenTab [i].ID != 15) 
			{
				QuestLogs[questsTakenTab[i].ID].transform.GetChild (0).GetComponent<Text> ().text = questsTakenTab [i].name + " (" + questsTakenTab [i].progress + "/" + questsTakenTab [i].maxProgress + ")";
				QuestLogs [questsTakenTab[i].ID].GetComponent<QuestLogProps> ().questGiver = questsTakenTab [i].questGiver;
				QuestLogs [questsTakenTab[i].ID].GetComponent<QuestLogProps> ().task = questsTakenTab [i].task;
				QuestLogs [questsTakenTab[i].ID].GetComponent<QuestLogProps> ().progress = questsTakenTab [i].progress + "/" + questsTakenTab [i].maxProgress;
				QuestLogs [questsTakenTab[i].ID].SetActive (true);
			}
		}
	}

	public static void SetupQuests()
	{
		QuestLogs = new GameObject[questLimit];
		questsTakenTab = new Quest[questLimit];
		questList = new Quest[50];

		for (int i = 0; i < 50; i++) 
		{
			questList [i] = new Quest ();
			questList [i].state = State.fresh;
		}

		for (int i = 0; i < questLimit; i++) 
		{
			questsTakenTab [i] = new Quest ();
		}

		SetupQuestJournal ();

		questList [0].name = "Find That Pretty Chick";
		questList [0].questGiver = "Pajlada";
		questList [0].task = "Find the girl Pajlada was talking about.";
		questList [0].maxProgress = 1;
		questList [0].expReward = 250;

		questList [1].name = "Exterminate Weebs";
		questList [1].questGiver = "Pajlada";
		questList [1].task = "Kill 5 weebs.";
		questList [1].maxProgress = 5;
		questList [1].expReward = 50;

		questList [2].name = "Purify Snusholme, part 1";
		questList [2].questGiver = "Tower Guard";
		questList [2].task = "Kill 4 advice fags.";
		questList [2].maxProgress = 4;
		questList [2].expReward = 80;

		questList [3].name = "Purify Snusholme, part 2";
		questList [3].questGiver = "Tower Guard";
		questList [3].task = "Kill 5 wingmans.";
		questList [3].maxProgress = 5;
		questList [3].expReward = 80;

	}

	public void StartQuest(Quest q)
	{
		if (questsTaken < questLimit) {
			q.state = State.ongoing;
			q.progress = 0;
			questsTakenTab [questsTaken] = q;
			questsTakenTab [questsTaken].ID = questsTaken;
			QuestLogs [questsTaken].SetActive (true);
			QuestLogs [questsTaken].transform.GetChild (0).GetComponent<Text> ().text = questsTakenTab [questsTaken].name + " (" + questsTakenTab [questsTaken].progress + "/" + questsTakenTab [questsTaken].maxProgress + ")";
			QuestLogs [questsTaken].GetComponent<QuestLogProps> ().questGiver = questsTakenTab [questsTaken].questGiver;
			QuestLogs [questsTaken].GetComponent<QuestLogProps> ().task = questsTakenTab [questsTaken].task;
			QuestLogs [questsTaken].GetComponent<QuestLogProps> ().progress = questsTakenTab [questsTaken].progress + "/" + questsTakenTab [questsTaken].maxProgress;
			questsTaken++;
			StartCoroutine(BigAnnouncingText.AnnounceQuest("Started Quest: " + q.name));
			LogBox.logs.Log ("Started Quest: " + q.name);
		} 
		else 
		{
			Debug.Log("Quest List is FULL!");
			StartCoroutine(BigAnnouncingText.AnnounceQuest("Quest List is FULL!"));
		}
	}

	public void MakeProgress(Quest q)
	{
		if (q.state == State.ongoing) 
		{
			q.progress++;
            

            if (BigAnnouncingText != null) 
			{
				StartCoroutine (BigAnnouncingText.AnnounceQuest (q.name + ": " + q.progress + "/" + q.maxProgress));
			} 
			else 
			{
				StartCoroutine (QuestCombatAnnouncer.me.AnnounceQuest(q.name + ": " + q.progress + "/" + q.maxProgress));
			}
			CheckComplete (q);
		}
	}

	public void CheckComplete(Quest q)
	{
		if (q.progress == q.maxProgress) 
		{
			q.state = State.completed;
			if (QuestLogs [q.ID] != null) 
			{
                //string s1 = QuestLogs [q.ID].transform.GetChild (0).GetComponent<Text> ().text;
                string s1 = q.name + " (" + q.progress + "/" + q.maxProgress + ")";

                QuestLogs [q.ID].transform.GetChild (0).GetComponent<Text> ().text = s1 + "(Complete)";
                QuestLogs[q.ID].GetComponent<QuestLogProps>().progress = q.progress + "/" + q.maxProgress;
            }
			//QuestLogs [q.ID].SetActive (false);
			//questsTaken--;

			if (BigAnnouncingText != null) 
			{
				StartCoroutine (BigAnnouncingText.AnnounceQuest (q.name + ": " + q.progress + "/" + q.maxProgress + "(Complete)"));
			} 
			else 
			{
				StartCoroutine (QuestCombatAnnouncer.me.AnnounceQuest(q.name + ": " + q.progress + "/" + q.maxProgress + "(Complete)"));
			}
		}
	}
		
	public void EndQuest(Quest q)
	{
		if (q.state == State.completed) 
		{
			QuestLogs [q.ID].SetActive (false);
			questsTakenTab [q.ID] = new Quest ();
			questsTaken--;
			InventoryEnabler.me.player.AddExp (q.expReward);
		}
	}

	public void AbandonQuest(Quest q)
	{
		if (q.state == State.ongoing) 
		{
			QuestLogs [q.ID].SetActive (false);
			questsTaken--;
			q.state = State.fresh;
		}
	}

	public void ProgressAfterKill(string enemy)
	{
		switch (enemy) 
		{
		case "test_enemy":
			MakeProgress (questList [0]);
			Debug.Log (questList [0].progress);
			break;
		case "weeb":
			MakeProgress (questList [1]);
			break;
		case "advice_fag":
			MakeProgress (questList [2]);
			break;
		case "wingman":
			MakeProgress (questList [3]);
			break;
		}
	}
}
