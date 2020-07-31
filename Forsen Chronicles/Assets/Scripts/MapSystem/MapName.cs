using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class MapName : MonoBehaviour {


	public Text name_of_map;
	public PlayerMapDetector a1;
	public string raw_to_display;


	// Use this for initialization
	void Start () {

		name_of_map = GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {

		raw_to_display = a1.nazwa_mapy;


		switch (raw_to_display)
		{
		case "game1_stage1_startinghouse_upstairs":
		case "game1_stage1_startinghouse":
			name_of_map.text = "House";
		break;
		case "game1_stage1_startingzone1"			:
		case "game1_stage1_path1"					:
		case "game1_stage1_path2"					:
		case "game1_stage1_path3"					:
		case "game1_stage1_path4"					:
			name_of_map.text = "Path";
		break;
		default:
			name_of_map.text = raw_to_display;
		break;
		}
	}
}
