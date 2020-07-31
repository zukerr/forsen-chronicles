using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBarHandler : MonoBehaviour {

	public BasicUnitFunctions player;
	public Image exp;
	public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		exp.fillAmount = player.exp / player.max_exp;
		text.text = "EXP: " + player.exp + "/" + player.max_exp;
	}
}
