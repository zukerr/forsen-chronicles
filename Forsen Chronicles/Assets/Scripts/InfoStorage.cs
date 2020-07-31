using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class InfoStorage : MonoBehaviour {

	//can be used to store loot info
	//can be used to store fairy prefab
	public static GameObject itemsBox;
	public static string fairy;
	public static BasicUnitFunctions playersBUF;
	public static Transform playersTransform;
	public static Vector3 playersPosition;
	public static Vector3 playersScale;

	public static string latestEnemyName;
	public static int numberOfEnemies = 1;
	public static GameObject baseEnemy;
	public static GameObject bonusEnemy1;
	public static GameObject bonusEnemy2;
	public static GameObject bonusEnemy3;
    //public static GameObject _player;
    //public GameObject thisObj;

    public static bool thisIsLoaded = false;
    public static bool sponsorButton = false;
	public static float expBufor;
	public static bool fightFailed = false;
	public static bool fightResult;
	public static string sceneName;
	public static bool gameStarted = false;
	public static bool loadable = false;
	public static bool loadable2 = false;
	public static bool loadQuests = true;

	public static GameObject[] recentlyLootedItems;

	void Awake()
	{
		DontDestroyOnLoad (gameObject);
		gameObject.name = "InfoStorage";
		recentlyLootedItems = new GameObject[50];
		//myself = this;
		//thisObj = gameObject;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

		

	public static void ScreenshotPlayer(GameObject player)
	{
		//GameObject player = GameObject.Find ("Forsen");
		//GameObject temp = Instantiate(player, new Vector3(-100, 0, 0), player.transform.rotation, GameObject.Find("InfoStorage").GetComponent<Transform>());
		//temp.SetActive (false);
		playersBUF = player.GetComponent<BasicUnitFunctions> ();
		playersTransform = player.transform;
		playersPosition = player.transform.position;
		playersScale = player.transform.localScale;
		sceneName = SceneManager.GetActiveScene ().name;
	}

	public static void SetupPlayerAfterFight(GameObject player)
	{
		player.transform.position = playersPosition;
		player.transform.localScale = playersScale;
	}

	public static void SetupPlayerAfterLoading(GameObject player)
	{
		player.transform.position = playersPosition;
		player.transform.localScale = playersScale;
		CopyBUF (playersBUF, player.GetComponent<BasicUnitFunctions> ());
	}

	public static void CopyBUF(BasicUnitFunctions _from, BasicUnitFunctions _to)
	{
		_to.level = _from.level;
		_to.exp = _from.exp;
		_to.max_exp = _from.max_exp;

		_to.health = _from.health;
		_to.max_health = _from.max_health;
		_to.mana = _from.mana;
		_to.max_mana = _from.max_mana;
		_to.mana_regen = _from.mana_regen;

		_to.baseInt = _from.baseInt;
		_to.inteligence = _from.inteligence;
		_to.baseStr = _from.baseStr;
		_to.strength = _from.strength;
		_to.baseAgi = _from.baseAgi;
		_to.agility = _from.agility;
		_to.baseGay = _from.baseGay;
		_to.gay_percentage = _from.gay_percentage;
		_to.baseVit = _from.baseVit;
		_to.vitality = _from.vitality;

		_to.myWeaponType = _from.myWeaponType;

		_to.baseAttack_min = _from.baseAttack_min;
		_to.attack_min = _from.attack_min;
		_to.baseAttack_max = _from.baseAttack_max;
		_to.attack_max = _from.attack_max;

		_to.identifier = _from.identifier;
		_to.IsDead = _from.IsDead;
		_to.prev_hp = _from.prev_hp;
		_to.hp_change = _from.hp_change;
		_to.hp_change_str = _from.hp_change_str;

		_to.baseArmor = _from.baseArmor;
		_to.armor = _from.armor;
		_to.baseMres = _from.baseMres;
		_to.magic_resistance = _from.magic_resistance;

		_to.unitType = _from.unitType;
		_to.friendly = _from.friendly;
	}

	public static void Save()
	{
		WorldSetup._inventory.PrepareToSaveInventory ();

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");
		Debug.Log (Application.persistentDataPath);

		DataToSave data = new DataToSave ();

		ScreenshotPlayer (GameObject.Find ("Forsen"));

		data.level = playersBUF.level;
		data.exp = playersBUF.exp;
		data.max_exp = playersBUF.max_exp;

		data.health = playersBUF.health;
		data.max_health = playersBUF.max_health;
		data.mana = playersBUF.mana;
		data.max_mana = playersBUF.max_mana;
		data.mana_regen = playersBUF.mana_regen;

		data.baseInt = playersBUF.baseInt;
		data.inteligence = playersBUF.inteligence;
		data.baseStr = playersBUF.baseStr;
		data.strength = playersBUF.strength;
		data.baseAgi = playersBUF.baseAgi;
		data.agility = playersBUF.agility;
		data.baseGay = playersBUF.baseGay;
		data.gay_percentage = playersBUF.gay_percentage;
		data.baseVit = playersBUF.baseVit;
		data.vitality = playersBUF.vitality;

		data.baseAttack_min = playersBUF.baseAttack_min;
		data.attack_min = playersBUF.attack_min;
		data.baseAttack_max = playersBUF.baseAttack_max;
		data.attack_max = playersBUF.attack_max;
		//public float averageDpt;

		data.identifier = playersBUF.identifier;
		data.IsDead = playersBUF.IsDead;
		data.prev_hp = playersBUF.prev_hp;
		data.hp_change = playersBUF.hp_change;
		data.hp_change_str = playersBUF.hp_change_str;

		data.baseArmor = playersBUF.baseArmor;
		data.armor = playersBUF.armor;
		data.baseMres = playersBUF.baseMres;
		data.magic_resistance = playersBUF.magic_resistance;

		data.friendly = playersBUF.friendly;

		data.startingSetupHelper = BasicUnitFunctions.startingSetupHelper;

		data.playPosition_x = playersPosition.x;
		data.playPosition_y = playersPosition.y;
		data.playScale_x = playersScale.x;
		data.playScale_y = playersScale.y;
		data.playScale_z = playersScale.z;

		data.scene_Name = sceneName;

		data.fairy = fairy;
		data.gold = InventoryBase.playersGold;
		data.inventory = SaverCommon.InventoryTable();

		data.spawns = SpawnSystem.logicalSpawns;
		//SpawnSystem.me.CopyBoolTable (SpawnSystem.logicalSpawns, data.spawns);
        data.spawns = SpawnSystem.CopyBoolTable2(SpawnSystem.logicalSpawns);

        data.worldItems = WorldItemData.CopyBools(WorldItemData.worldItemsBools, WorldItemData.me.worldItemsCount);

		data.questsTaken = QuestBase.SaveQuests (QuestBase.questsTakenTab, QuestBase.questLimit);
		data.quests = QuestBase.SaveQuests (QuestBase.questList, 50);
		//Debug.Log ("progress zapisanego questa: " + data.quests [0].progress);

		data.pajladaLoader = PajladaDialogue.loader;
		data.towerGuard_1_Loader = TowerGuard1Dialogue.loader;
		data.towerGuard_2_Loader = TowerGuard2Dialogue.loader;
		data.pajlada_dial2_Loader = PajladaDialogue2.loader;
		data.tyggbarLoader = TyggbarDialogue.loader;

		data.wEqPiece = SaverCommon.SaveablePieceOfEq((Equipment)InventoryBase.weaponSlot.CurrentItem);
		data.nEqPiece = SaverCommon.SaveablePieceOfEq((Equipment)InventoryBase.necklaceSlot.CurrentItem);
		data.oEqPiece = SaverCommon.SaveablePieceOfEq((Equipment)InventoryBase.offhandSlot.CurrentItem);
		data.cEqPiece = SaverCommon.SaveablePieceOfEq((Equipment)InventoryBase.chestSlot.CurrentItem);
		data.sEqPiece = SaverCommon.SaveablePieceOfEq((Equipment)InventoryBase.shoulderSlot.CurrentItem);
		data.hEqPiece = SaverCommon.SaveablePieceOfEq((Equipment)InventoryBase.helmetSlot.CurrentItem);
		data.gEqPiece = SaverCommon.SaveablePieceOfEq((Equipment)InventoryBase.gauntletSlot.CurrentItem);

        data.musicVolumeValue = OptionsScript.music;
        data.effectsVolumeValue = OptionsScript.effects;

		bf.Serialize (file, data);
		file.Close ();
	}


	public static void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) 
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			DataToSave data = (DataToSave)bf.Deserialize (file);
			file.Close ();

			sceneName = data.scene_Name;

			loadable = true;
			SceneManager.LoadSceneAsync (sceneName);
			//loadable2 = true;

		}
	}

	public static IEnumerator _LoadTheScene(string s)
	{
		AsyncOperation async = SceneManager.LoadSceneAsync(s);
		while (!async.isDone) {
			yield return null;
		}
			
	}


	void OnEnable()
	{
		SceneManager.sceneLoaded += SetSceneLoadable;
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= SetSceneLoadable;
	}

	void SetSceneLoadable(Scene scene, LoadSceneMode mode)
	{
		if (loadable) {
			Debug.Log ("loaded scene: " + scene.name);
			StartCoroutine (loader ());
			//LoadInsight ();
			loadable = false;
		}
	}



	public static IEnumerator loader()
	{
		InventoryEnabler.me.loadingScr.SetActive (true);
		InventoryEnabler.me.EnableInventory ();
		Debug.LogWarning ("enabled inventory for load");
		yield return new WaitForSeconds (0.001f);
		Debug.LogWarning ("waited for seconds inside loader");
		LoadInsight ();
		Debug.LogWarning ("loaded insight.");
		//Save ();
		InventoryEnabler.me.EnableInventory ();
		Debug.LogWarning ("disabled inventory.");
		InventoryEnabler.me.loadingScr.SetActive (false);
	}



	public void reload()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		LoadInsight ();
	}

	public static void LoadInsight()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) 
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			DataToSave data = (DataToSave)bf.Deserialize (file);
			file.Close ();

			sceneName = data.scene_Name;

			//SceneManager.LoadScene(sceneName);

			playersBUF.level = data.level;
			playersBUF.exp = data.exp;
			playersBUF.max_exp = data.max_exp;

			playersBUF.health = data.health;
			playersBUF.max_health = data.max_health;
			playersBUF.mana = data.mana;
			playersBUF.max_mana = data.max_mana;
			playersBUF.mana_regen = data.mana_regen;

			playersBUF.baseInt = data.baseInt;
			playersBUF.inteligence = data.inteligence;
			playersBUF.baseStr = data.baseStr;
			playersBUF.strength = data.strength;
			playersBUF.baseAgi = data.baseAgi;
			playersBUF.agility = data.agility;
			playersBUF.baseGay = data.baseGay;
			playersBUF.gay_percentage = data.gay_percentage;
			playersBUF.baseVit = data.baseVit;
			playersBUF.vitality = data.vitality;

			playersBUF.baseAttack_min = data.baseAttack_min;
			playersBUF.attack_min = data.attack_min;
			playersBUF.baseAttack_max = data.baseAttack_max;
			playersBUF.attack_max = data.attack_max;
				//public float averageDpt;

			playersBUF.identifier = data.identifier;
			playersBUF.IsDead = data.IsDead;
			playersBUF.prev_hp = data.prev_hp;
			playersBUF.hp_change = data.hp_change;
			playersBUF.hp_change_str = data.hp_change_str;

			playersBUF.baseArmor = data.baseArmor;
			playersBUF.armor = data.armor;
			playersBUF.baseMres = data.baseMres;
			playersBUF.magic_resistance = data.magic_resistance;

			playersBUF.friendly = data.friendly;

			BasicUnitFunctions.startingSetupHelper = data.startingSetupHelper;

			//playersTransform = data.playTransform;
			if (fightFailed != true) {
				Debug.Log ("loading players location from save");
				playersPosition = new Vector3 (data.playPosition_x, data.playPosition_y);
				playersScale = new Vector3 (data.playScale_x, data.playScale_y, data.playScale_z);
			}



			fairy = data.fairy;
			InventoryBase.playersGold = data.gold;
			SaverCommon.LoadAndInstantiateInv (data.inventory);

			Debug.LogWarning ("loaded inventory.");

            //SpawnSystem.logicalSpawns = data.spawns;
            //SpawnSystem.me.CopyBoolTable (data.spawns, SpawnSystem.logicalSpawns);
            SpawnSystem.logicalSpawns = SpawnSystem.CopyBoolTable2(data.spawns);
            
            if (InfoStorage.fightResult == true)
            {
                SpawnSystem.logicalSpawns[WorldSetup.index_temp] = false;
            }

            SpawnSystem.me.Load();

            WorldItemData.worldItemsBools = WorldItemData.CopyBools(data.worldItems, WorldItemData.me.worldItemsCount);
            WorldItemData.me.LoadWorldItems();

            if (loadQuests) {
				QuestBase.SetupQuests ();
				QuestBase.questsTakenTab = QuestBase.SaveQuests (data.questsTaken, QuestBase.questLimit);
				QuestBase.questList = QuestBase.SaveQuests (data.quests, 50);
				QuestBase.LoadQuestJournal ();
			} else {
				QuestBase.SetupQuestJournal ();
				QuestBase.LoadQuestJournal ();
				loadQuests = true;
			}
			Debug.Log ("progress questa: " + QuestBase.questList [0].progress);

			PajladaDialogue.loader = data.pajladaLoader;
			if (PajladaDialogue.me != null) {
				PajladaDialogue.me.Load ();
			}
			TowerGuard1Dialogue.loader = data.towerGuard_1_Loader;
			TowerGuard1Dialogue.me.Load ();
			TowerGuard2Dialogue.loader = data.towerGuard_2_Loader;
			TowerGuard2Dialogue.me.Load ();
			PajladaDialogue2.loader = data.pajlada_dial2_Loader;
			if (PajladaDialogue2.me != null) {
				PajladaDialogue2.me.Load ();
			}
			TyggbarDialogue.loader = data.tyggbarLoader;
			if (TyggbarDialogue.me != null) {
				TyggbarDialogue.me.Load ();
			}

			SaverCommon.LoadAndInstantiateEqPiece (data.wEqPiece, InventoryBase.weaponSlot);
			SaverCommon.LoadAndInstantiateEqPiece (data.nEqPiece, InventoryBase.necklaceSlot);
			SaverCommon.LoadAndInstantiateEqPiece (data.oEqPiece, InventoryBase.offhandSlot);
			SaverCommon.LoadAndInstantiateEqPiece (data.cEqPiece, InventoryBase.chestSlot);
			SaverCommon.LoadAndInstantiateEqPiece (data.sEqPiece, InventoryBase.shoulderSlot);
			SaverCommon.LoadAndInstantiateEqPiece (data.hEqPiece, InventoryBase.helmetSlot);
			SaverCommon.LoadAndInstantiateEqPiece (data.gEqPiece, InventoryBase.gauntletSlot);

            OptionsScript.music = data.musicVolumeValue;
            OptionsScript.effects = data.effectsVolumeValue;
            //OptionsScript.me.LoadVolumes();

            if (fightFailed != true) 
			{
				SetupPlayerAfterLoading (GameObject.Find ("Forsen"));
			}
			GameObject.FindGameObjectWithTag ("MainCamera").transform.position = new Vector3 (playersPosition.x, playersPosition.y, GameObject.FindGameObjectWithTag ("MainCamera").transform.position.z);
			InventoryBase.playersEqChanged = true;
			InfoStorage.fightFailed = false;
            if (!thisIsLoaded)
            {
                thisIsLoaded = true;
            }

            //SceneManager.sceneLoaded -= LoadInsight;
            //loadable = false;
        }
	}

}

[Serializable]
class DataToSave
{
	public float gold;
	public string fairy;

	public float level;
	public float exp;
	public float max_exp;

	public float health;
	public float max_health;
	public float mana;
	public float max_mana;
	public float mana_regen;

	public float baseInt;
	public float inteligence;
	public float baseStr;
	public float strength;
	public float baseAgi;
	public float agility;
	public float baseGay;
	public float gay_percentage;
	public float baseVit;
	public float vitality;

	public float baseAttack_min;
	public float attack_min;
	public float baseAttack_max;
	public float attack_max;
	//public float averageDpt;

	public string identifier;
	public bool IsDead;
	public float prev_hp;
	public float hp_change;
	public string hp_change_str;

	public float baseArmor;
	public float armor;
	public float baseMres;
	public float magic_resistance;

	public bool friendly;

	public bool startingSetupHelper;

	//public Transform playTransform;
	//public Vector3 playPosition;
	public float playPosition_x;
	public float playPosition_y;
	public float playScale_x;
	public float playScale_y;
	public float playScale_z;

	public string scene_Name;

	public SerialInventory[] inventory;

	public SerialInventory wEqPiece;
	public SerialInventory nEqPiece;
	public SerialInventory oEqPiece;
	public SerialInventory cEqPiece;
	public SerialInventory sEqPiece;
	public SerialInventory hEqPiece;
	public SerialInventory gEqPiece;

	public Quest[] quests;
	public Quest[] questsTaken;

	public int pajladaLoader;
	public int pajlada_dial2_Loader;
	public int towerGuard_1_Loader;
	public int towerGuard_2_Loader;
	public int tyggbarLoader;

	public bool[] spawns;

    public bool[] worldItems;

    public int musicVolumeValue;
    public int effectsVolumeValue;
}
