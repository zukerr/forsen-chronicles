using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTooltip : MonoBehaviour {

	public static QuestTooltip me;

	public Text qGiver;
	public Text qTask;
	public Text qProgress;
	// Use this for initialization
	void Start () {
		me = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
