using UnityEngine;
using System.Collections;

//This class is all about statistics in fights - one instance is always attached to the player, and also to the enemies in fights
public class BasicUnitFunctions : MonoBehaviour {

	//Level is only characteristic for the player - on mobs it currently has no use. 
	//Level does not decrease till the end of the game - it only goes up with exp gain
	public float level = 0;
	//current exp on current level
	public float exp = 0;
	//maximum exp to complete current level
	public float max_exp = 0;

	//current health of the player - doesn't mean anything in the open world
	public float health;
	//maximum health - its exported to fight scene when it triggers, not important in world environment
	public float max_health;
	//current mana (analogically to health)
	public float mana;
	public float max_mana;

	//how much mana a unit regenerates at the beginning of their turn 
	public float mana_regen = 2;


	//Base statistics are connected to level -> they are base values that start at a certain number at level 1, and then scales ONLY with level - their values increase according to the algorithms.
	//Base stats are not affected by gear in any way.

	//Normal stats are the sum of stats coming from gear(base stats) and from level. Also these stats are the input for abilities.
	public float baseInt = 0;
	public float inteligence = 0;
	public float baseStr = 0;
	public float strength = 0;
	public float baseAgi = 0;
	public float agility = 0;
	public float baseGay = 30;
	public float gay_percentage = 0;
	public float baseVit = 0;
	public float vitality = 0;

	public weaponType myWeaponType;

	public float mainStat
	{
		get {
			if (myWeaponType == weaponType.melee_heavy) {
				return strength;
			} else {
				return agility;
			}
		}
	}

	public float baseAttack_min = 0;
	public float attack_min = 0;
	public float baseAttack_max = 1;
	public float attack_max = 0;
	//public float averageDpt;

	public string identifier;
	public bool IsDead = false;
	public float prev_hp;
	public float hp_change;
	public string hp_change_str;

	public float baseArmor = 2;
	public float armor=0;
	public float baseMres = 2;
	public float magic_resistance=0;

	public enum UnitType{player, test_enemy, weeb, advice_fag, wingman};

	public UnitType unitType;
	public bool friendly = true;

	public Animator animat;
	public FloatingCombatText text1;

	public static bool startingSetupHelper = false;

	//public Sprite targetedSprite;

	public void Start () {


		SetupChar ();

		if (GameObject.Find ("FloatingCombatText") != null) 
		{
			text1 = GameObject.Find ("FloatingCombatText").GetComponent<FloatingCombatText> ();
		}

		if (GetComponent<Animator> () != null) 
		{
			animat = GetComponent<Animator> ();
		}
	}
		

	public void Update () {

		if ((health <= 0)&&(!IsDead)) {
			//start coroutine "death animation", which is located in abilities class for player and in AI class for enemy
			animat.SetTrigger("death");
			IsDead = true;
			QuestBase.questBase.ProgressAfterKill (unitType.ToString ());
			//health = 0;
		}
			
			if (prev_hp != health) {
				if (text1 != null) {

					hp_change = health - prev_hp;
					if (hp_change > 0) {
						hp_change_str = "+" + hp_change;
					} else {
						hp_change_str = hp_change.ToString ();
					}

					text1.to_display.text = gameObject.name + ": " + hp_change_str + "hp";
					Debug.Log ("Displaying floating combat text for player");
					StartCoroutine (text1.Inscription ());

					if (health <= 0) {
						health = 0;
					}

					prev_hp = health;
				}
			}
			


	}

	//this should be called only in the beginning
	public void SetupChar ()
	{
		if (!startingSetupHelper) {

			LvlUp ();
			
			health = max_health;
			mana = max_mana;

			attack_min = baseAttack_min;
			attack_max = baseAttack_max;

			armor = baseArmor;
			magic_resistance = baseMres;

			inteligence = baseInt;
			strength = baseStr;
			agility = baseAgi;
			gay_percentage = baseGay;
			vitality = baseVit;

			max_health = (vitality * 10f) * (1f - (gay_percentage / 100f));
			health = max_health;
			prev_hp = health;
			attack_min = Mathf.Floor ((1 + (mainStat / 100)) * attack_min);
			attack_max = Mathf.Floor ((1 + (mainStat / 100)) * attack_max);

			startingSetupHelper = true;

			Debug.Log ("Character setup complete");
		}
	}

	//Player starts at level 0, and then levelups to 1 with the start of the game
	public void LvlUp()
	{
		level++;

		if (level > 1) {
			SoundEffects.sfx.onLevelUp ();
			StartCoroutine(BigMapName.me.AnnounceQuest("LEVEL UP!"));
		}

		max_exp = level * level * 100f;
		exp = 0;

		baseInt = level * 2f;
		baseStr = level * level * 2f;
		baseAgi = level * level * 2f;
		baseVit = level * level * 2f;

		max_health = (vitality * 10f) * (1f - (gay_percentage / 100f));
		health = max_health;
		attack_min = Mathf.Floor ((1 + (mainStat / 100)) * attack_min);
		attack_max = Mathf.Floor ((1 + (mainStat / 100)) * attack_max);
	}

	public void AddExp(float experience)
	{
		float exp_to_level = max_exp - exp;

		if (exp_to_level > experience) 
		{
			exp += experience;
		} 
		else if (exp_to_level <= experience) 
		{
			experience -= exp_to_level;
			LvlUp ();
			AddExp (experience);
		}
	}


	public IEnumerator regenerate_mana () {


		if (mana <= max_mana - mana_regen) {

			mana += mana_regen;

		}
		yield return null;
	}

	public void DealPhisicalDamage (float dmg) {

		if (armor < 0) {
			armor = 0;
		}

		float real_dmg;

		if (armor >= dmg) {
			real_dmg = 1;
		} else
			real_dmg = dmg - armor;

		//health = health - (dmg * (100/(100+armor)));
		health = health - real_dmg;

	}

	public void DealMagicalDamage (float dmg) {

		if (magic_resistance < 0) {
			magic_resistance = 0;
		}

		float real_dmg;

		if (magic_resistance >= dmg) {
			real_dmg = 1;
		} else
			real_dmg = dmg - magic_resistance;
		
		health = health - real_dmg;

	}



}
