using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class subtitlesBackground : MonoBehaviour {

    public Text txt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if((txt.text == " ") || (txt.text == ""))
        {
            GetComponent<Image>().enabled = false;
        }
        else
        {
            GetComponent<Image>().enabled = true;
        }
	}
}
