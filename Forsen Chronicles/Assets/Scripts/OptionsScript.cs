using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour {

    public AudioMixer masterMixer;
	//public AudioSource musicSource;
	public Slider musicSlider;
	//public AudioSource effectsSource;
	public Slider effectsSlider;
	public Toggle fullScreen;
	public Dropdown resolution;

    public static OptionsScript me;

    public static int music = -20;
    public static int effects = -10;


	// Use this for initialization
	void Awake () {
        me = this;
        LoadVolumes();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        musicSlider.value = music;
        effectsSlider.value = effects;
    }

    public void LoadVolumes()
    {
        musicVolumeController((float)music);
        effectsVolumeController((float)effects);
        musicSlider.value = music;
        effectsSlider.value = effects;
    }

	public void musicVolumeController(float musicVol)
	{
        masterMixer.SetFloat("musicVol", musicVol);
        music = (int)musicVol;
	}

	public void effectsVolumeController(float sfxVol)
	{
        masterMixer.SetFloat("sfxVol", sfxVol);
        effects = (int)sfxVol;
    }

	public void OnResChanged()
	{
		bool fullscr = fullScreen.isOn;
		int res = resolution.value;

		switch (res) 
		{
		case 0:
			Screen.SetResolution (1920, 1080, fullscr);
			break;
		case 1:
			Screen.SetResolution (1280, 720, fullscr);
			break;
		}
	}
}
