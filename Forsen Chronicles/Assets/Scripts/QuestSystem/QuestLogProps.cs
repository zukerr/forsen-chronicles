using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLogProps : MonoBehaviour {

	public string questGiver;
	public string task;
	public string progress;

	public void MouseEnter()
	{
		QuestTooltip.me.qGiver.text = questGiver;
		QuestTooltip.me.qTask.text = task;
		QuestTooltip.me.qProgress.text = progress;
	}

	public void MouseExit()
	{
		QuestTooltip.me.qGiver.text = " ";
		QuestTooltip.me.qTask.text = " ";
		QuestTooltip.me.qProgress.text = " ";
	}

}
