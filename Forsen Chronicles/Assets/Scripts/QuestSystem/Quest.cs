using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public enum State
{
	fresh,
	ongoing,
	completed
};

[Serializable]
public class Quest {

	public int ID = 15;
	public State state;
	public string name;
	public int progress;
	public int maxProgress;
	public float expReward;
	public string task;
	public string questGiver;

}
