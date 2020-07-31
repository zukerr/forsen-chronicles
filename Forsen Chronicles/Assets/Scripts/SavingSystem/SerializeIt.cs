using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class SerializeIt {

	public string itName;
	public string itProps;
	public string itCost;

	public int levelRequirement;

	public int wType;

	public float attack_min;
	public float attack_max;

	public float armor;
	public float magic_resistance;

	public float inteligence;
	public float strength;
	public float agility;
	public float gay_percentage;
	public float vitality;


}

[Serializable]
public class SerialInventory{

	public int ID;
	public bool equipable;
	public SerializeIt equipmentData;
	public int stacksize;

}
