using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum SlotType
{
	weapon,
	helmet,
	shoulder,
	offhand,
	chest,
	gauntlet,
	necklace
};

public class Slot : MonoBehaviour, IPointerClickHandler{

	public SlotType type;

	public bool equipmentSlot;

	private Stack<Item> items;

	public Stack<Item> Items
	{
		get { return items; }
		set { items = value; }
	}

	public Text stackTxt;

	public Sprite slotEmpty;
	public Sprite slotHighlight;

	public bool IsEmpty
	{
		get { return items.Count == 0; }
	}

	public bool IsAvailibleForStacking
	{
		get { return CurrentItem.maxSize > items.Count; }
	}

	public Item CurrentItem
	{
		get {
			if (items != null) {
				if (items.Count != 0)
					return items.Peek ();
				else
					return null;
			} else
				return null;
		}	
	}

	void Awake()
	{
		items = new Stack<Item> ();
	}

	// Use this for initialization
	void Start () {
	

		RectTransform slotRect = GetComponent<RectTransform> ();
		RectTransform txtRect = stackTxt.GetComponent<RectTransform> ();

		int txtScaleFactor = (int)(slotRect.sizeDelta.x * 0.60);
		stackTxt.resizeTextMaxSize = txtScaleFactor;
		stackTxt.resizeTextMinSize = txtScaleFactor;


		txtRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, slotRect.sizeDelta.y);
		txtRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, slotRect.sizeDelta.x);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddItem(Item item)
	{
		if ((items.Count != 0) && (item.equipable)&&(equipmentSlot==true)) {
			if (item.type.ToString () == type.ToString ()) {
				items.Push (item);

				if (items.Count > 1) {
					stackTxt.text = items.Count.ToString ();
				}

				ChangeSprite (item.spriteNeutral, item.spriteHighlighted);
			} else {
				Debug.Log ("wrong slot forsenE");
			}
		} else {
			items.Push (item);

			if (items.Count > 1) {
				stackTxt.text = items.Count.ToString ();
			}

			ChangeSprite (item.spriteNeutral, item.spriteHighlighted);
		}
	}

	public void AddItems(Stack<Item> items)
	{
		if ((items.Count != 0) && (items.Peek ().equipable) && (this.equipmentSlot == true)) {
			if ((items.Peek ().type.ToString () == type.ToString ())) {
				this.items = new Stack<Item> (items);

				stackTxt.text = items.Count > 1 ? items.Count.ToString () : string.Empty;

				ChangeSprite (CurrentItem.spriteNeutral, CurrentItem.spriteHighlighted);
				
			}
            else
            {
				Debug.Log ("wrong slot forsenE2");
			}
		}
		else 
		{
				this.items = new Stack<Item> (items);

				stackTxt.text = items.Count > 1 ? items.Count.ToString () : string.Empty;

			if (CurrentItem != null) 
			{
				ChangeSprite (CurrentItem.spriteNeutral, CurrentItem.spriteHighlighted);
			}
		}
	}

	private void ChangeSprite (Sprite neutral, Sprite highlight)
	{
		GetComponent<Image> ().sprite = neutral;

		SpriteState st = new SpriteState ();

		st.highlightedSprite = highlight;
		st.pressedSprite = neutral;

		GetComponent<Button> ().spriteState = st;

		//Debug.Log ("changed");

	}

	private void _UseItem()
	{
		if (InventoryBase.from != null) 
		{
			InventoryBase.from.GetComponent<Image> ().color = Color.white;
			InventoryBase.from = null;
		}

		if ((!IsEmpty) && (InventoryEnabler.me.vendorScreen.activeSelf) && (gameObject.tag != "VendorSlot")) 
		{
			if (CurrentItem.equipable) 
			{
				Equipment eq1 = (Equipment)CurrentItem;
				eq1.DontRandomizeStats = true;
			}
			InventoryBase.playersGold += CurrentItem.itCostValue;
			VendorProps.me.PlaceEmpty (CurrentItem);
			ClearSlot ();
		} 

		else if ((!IsEmpty) && (InventoryEnabler.me.vendorScreen.activeSelf) && (gameObject.tag == "VendorSlot")) 
		{
			
			if (InventoryBase.playersGold >= CurrentItem.itCostValue) 
			{
				InventoryBase.playersGold -= CurrentItem.itCostValue;
				if (CurrentItem.equipable) 
				{
					Item g1 = Instantiate (CurrentItem, InfoStorage.itemsBox.GetComponent<Transform> ());
					Equipment g2 = (Equipment)g1;
					if (!g2.DontRandomizeStats) 
					{
						g2.EquipmentSetup ();
					}
					WorldSetup._inventory.AddItem (g2);
					Equipment eq1 = (Equipment)CurrentItem;
					if (eq1.DontRandomizeStats) 
					{
						ClearSlot ();
					} 

				} 
				else 
				{
					WorldSetup._inventory.AddItem (CurrentItem);
				}
				//ClearSlot ();
			} 
			else 
			{
				Debug.LogError ("not enough gold!");
			}
		}
			
		else if ((!IsEmpty) && (equipmentSlot)) 
		{
			InventoryBase.invBase.AddItem (items.Peek ());
			ClearSlot ();
			InventoryBase.playersEqChanged = true;
		}
		else if ((!IsEmpty)&&(!equipmentSlot))
		{
			if ((items.Peek ().equipable == true)&&(!IsEmpty))
			{
				Equipment e1 = (Equipment)items.Peek ();
				BasicUnitFunctions player = GameObject.Find ("Forsen").GetComponent<BasicUnitFunctions> ();
				if (player.level >= e1.levelRequirement) {
					switch (items.Peek ().type) {
					case ItemType.weapon:
						InventoryBase.invBase.MoveItem (gameObject);
						InventoryBase.invBase.MoveItem (InventoryBase.weaponSlot.gameObject);
						InventoryBase.weaponSlot.gameObject.GetComponent<Image> ().color = Color.white;
						break;
					case ItemType.helmet:
						InventoryBase.invBase.MoveItem (gameObject);
						InventoryBase.invBase.MoveItem (InventoryBase.helmetSlot.gameObject);
						InventoryBase.helmetSlot.gameObject.GetComponent<Image> ().color = Color.white;
						break;
					case ItemType.shoulder:
						InventoryBase.invBase.MoveItem (gameObject);
						InventoryBase.invBase.MoveItem (InventoryBase.shoulderSlot.gameObject);
						InventoryBase.shoulderSlot.gameObject.GetComponent<Image> ().color = Color.white;
						break;
					case ItemType.offhand:
						InventoryBase.invBase.MoveItem (gameObject);
						InventoryBase.invBase.MoveItem (InventoryBase.offhandSlot.gameObject);
						InventoryBase.offhandSlot.gameObject.GetComponent<Image> ().color = Color.white;
						break;
					case ItemType.chest:
						InventoryBase.invBase.MoveItem (gameObject);
						InventoryBase.invBase.MoveItem (InventoryBase.chestSlot.gameObject);
						InventoryBase.chestSlot.gameObject.GetComponent<Image> ().color = Color.white;
						break;
					case ItemType.gauntlet:
						InventoryBase.invBase.MoveItem (gameObject);
						InventoryBase.invBase.MoveItem (InventoryBase.gauntletSlot.gameObject);
						InventoryBase.gauntletSlot.gameObject.GetComponent<Image> ().color = Color.white;
						break;
					case ItemType.necklace:
						InventoryBase.invBase.MoveItem (gameObject);
						InventoryBase.invBase.MoveItem (InventoryBase.necklaceSlot.gameObject);
						InventoryBase.necklaceSlot.gameObject.GetComponent<Image> ().color = Color.white;
						break;
					}
					InventoryBase.to = null;
					InventoryBase.from = null;
					InventoryBase.playersEqChanged = true;
					//Debug.Log ("from and to nulled");
				} 
				else 
				{
					Debug.Log ("Your level is too low forsenE");
				}
			}
			else if (CurrentItem.type != ItemType.trash)
			{
				items.Pop ().UseItem ();

				stackTxt.text = items.Count > 1 ? items.Count.ToString () : string.Empty;

				if (IsEmpty) {
					ChangeSprite (slotEmpty, slotHighlight);
					InventoryBase.EmptySlots++;
				}
			}
		}
	}

	public void ClearSlot ()
	{
		items.Clear ();
		ChangeSprite (slotEmpty, slotHighlight);
		stackTxt.text = string.Empty;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right) {
			_UseItem ();
		}
	}

	public void TurnItemtooltipOn()
	{
		if (CurrentItem != null) {
			if (InventoryBase.invBase.gameObject.activeSelf) 
			{
				InventoryBase.itemName.text = CurrentItem.itName;
				InventoryBase.itemProperties.text = CurrentItem.itProps;
				InventoryBase.itemCost.text = CurrentItem.itCost;
			}
			if (NPCHandler.vendorScreen.activeSelf) 
			{
				NPCHandler.vendorTooltip.SetActive (true);
				/*
				Vector2 upperRight = new Vector2 (1f, 1f);
				Vector2 upperLeft = new Vector2 (0f, 1f);
				Vector2 lowerRight = new Vector2 (1f, 0f);
				Vector2 lowerLeft = new Vector2 (0f, 0f);

				if (GetComponent<RectTransform> ().pivot == upperRight) {
					NPCHandler.vendorTooltip.GetComponent<RectTransform> ().pivot = upperLeft;
				} 
				else if (GetComponent<RectTransform> ().pivot == upperLeft)
				{
					NPCHandler.vendorTooltip.GetComponent<RectTransform> ().pivot = upperRight;
				}
				else if (GetComponent<RectTransform> ().pivot == lowerRight)
				{
					NPCHandler.vendorTooltip.GetComponent<RectTransform> ().pivot = lowerLeft;
				}
				else if (GetComponent<RectTransform> ().pivot == lowerLeft)
				{
					NPCHandler.vendorTooltip.GetComponent<RectTransform> ().pivot = lowerRight;
				}
				*/
				NPCHandler.vendorTooltip.transform.SetAsLastSibling ();
				//NPCHandler.vendorTooltip.transform.position = gameObject.transform.position;
				//NPCHandler.vendorTooltip.GetComponent<VendorTooltip>().enabled = true;
				NPCHandler.vendorTooltipName.text = CurrentItem.itName;
				NPCHandler.vendorTooltipDescription.text = CurrentItem.itProps;
				NPCHandler.vendorTooltipCost.text = CurrentItem.itCost;
			}
		}
	}

	public void TurnItemtooltipOff()
	{
		if (InventoryBase.invBase.gameObject.activeSelf) 
		{
			InventoryBase.itemName.text = " ";
			InventoryBase.itemProperties.text = " ";
			InventoryBase.itemCost.text = " ";
		}

		if (NPCHandler.vendorScreen.activeSelf) 
		{
			//NPCHandler.vendorTooltip.GetComponent<VendorTooltip>().enabled = false;
			NPCHandler.vendorTooltip.SetActive (false);
			NPCHandler.vendorTooltipName.text = " ";
			NPCHandler.vendorTooltipDescription.text = " ";
			NPCHandler.vendorTooltipCost.text = " ";
		}
	}
		
}
