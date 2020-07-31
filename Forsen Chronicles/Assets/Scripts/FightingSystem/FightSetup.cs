using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FightSetup : MonoBehaviour {


	public BasicUnitFunctions player;
	public GameObject fairyTyggbar;
	public GameObject fairyNani;
	public GameObject defaultAbilities;
	public GameObject tyggbarsAbilities;
	public GameObject nanisAbilities;

	public GameObject map;

	public Transform position_1;
	public Transform position_2_1;
	public Transform position_2_2;
	public Transform position_3_1;
	public Transform position_3_2;
	public Transform position_3_3;
	public Transform position_4_1;
	public Transform position_4_2;
	public Transform position_4_3;
	public Transform position_4_4;

	// Use this for initialization
	void Awake () {

		InfoStorage.CopyBUF (InfoStorage.playersBUF, player);
		//player = GameObject.Find ("InfoStorage").GetComponentInChildren<BasicUnitFunctions>();
		//player = InfoStorage.playersBUF;

		//instantiate appropriate fairy
		SetupFairies();

		//instantiate appropriate number of enemies
		SetupEnemies();
	}
		
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BackToWorld()
	{
		UI.loadingScreen.SetActive (true);
		//SceneManager.LoadSceneAsync (InfoStorage.sceneName);
		InfoStorage.loadQuests = false;
		InfoStorage.Load();
	}

	public void LoadWorldAfterDying()
	{
		InfoStorage.fightResult = false;
		InfoStorage.fightFailed = true;
		BackToWorld ();
	}

	public void SetupFairies()
	{
		Debug.Log ("setting up fairies");
		switch (InfoStorage.fairy) {
		case "Nani":
			defaultAbilities.SetActive(false);
			nanisAbilities.SetActive(true);
			Instantiate (fairyNani);
			Debug.Log ("instantiated nani");
			break;
		case "Tyggbar":
			Instantiate (fairyTyggbar);
			//Activate gameobject responsible for tyggbars abilities (the parent of 2 objects which is disabled by default
			defaultAbilities.SetActive(false);
			tyggbarsAbilities.SetActive(true);
			Debug.Log ("instantiated tyggbar");
			break;
		}
	}

	public void SetupEnemies()
	{
		if (InfoStorage.numberOfEnemies >= 1) {
			switch (InfoStorage.numberOfEnemies) 
			{
			case 1:
				GameObject e1 = Instantiate (InfoStorage.baseEnemy, position_1.position, InfoStorage.baseEnemy.transform.rotation, map.transform);
				e1.name = InfoStorage.baseEnemy.name;
				break;
			case 2:
				GameObject temp_2_1 = Instantiate (InfoStorage.baseEnemy, position_2_1.position, InfoStorage.baseEnemy.transform.rotation, map.transform);
				temp_2_1.GetComponent<SpriteRenderer> ().sortingOrder = 3;
				temp_2_1.name = InfoStorage.baseEnemy.name;
				GameObject temp_2_0 = Instantiate (InfoStorage.bonusEnemy1, position_2_2.position, InfoStorage.baseEnemy.transform.rotation, map.transform);
				temp_2_0.name = InfoStorage.bonusEnemy1.name;
				break;
			case 3:
				GameObject temp_3_1 = Instantiate (InfoStorage.baseEnemy, position_3_1.position, InfoStorage.baseEnemy.transform.rotation, map.transform);
				temp_3_1.GetComponent<SpriteRenderer> ().sortingOrder = 4;
				temp_3_1.name = InfoStorage.baseEnemy.name;
				GameObject temp_3_2 = Instantiate (InfoStorage.bonusEnemy1, position_3_2.position, InfoStorage.baseEnemy.transform.rotation, map.transform);
				temp_3_2.GetComponent<SpriteRenderer> ().sortingOrder = 3;
				temp_3_2.name = InfoStorage.bonusEnemy1.name;
				GameObject temp_3_0 = Instantiate (InfoStorage.bonusEnemy2, position_3_3.position, InfoStorage.baseEnemy.transform.rotation, map.transform);
				temp_3_0.name = InfoStorage.bonusEnemy2.name;
				break;
			case 4:
				GameObject temp_4_1 = Instantiate (InfoStorage.baseEnemy, position_4_1.position, InfoStorage.baseEnemy.transform.rotation, map.transform);
				temp_4_1.GetComponent<SpriteRenderer> ().sortingOrder = 5;
				temp_4_1.name = InfoStorage.baseEnemy.name;
				GameObject temp_4_2 = Instantiate (InfoStorage.bonusEnemy1, position_4_2.position, InfoStorage.baseEnemy.transform.rotation, map.transform);
				temp_4_2.GetComponent<SpriteRenderer> ().sortingOrder = 4;
				temp_4_2.name = InfoStorage.bonusEnemy1.name;
				GameObject temp_4_3 = Instantiate (InfoStorage.bonusEnemy2, position_4_3.position, InfoStorage.baseEnemy.transform.rotation, map.transform);
				temp_4_3.GetComponent<SpriteRenderer> ().sortingOrder = 3;
				temp_4_3.name = InfoStorage.bonusEnemy2.name;
				GameObject temp_4_0 = Instantiate (InfoStorage.bonusEnemy3, position_4_4.position, InfoStorage.baseEnemy.transform.rotation, map.transform);
				temp_4_0.name = InfoStorage.bonusEnemy3.name;
				break;

			}
		}
	}
}
