using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MainMenu : MonoBehaviour {

	public string gameStartingScene;
	public GameObject animatedBackground;
	public GameObject continueButton;
    public GameObject sponsorButt;
	public GameObject loadingScreen;
	public GameObject Intro;
    public GameObject Credits;

    private bool skiper = false;

	// Use this for initialization
	void Awake () {
		//Debug.Log (Application.persistentDataPath);

		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			continueButton.SetActive (true);
		}

        if(InfoStorage.sponsorButton)
        {
            sponsorButt.SetActive(true);
        }

	}
	
	// Update is called once per frame
	void Update () {
		if (skiper) {
			if ((Input.GetKeyDown (KeyCode.Space)) || (Input.GetKeyDown (KeyCode.Return))) {
                if (Intro.GetComponent<VideoPlayer>().isPlaying)
                {
                    Intro.GetComponent<VideoPlayer>().Stop();
                }
                if (Credits.GetComponent<VideoPlayer>().isPlaying)
                {
                    Credits.GetComponent<VideoPlayer>().Stop();
                }
				loadingScreen.SetActive (true);
				Intro.GetComponent<StreamVideo> ().isPlaying = false;
				Intro.SetActive (false);
                Credits.GetComponent<StreamVideo>().isPlaying = false;
                Credits.SetActive(false);
                loadingScreen.SetActive(false);
                animatedBackground.SetActive(true);
                GetComponent<AudioSource>().Play();
            }
		}		
	}


	public void StartGame()
	{
		animatedBackground.SetActive (false);
		GetComponent<AudioSource> ().Stop ();
		Intro.SetActive (true);
		skiper = true;
		StartCoroutine (StartGameInsight ());
	}

	public IEnumerator StartGameInsight()
	{
		while (Intro.GetComponent<StreamVideo>().isPlaying) 
		{
			yield return new WaitForSeconds (1f);
		}

		skiper = false;
		loadingScreen.SetActive (true);
		SceneManager.LoadSceneAsync (gameStartingScene);
	}

	public void Continue()
	{
		loadingScreen.SetActive (true);
        InfoStorage.thisIsLoaded = true;
		InfoStorage.Load ();
	}

    public void RollCredits()
    {
        InfoStorage.sponsorButton = true;
        sponsorButt.SetActive(true);
        animatedBackground.GetComponent<StreamVideo>().isPlaying = false;
        animatedBackground.SetActive(false);
        GetComponent<AudioSource>().Stop();
        Credits.SetActive(true);
        skiper = true;
    }

    public void OpenStreamtip()
    {
        Application.OpenURL("https://streamtip.com/t/zukeer");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
