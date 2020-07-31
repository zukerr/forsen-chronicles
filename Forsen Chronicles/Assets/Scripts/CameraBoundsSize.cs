using UnityEngine;
using System.Collections;

public class CameraBoundsSize : MonoBehaviour {


	public Transform box_cords;
	public PlayerMapDetector current_map;
	public Transform temporary_map;
	//float szerokosc = 15.36f/2f;
	//float wysokosc = -8.64f/2f;
	string mapa;
	//float box_x;
	//float box_y;

	private BoxCollider2D box;


	// Use this for initialization
	void Start () {

		box_cords = GetComponent<Transform> ();
		temporary_map = GetComponent<Transform> ();
		box = GetComponent<BoxCollider2D> ();

	}

	// Update is called once per frame
	public void Update () {

		if (current_map == null) {
			Debug.Log ("current_map needs to be assigned to active player!");
		}

		temporary_map = current_map.map_cords;


		box_cords.position = temporary_map.position;
		box.size = new Vector2((temporary_map.GetComponent<MapProps> ().sizeInPixels.x / 100), (temporary_map.GetComponent<MapProps> ().sizeInPixels.y / 100));
		//box_x = temporary_map.transform.position.x + szerokosc;
		//box_y = temporary_map.transform.position.x - wysokosc;
		//box_cords.position += new Vector3(szerokosc, wysokosc);
		box_cords.position += new Vector3 ((temporary_map.GetComponent<MapProps> ().sizeInPixels.x / 100)/2f, -(temporary_map.GetComponent<MapProps> ().sizeInPixels.y / 100)/2f);


	}
}
