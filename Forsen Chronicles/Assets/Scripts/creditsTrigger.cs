using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditsTrigger : MonoBehaviour {

    public GameObject credits;
    public AudioSource music;
    public AudioSource tbcSource;

    public GameObject tBC;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InfoStorage.sponsorButton = true;
        music.Stop();
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(ToBeContinued());
    }


    public IEnumerator ToBeContinued()
    {
        SoundEffects.sfx.onAnything(SoundEffects.sfx.toBeContinued);
        yield return new WaitForSeconds(4.1f);
        tBC.SetActive(true);

        while (tbcSource.isPlaying)
        {
            yield return new WaitForSeconds(0.5f);
        }

        tBC.SetActive(false);
        credits.SetActive(true);
        StartCoroutine(ReturnToMenu());
    }

    public IEnumerator ReturnToMenu()
    {
        while (credits.GetComponent<StreamVideo>().isPlaying)
        {
            yield return new WaitForSeconds(1f);
        }

        InventoryEnabler.me.loadingScr.SetActive(true);
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
