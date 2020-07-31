using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCHandler : MonoBehaviour {

	public GameObject _pressSpace;
	public GameObject _dialogueWindow;
	public GameObject _vendorScreen;

	public GameObject _vendorTooltip;
	public Text _vendorTooltipName;
	public Text _vendorTooltipDescription;
	public Text _vendorTooltipCost;

	public static GameObject pressSpace;
	public static GameObject dialogueWindow;
	public static GameObject vendorScreen;

	public static GameObject vendorTooltip;
	public static Text vendorTooltipName;
	public static Text vendorTooltipDescription;
	public static Text vendorTooltipCost;

	/*
	public static GameObject option1;
	public static GameObject option2;
	public static GameObject option3;
	public static GameObject option4;
	public static GameObject option5;
*/


	// Use this for initialization
	void Start () {
		pressSpace = _pressSpace;
		dialogueWindow = _dialogueWindow;
		vendorScreen = _vendorScreen;

		vendorTooltip = _vendorTooltip;
		vendorTooltipName = _vendorTooltipName;
		vendorTooltipDescription = _vendorTooltipDescription;
		vendorTooltipCost = _vendorTooltipCost;
			
		/*
		option1 = dialogueWindow.transform.GetChild (0).transform.GetChild (0).gameObject;
		option2 = dialogueWindow.transform.GetChild (0).transform.GetChild (1).gameObject;
		option3 = dialogueWindow.transform.GetChild (0).transform.GetChild (2).gameObject;
		option4 = dialogueWindow.transform.GetChild (0).transform.GetChild (3).gameObject;
		option5 = dialogueWindow.transform.GetChild (0).transform.GetChild (4).gameObject;
		*/

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
