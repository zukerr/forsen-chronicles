using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryBase : MonoBehaviour {

	public static InventoryBase invBase;

	public static float playersGold = 0;

	public GameObject _vendorScreen;
	public static GameObject vendorScreen;
	public static GameObject inventoryScreen;
	public static Vector3 inventoryMainPosition;

	public GameObject testItem;

	public GameObject itemsBox;
	public GameObject groundItems;

	public static bool newItemsDropped;
	private GameObject theLootStorage;

	public static Slot[] everySlotData;
	public static bool SaveInv = false;
	public static bool LoadInv = false;

	public static Slot weaponSlot;
	public Slot _weaponSlot;
	public static Slot necklaceSlot;
	public Slot _necklaceSlot;
	public static Slot offhandSlot;
	public Slot _offhandSlot;
	public static Slot chestSlot;
	public Slot _chestSlot;
	public static Slot shoulderSlot;
	public Slot _shoulderSlot;
	public static Slot helmetSlot;
	public Slot _helmetSlot;
	public static Slot gauntletSlot;
	public Slot _gauntletSlot;

	public static Text itemName;
	public Text _itemName;
	public static Text itemProperties;
	public Text _itemProperties;
	public static Text itemCost;
	public Text _itemCost;

	public CharacterStats stats;

	public BasicUnitFunctions player;
	public static bool playersEqChanged = false;

	private RectTransform inventoryRect;

	private float invWidth;
	private float invHeight;

	public int slots;
	public int rows;

	public float slotPaddingLeft, slotPaddingTop;

	public float slotSize;

	public GameObject slotPrefab;

	public static Slot from, to;


	private List<GameObject> allSlots;

	private static int emptySlots;

	public static int EmptySlots
	{
		get{ return emptySlots; }
		set{ emptySlots = value; }
			
	}

	void Awake()
	{
		invBase = this;

		vendorScreen = _vendorScreen;
		inventoryMainPosition = transform.localPosition;
		inventoryScreen = gameObject.transform.parent.gameObject;

		//PrepareToSaveInventory ();
		if (GameObject.Find ("LootedBox") != null) 
		{
			theLootStorage = GameObject.Find ("LootedBox");
		}
		//StartCoroutine (AddNewDrop ());
	}

	// Use this for initialization
	void Start () {




		//invBase = this;
		//CreateLayout ();


	}
		
	
	// Update is called once per frame
	void Update () {
		if (playersEqChanged) {
			SumUpEq ();
			stats.SetStats ();
			PrepareToSaveInventory ();
			playersEqChanged = false;
		}
		if (SaveInv) {
			PrepareToSaveInventory ();
			SaveInv = false;
		}
		if (LoadInv) {
			LoadInventory ();
			LoadInv = false;
		}
	
	}

	public void CreateLayout() {

		allSlots = new List<GameObject> ();

		emptySlots = slots;

		invWidth = (slots / rows) * (slotSize + slotPaddingLeft) + slotPaddingLeft;

		invHeight = rows * (slotSize + slotPaddingTop) + slotPaddingTop;

		inventoryRect = GetComponent<RectTransform> ();

		inventoryRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, invWidth);
		inventoryRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, invHeight);


		int columns = slots / rows;

		for (int y = 0; y < rows; y++) 
		{
			for (int x = 0; x < columns; x++) 
			{
				GameObject newSlot = (GameObject) Instantiate (slotPrefab);

				RectTransform slotRect = newSlot.GetComponent<RectTransform> ();

				newSlot.name = "Slot";
		
				//newSlot.GetComponent<Slot>().Items = new Stack<Item> ();

				newSlot.transform.SetParent (this.transform);

				slotRect.localPosition = /*inventoryRect.localPosition +*/ new Vector3 (slotPaddingLeft * (x + 1) + (slotSize * x), -slotPaddingTop * (y + 1) - (slotSize * y));

				slotRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, slotSize);
				slotRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, slotSize);

				allSlots.Add (newSlot);
			}
		}
		Debug.Log ("created inventory layout");
	}


	public void SetupSlotPivots()
	{
		foreach (GameObject slot in allSlots) {
			slot.GetComponent<RectTransform> ().pivot = new Vector2 (1f, 0f);
		}
	}

	public IEnumerator AddNewDrop()
	{
		if (InventoryBase.newItemsDropped == true) {
			//yield return new WaitForEndOfFrame();
			yield return new WaitForSeconds (0.01f);
			PickUpLoot ();
			InventoryBase.newItemsDropped = false;
		}

		if (LootboxHandler.DroppedItemsCount () == 0) 
		{
			Destroy (GameObject.Find ("LootedBox"));
			Debug.Log ("Destroyed empty loot box with new if statement");
		}
	}

	public void PickUpLoot()
	{
		if (LootboxHandler.DroppedItemsCount () <= InventoryBase.EmptySlots) 
		{
			for (int i = 0; i < LootboxHandler.DroppedItemsCount (); i++) {
				LootItem ();
				Debug.Log ("looting an item");
			}

			for (int i = 0; i < LootboxHandler.DroppedItemsCount (); i++) {
				InfoStorage.recentlyLootedItems [i] = null;
			}
			Debug.Log ("ADDED NEW DROP");
		} 
			
	}

	public void DropLootOnTheGround()
	{
		if (LootboxHandler.DroppedItemsCount () > InventoryBase.EmptySlots) 
		{
			Vector3 tempPosition = InfoStorage.playersPosition;
			groundItems.transform.position = tempPosition;
			for (int i = 0; i < LootboxHandler.DroppedItemsCount (); i++) 
			{

				GameObject g1 = theLootStorage.transform.GetChild(0).gameObject;
				g1.transform.SetParent(groundItems.transform);
				g1.transform.position = tempPosition;
				//g1.tag = "Item";

				if (theLootStorage.transform.childCount == 0) 
				{
					Destroy (theLootStorage);
				}
				Debug.Log ("dropping item on the ground");
			}
		}
	}

	public void LootItem()
	{
		if (theLootStorage.transform.childCount > 0) {
			GameObject g1 = theLootStorage.transform.GetChild (0).gameObject;
		
			g1.transform.SetParent (itemsBox.transform);
			if (theLootStorage.transform.childCount == 0) {
				Destroy (theLootStorage);
			}
			AddItem (g1.GetComponent<Item> ());
			LogBox.logs.Log ("You receive loot: " + g1.GetComponent<Item> ().itName + ".");

		} else {
			Debug.LogError("The loot storage didnt have children");
			//Destroy (theLootStorage);
		}
	}


	public bool AddItem(Item item)
	{
		/*
		if (item.GetType ().ToString() == "Equipment") 
		{
			Equipment e1 = (Equipment)item;
			e1.EquipmentSetup ();
		}
		*/

		if (item.maxSize == 1) {
			PlaceEmpty (item);
			return true;
		} 
		else 
		{
			foreach (GameObject slot in allSlots) 
			{
				Slot tmp = slot.GetComponent<Slot> ();

				if (!tmp.IsEmpty) 
				{
					if ((tmp.CurrentItem.itName == item.itName)&&(tmp.IsAvailibleForStacking))
					{
						tmp.AddItem (item);
						Debug.Log ("STACKED THE HAMMER");
						return true;
					}
				}
			}
			if (emptySlots > 0) 
			{
				PlaceEmpty (item);
			}
		}

		return false;
	}

	private bool PlaceEmpty(Item item)
	{
		if (emptySlots > 0) 
		{
			foreach (GameObject slot in allSlots) 
			{
				Slot tmp = slot.GetComponent<Slot> ();

				if (tmp.IsEmpty) 
				{
					tmp.AddItem (item);
					emptySlots--;
					return true;
				}
			}
		}
		else 
		{
			Debug.Log ("Inventory is full!");
		}
		return false;
	}

	public void MoveItem(GameObject clicked)
	{
		if (from == null) {
			if (!clicked.GetComponent<Slot> ().IsEmpty) {
				from = clicked.GetComponent<Slot> ();
				from.GetComponent<Image> ().color = Color.gray;
			}
		} 
		else if (to == null) 
		{
			if (from != null) 
			{
				//Debug.Log ("to set");
				to = clicked.GetComponent<Slot> ();
			}
		}
		if ((to != null) && (from != null)) 
		{
			if (!((from.tag == "VendorSlot") && (to.tag == "VendorSlot"))) {
				
				if ((from.equipmentSlot) && (!from.IsEmpty)) {
					playersEqChanged = true;
				}

				//Debug.Log ("from and to are full of fuck");
				if ((from.IsEmpty == false) && (from.Items.Peek ().equipable == true) && (to.equipmentSlot == true)) 
				{
					if (from.Items.Peek ().type.ToString () == to.type.ToString ())
                    {
						Equipment e1 = (Equipment)from.Items.Peek ();
						BasicUnitFunctions slayer = GameObject.Find ("Forsen").GetComponent<BasicUnitFunctions> ();
						if (slayer.level >= e1.levelRequirement) {
							Stack<Item> tmpTo = new Stack<Item> (to.Items);
							to.AddItems (from.Items);

							if (tmpTo.Count == 0) {
								from.ClearSlot ();
							} else {
								from.AddItems (tmpTo);
							}

							playersEqChanged = true;
							from.GetComponent<Image> ().color = Color.white;
							SoundEffects.sfx.OnItemEquipped ();
							to = null;
							from = null;
						} else {
							Debug.Log ("Your level is too low forsenE");
							to = null;
						}
					}
                    else
                    {
                        Debug.Log("wrong slot forsenE");
                        from.GetComponent<Image>().color = Color.white;
                        to = null;
                        from = null;
                    }
				}
				else if ((from.tag == "VendorSlot") && (to.tag != "VendorSlot")) 
				{
					if (playersGold >= from.CurrentItem.itCostValue) 
					{
						playersGold -= from.CurrentItem.itCostValue;
					
						if (from.CurrentItem.equipable) 
						{
							Item g1 = Instantiate (from.CurrentItem, InfoStorage.itemsBox.GetComponent<Transform> ());
							Equipment g2 = (Equipment)g1;
							if (!g2.DontRandomizeStats) 
							{
								g2.EquipmentSetup ();
							}
							to.AddItem (g2);
							if (g2.DontRandomizeStats) 
							{
								from.ClearSlot ();
							}
						} 
						else 
						{
							Stack<Item> tmpTo = new Stack<Item> (to.Items);
							to.AddItems (from.Items);

							if (tmpTo.Count == 0) 
							{
								from.ClearSlot ();
							} 
							else 
							{
								from.AddItems (tmpTo);
							}
						}

						from.GetComponent<Image> ().color = Color.white;
						to = null;
						from = null;
					} 
					else 
					{
						Debug.LogError ("Not enough gold!");
						from.GetComponent<Image> ().color = Color.white;
						to = null;
						from = null;
					}
				}

				else if ((from.tag != "VendorSlot") && (to.tag == "VendorSlot")) 
				{
					if (to.IsEmpty) 
					{
						if (from.CurrentItem.equipable) 
						{
							Equipment eq1 = (Equipment)from.CurrentItem;
							eq1.DontRandomizeStats = true;
						}
						playersGold += from.CurrentItem.itCostValue;

						Stack<Item> tmpTo = new Stack<Item> (to.Items);
						to.AddItems (from.Items);

						if (tmpTo.Count == 0) {
							from.ClearSlot ();
						} else {
							from.AddItems (tmpTo);
						}

						from.GetComponent<Image> ().color = Color.white;
						to = null;
						from = null;
					} 
					else 
					{
						from.GetComponent<Image> ().color = Color.white;
						to = null;
						from = null;
					}
				}
				
				else if ((to.equipmentSlot == false))
				{
                    if ((from.equipmentSlot) && (!from.IsEmpty) && (!to.IsEmpty) && (!to.CurrentItem.equipable))
                    {
                        from.GetComponent<Image>().color = Color.white;
                        to = null;
                        from = null;
                    }

                    else if ((!from.IsEmpty) && (!to.IsEmpty) && (from.equipmentSlot) && (!to.equipmentSlot) && (to.CurrentItem.equipable) && (from.CurrentItem.equipable))
                    {
                        if (from.CurrentItem.type.ToString() != to.CurrentItem.type.ToString())
                        {
                            from.GetComponent<Image>().color = Color.white;
                            to = null;
                            from = null;
                        }
                        else
                        {
                            Stack<Item> tmpTo = new Stack<Item>(to.Items);
                            to.AddItems(from.Items);

                            if (tmpTo.Count == 0)
                            {
                                from.ClearSlot();
                            }
                            else
                            {
                                from.AddItems(tmpTo);
                            }

                            from.GetComponent<Image>().color = Color.white;
                            to = null;
                            from = null;
                        }
                    }

                    else
                    {
                        Stack<Item> tmpTo = new Stack<Item>(to.Items);
                        to.AddItems(from.Items);

                        if (tmpTo.Count == 0)
                        {
                            from.ClearSlot();
                        }
                        else
                        {
                            from.AddItems(tmpTo);
                        }

                        from.GetComponent<Image>().color = Color.white;
                        to = null;
                        from = null;
                    }
				}
				else if ((from.CurrentItem.equipable == false)&&(to.equipmentSlot == true))
				{
					from.GetComponent<Image> ().color = Color.white;
					to = null;
					from = null;
				}
			}
			else 
			{
				from.GetComponent<Image> ().color = Color.white;
				to = null;
				from = null;
			}
		}
	}
		

	public void test()
	{
		Debug.Log ("progress questa: " + QuestBase.questList [0].progress);
	}

	public void test0()
	{
		for (int i = 0; i < 1; i++) {
			GameObject g1 = Instantiate (testItem, itemsBox.GetComponent<Transform> ());
			AddItem (g1.GetComponent<Item> ());
		}
	}

	public void AddItemUpdated(GameObject item)
	{
		GameObject g1 = Instantiate (item, itemsBox.GetComponent<Transform> ());
		AddItem (g1.GetComponent<Item> ());
	}


	//this function needs to be called only when inventory is disabled by player;
	public void SumUpEq()
	{
		float armor_sum = 0;
		float mr_sum = 0;

		float attack_min_sum = 0;
		float attack_max_sum = 0;

		float intel_sum = 0;
		float strength_sum = 0;
		float agi_sum = 0;
		float gay_sum = 0;
		float vit_sum = 0;

		Equipment e1 = (Equipment)weaponSlot.CurrentItem;

		if (e1 != null) 
		{
			switch (e1.wType) 
			{
			case weaponType.melee_heavy:
				player.myWeaponType = weaponType.melee_heavy;
				break;
			case weaponType.melee_light:
				player.myWeaponType = weaponType.melee_light;
				break;
			case weaponType.ranged:
				player.myWeaponType = weaponType.ranged;
				break;
			default:
				player.myWeaponType = weaponType.melee_heavy;
				break;
			}
		}

			Equipment[] tab = {
				(Equipment)weaponSlot.CurrentItem,
				(Equipment)helmetSlot.CurrentItem,
				(Equipment)shoulderSlot.CurrentItem,
				(Equipment)offhandSlot.CurrentItem,
				(Equipment)chestSlot.CurrentItem,
				(Equipment)gauntletSlot.CurrentItem,
				(Equipment)necklaceSlot.CurrentItem
			};

			foreach (Equipment part in tab) {
				if (part != null) {
					armor_sum += part.armor;
					mr_sum += part.magic_resistance;

					attack_min_sum += part.attack_min;
					attack_max_sum += part.attack_max;

					intel_sum += part.inteligence;
					strength_sum += part.strength;
					agi_sum += part.agility;
					gay_sum += part.gay_percentage;
					vit_sum += part.vitality;
				}
			}

			player.armor = player.baseArmor + armor_sum;
			player.magic_resistance = player.baseMres + mr_sum;

			player.attack_min = player.baseAttack_min + attack_min_sum;
			player.attack_max = player.baseAttack_max + attack_max_sum;

			player.inteligence = player.baseInt + intel_sum;
			player.agility = player.baseAgi + agi_sum;
			player.strength = player.baseStr + strength_sum;
			player.gay_percentage = player.baseGay + gay_sum;
			player.vitality = player.baseVit + vit_sum;

			//formulas calculations
			player.max_health = (player.vitality * 10f) * (1f - (player.gay_percentage / 100f));
			player.health = player.max_health;
			player.prev_hp = player.max_health;
			player.attack_min = Mathf.Floor ((1 + (player.mainStat / 100)) * player.attack_min);
			player.attack_max = Mathf.Floor ((1 + (player.mainStat / 100)) * player.attack_max);
	}



	public void PrepareToSaveInventory()
	{
		everySlotData = new Slot[40];
		int i = 0;
		foreach (GameObject slot in allSlots) 
		{
			everySlotData[i] = slot.GetComponent<Slot> ();
			i++;
		}
	}

	public void LoadInventory()
	{
		int i = 0;
		foreach (GameObject slot in allSlots) 
		{
			Slot s1 = slot.GetComponent<Slot> ();
			s1.AddItems (everySlotData [i].Items);
			i++;
		}

		Debug.Log ("LOADED INVENTORY");
	}
		
}
