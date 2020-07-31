using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSetup : MonoBehaviour {

	public GameObject player;
	public Camera main_cam;
	public GameObject infoStorage;
	public GameObject dropBox;
	public GameObject itBox;
	public InventoryBase inventory;
	public static InventoryBase _inventory;
	public GameObject _ScrollbarContent;
	public InventoryHudAdjust hudAdjust;
	public SpawnSystem spawnSys;
    public WorldItemData wItemsData;
	public Transform respawnLocation;
    public static int index_temp;

	// Use this for initialization
	void Awake () {

		Debug.Log ("Awaking the WorldSetup");

		Application.runInBackground = true;

		hudAdjust.AdjustHudForInventory ();
		_inventory = inventory;
		QuestBase.ScrollbarContent = _ScrollbarContent;

		InventoryBase.weaponSlot = inventory._weaponSlot;
		InventoryBase.necklaceSlot = inventory._necklaceSlot;
		InventoryBase.offhandSlot = inventory._offhandSlot;
		InventoryBase.chestSlot = inventory._chestSlot;
		InventoryBase.shoulderSlot = inventory._shoulderSlot;
		InventoryBase.helmetSlot = inventory._helmetSlot;
		InventoryBase.gauntletSlot = inventory._gauntletSlot;

		InventoryBase.itemName = inventory._itemName;
		InventoryBase.itemProperties = inventory._itemProperties;
		InventoryBase.itemCost = inventory._itemCost;


		if (!InfoStorage.gameStarted) 
		{
			Instantiate (infoStorage);
			Debug.Log ("created infostorage");
			InfoStorage.playersBUF = player.GetComponent<BasicUnitFunctions> ();
			QuestBase.SetupQuests ();
			SpawnSystem.me = spawnSys;
            WorldItemData.me = wItemsData;
            //this should be called only at first opening of the game, and cannot be run in case where you open the game and click continue
            SpawnSystem.me.SpawnersSetup();
            WorldItemData.me.WorldItemsSetup();
            if (!InfoStorage.thisIsLoaded)
            {
               // SpawnSystem.me.SpawnersSetup();
            }
            else
            {
                /*
                SpawnSystem.me.SetupGOs();
                Debug.Log("SetupGOs COMPLETE");
                */
                
            }
			InfoStorage.gameStarted = true;
		}

        else
        {
            SpawnSystem.me.SetupGOs ();
            Debug.Log("SetupGOs COMPLETE");
        }

		if (GameObject.Find ("LootBox") != null) 
		{
			dropBox = GameObject.Find ("LootBox");
			if (dropBox.transform.childCount == 0) 
			{
				Destroy (dropBox);
			}
		}

		InfoStorage.itemsBox = itBox;

			
		if (InfoStorage.playersPosition != Vector3.zero) 
		{
			

			if (InfoStorage.fightResult == true) 
			{
				Debug.Log ("setting players location after fight");
				//InfoStorage.LoadInsight ();
				//QuestBase.LoadQuestJournal();
				InfoStorage.SetupPlayerAfterFight (player);
				InfoStorage.CopyBUF (InfoStorage.playersBUF, player.GetComponent<BasicUnitFunctions> ());
				Debug.Log (InfoStorage.playersBUF.health);
				main_cam.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10);
                index_temp = GameObject.Find(InfoStorage.latestEnemyName).GetComponent<SpawnWorldMobs>().index;
                //SpawnSystem.logicalSpawns [GameObject.Find (InfoStorage.latestEnemyName).GetComponent<SpawnWorldMobs> ().index] = false;
                Destroy (GameObject.Find (InfoStorage.latestEnemyName));
                //StartCoroutine(SpawnSystem.me.SpawnsAfterFightCoroutine());
                if (LootboxHandler.DroppedItemsCount () > 0f) 
				{
					InventoryBase.newItemsDropped = true;
					inventory.DropLootOnTheGround ();
				}
                //pick up the loot
                //PickUpLoot ();
			} 
			if (InfoStorage.fightFailed) 
			{
				Respawn ();
			}
		}

		inventory.PrepareToSaveInventory ();
		StartCoroutine (inventory.AddNewDrop ());
	}

    private void Start()
    {
        StartCoroutine(SaverCoroutine());
    }

    private IEnumerator SaverCoroutine()
    {
        yield return new WaitForSeconds(0.01f);
        InfoStorage.Save();
    }


    //IEnumerator AddTheDrop()
    //{
    //yield return Wai
    //	}

    private void Respawn()
	{
		Debug.Log ("respawning player");
		player.transform.position = respawnLocation.position;
		player.transform.localScale = respawnLocation.localScale;
		InfoStorage.CopyBUF (InfoStorage.playersBUF, player.GetComponent<BasicUnitFunctions> ());
		main_cam.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10);
	}
		
	
	// Update is called once per frame
	void Update () {
		
	}
}
