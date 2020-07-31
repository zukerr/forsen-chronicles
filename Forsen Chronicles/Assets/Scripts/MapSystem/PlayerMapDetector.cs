using UnityEngine;
using System.Collections;

public class PlayerMapDetector : MonoBehaviour {


	Transform mapq;
	public Transform player;
	GameObject[] wirtualna_tablica_map;
	//double[] szerokosc;
	//double szerokosc = 19.20f;
	//double[] wysokosc;
	//double wysokosc = 8.00f;
	public string nazwa_mapy;
	public Transform map_cords;


	// Use this for initialization
	void Start () {

		//player = GetComponent<Transform> ();
		wirtualna_tablica_map = GameObject.FindGameObjectsWithTag ("map");
		map_cords = GetComponent<Transform> ();
		/*
		szerokosc = new double[wirtualna_tablica_map.Length];
		wysokosc = new double[wirtualna_tablica_map.Length];


		for (int i = 0; i < wirtualna_tablica_map.Length; i++) 
		{
			szerokosc [i] = wirtualna_tablica_map [i].GetComponent<MapProps> ().sizeInPixels.x;
			wysokosc [i] = wirtualna_tablica_map [i].GetComponent<MapProps> ().sizeInPixels.y;
		}
*/

	}
	
	// Update is called once per frame
	void Update () {

		foreach (GameObject map in wirtualna_tablica_map) {
//			szerokosc = map.GetComponent<MapProps> ().sizeInPixels.x / 100;
//			wysokosc = map.GetComponent<MapProps> ().sizeInPixels.y / 100;
			if (map == null) {
				Debug.LogError ("map is empty");
			}

			if ((((map.transform.position.x /*- szerokosc/2*/) + map.GetComponent<MapProps>().sizeInPixels.x / 100) >= player.position.x)
				&& (player.position.x >= (map.transform.position.x /*- szerokosc/2*/))
				&& (((map.transform.position.y /*+ wysokosc/2*/) - map.GetComponent<MapProps>().sizeInPixels.y / 100) <= player.position.y)
				&& (player.position.y <= (map.transform.position.y /*+ wysokosc/2*/))) {

				if (nazwa_mapy != map.name) {
					nazwa_mapy = map.name;
					Debug.Log (nazwa_mapy);
				}

				map_cords = map.transform;

				if (map_cords.position != map.transform.position) {
					map_cords.position = map.transform.position;
				}
			}
		}



	}

	
	}

