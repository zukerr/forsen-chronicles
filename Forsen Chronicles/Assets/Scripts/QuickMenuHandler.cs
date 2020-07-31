using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuickMenuHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ExitToMainMenu()
	{
		Time.timeScale = 1.0f;
		InventoryEnabler.me.loadingScr.SetActive (true);
		InfoStorage.Save ();
		SceneManager.LoadScene ("MainMenu");
	}

	public void SaveGame()
	{
		Time.timeScale = 1.0f;
		InfoStorage.Save ();
		gameObject.SetActive (false);
	}

	public void LoadGame()
	{
		//InfoStorage.loadQuests = false;
		Time.timeScale = 1.0f;
		InfoStorage.Load ();
	}



	public void QuitGame()
	{
		Time.timeScale = 1.0f;
		InfoStorage.Save ();
		Application.Quit ();
	}
}
