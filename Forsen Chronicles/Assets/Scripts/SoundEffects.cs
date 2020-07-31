using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour {

	public static SoundEffects sfx;

	public AudioClip equipItem;
	public AudioClip youDiedMusic;
	public AudioClip neverLucky;
    public AudioClip toBeContinued;
    public AudioClip gimme_gimme;
    public AudioClip inventory_opening;
    public AudioClip map_opening;

    public AudioClip sprinklerAbilitySound;
	public AudioClip basicAttackAbilitySound;

	public AudioClip nyanpasuAbilitySound;
	public AudioClip datingAdviceAbilitySound;
	public AudioClip datingAdviceAbilitySound2;
	public AudioClip datingAdviceAbilitySound3;
	public AudioClip depressionAdviceAbilitySound;
	public AudioClip streamAdviceAbilitySound;
	public AudioClip smokeBombAbilitySound;
	public AudioClip wingedChargeAbilitySound;
	public AudioClip healingTouchAbilitySound;

	public AudioClip cheering;
	public AudioClip levelUP;

	private AudioSource source;
	public AudioSource musicSource;

	// Use this for initialization
	void Start () {

		sfx = this;
		source = GetComponent<AudioSource> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PauseOrUnpause()
    {
        if (source.isPlaying)
        {
            source.Pause();
        }
        else
        {
            source.UnPause();
        }
    }

	public void OnItemEquipped()
	{
		if (source.isPlaying) {
			source.Stop ();
		}
		source.PlayOneShot (equipItem);
	}

    public void OnInventoryOpen()
    {
        onAnything(inventory_opening);
    }

    public void OnMapOpen()
    {
        if (source.isPlaying == false)
        {
            //source.Stop ();
            source.PlayOneShot(map_opening);
        }
    }

    public void OnItemPickup()
    {
        onAnything(gimme_gimme);
    }

    public void OnDeath()
	{
		if (musicSource.isPlaying) {
			musicSource.Stop ();
		}
		musicSource.PlayOneShot (youDiedMusic);
	}

	public void onLevelUp()
	{
		onAnything (levelUP);
	}

	public void OnSprinkler()
	{
		if (source.isPlaying) {
			source.Stop ();
		}
		source.PlayOneShot (sprinklerAbilitySound);
	}

	public void OnBasicAttack()
	{
		onAnything (basicAttackAbilitySound);
	}

	public void onNyanpasu()
	{
		if (source.isPlaying) {
			source.Stop ();
		}
		source.PlayOneShot (nyanpasuAbilitySound);
	}
	public void onDatingAdvice()
	{
		if (source.isPlaying) {
			source.Stop ();
		}
		source.PlayOneShot (datingAdviceAbilitySound);
	}
	public void onDatingAdvice2()
	{
		onAnything (datingAdviceAbilitySound2);
	}
	public void onDatingAdvice3()
	{
		onAnything (datingAdviceAbilitySound3);
	}
	public void onDepressionAdvice()
	{
		if (source.isPlaying) {
			source.Stop ();
		}
		source.PlayOneShot (depressionAdviceAbilitySound);
	}
	public void onStreamAdvice()
	{
		if (source.isPlaying) {
			source.Stop ();
		}
		source.PlayOneShot (streamAdviceAbilitySound);
	}
	public void onSmokeBomb()
	{
		onAnything (smokeBombAbilitySound);
	}
	public void onWingedCharge()
	{
		onAnything (wingedChargeAbilitySound);
	}
	public void OnWin()
	{
		if (source.isPlaying) {
			source.Stop ();
		}
		if (musicSource.isPlaying) {
			musicSource.Stop ();
		}
		source.PlayOneShot (cheering);
	}


	public void onAnything(AudioClip clip)
	{
		if (source.isPlaying) {
			source.Stop ();
		}
		source.PlayOneShot (clip);
	}
}
