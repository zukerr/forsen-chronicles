using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerFight : MonoBehaviour {

	public string sceneToLoad;
	public int numberOfEnemies = 1;
	/*
	public bool randomizeNumerOfEnemies = false;
	public int enemiesNumberMin;
	public int enemiesNumberMax;
	*/
	public GameObject enemy0;
	public GameObject additionalEnemy1;
	public GameObject additionalEnemy2;
	public GameObject additionalEnemy3;

	/*
	public bool zulu_warrior;
	public bool gachi_fag;
	public bool weeb;
	public bool ice_fag;
	public bool soda_cuck;
*/
	// Use this for initialization
	void Start () {
		/*
		if (randomizeNumerOfEnemies) {
			numberOfEnemies = Random.Range (enemiesNumberMin, enemiesNumberMax);
		}
		*/
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		if (numberOfEnemies >= 1) {
			switch (numberOfEnemies) 
			{
			case 1:
				InfoStorage.baseEnemy = enemy0;
				InfoStorage.numberOfEnemies = 1;
				break;
			case 2:
				InfoStorage.baseEnemy = enemy0;
				InfoStorage.bonusEnemy1 = additionalEnemy1;
				InfoStorage.numberOfEnemies = 2;
				break;
			case 3:
				InfoStorage.baseEnemy = enemy0;
				InfoStorage.bonusEnemy1 = additionalEnemy1;
				InfoStorage.bonusEnemy2 = additionalEnemy2;
				InfoStorage.numberOfEnemies = 3;
				break;
			case 4:
				InfoStorage.baseEnemy = enemy0;
				InfoStorage.bonusEnemy1 = additionalEnemy1;
				InfoStorage.bonusEnemy2 = additionalEnemy2;
				InfoStorage.bonusEnemy3 = additionalEnemy3;
				InfoStorage.numberOfEnemies = 4;
				break;
			}
		}
		InfoStorage.Save ();
		InfoStorage.ScreenshotPlayer (other.gameObject);
		InfoStorage.latestEnemyName = transform.parent.name;
		ScreenFader sf = GameObject.Find ("ScreenFader").GetComponent<ScreenFader>();
		yield return StartCoroutine (sf.FadeToBlack ());
		InventoryEnabler.me.loadingScr.SetActive (true);
		SceneManager.LoadSceneAsync (sceneToLoad);
		yield return StartCoroutine (sf.FadeToClear ());
	}

}
