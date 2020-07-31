using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootboxHandler : MonoBehaviour {

	public float pagesCount;
	public GameObject pagePrefab;
	public GameObject lootSlotPrefab;
	public Transform lootpagesParent;
	public GameObject[] lootSlots;

	public static Text _itname;
	public Text itname;
	public static Text _itprops;
	public Text itprops;
	public static Text _itcost;
	public Text itcost;

	public GameObject tooltip;
	public static bool tooltip_on;
	public static bool tooltip_off;

	public GameObject _infoStorage;

	public GameObject emptyLoot;

	//public Vector3 lootSlotBasePosition;
	//public int lootSlotsIndex = 0;

	// Use this for initialization
	void Start () {
		_itname = itname;
		_itprops = itprops;
		_itcost = itcost;

		//_infoStorage = GameObject.Find ("InfoStorage");
	}
	
	// Update is called once per frame
	void Update () {
		if (tooltip_on) 
		{
			tooltip.SetActive (true);
			tooltip_on = false;
		}

		if (tooltip_off) 
		{
			tooltip.SetActive (false);
			tooltip_off = false;
		}
	}

	public void EnablePages()
	{
		CountPages ();

		if (DroppedItemsCount () == 0) 
		{
			emptyLoot.SetActive (true);
		}

		GameObject temp;

		int lootSlotsIndex = 0;
		int slotsOnCurrentPage = 5;

		Vector3 lootSlotBasePosition = new Vector3 (-120, -30, 0);
		//Quaternion zero = new Quaternion (0, 0, 0, 0);

		for (int i = 0; i < pagesCount; i++) 
		{
			temp = Instantiate (pagePrefab, lootpagesParent);
			temp.transform.localScale = new Vector3 (1, 1, 1);
			temp.transform.localPosition = Vector3.zero;

			if ((pagesCount == 1) || (i == (pagesCount - 1))) 
			{
				temp.transform.Find ("next").gameObject.SetActive (false);
				slotsOnCurrentPage = (int)(DroppedItemsCount() - ((pagesCount - 1) * 5));
			}

			//that means it is not the last page
			else if (i < (pagesCount - 1)) 
			{
				slotsOnCurrentPage = 5;
			}

			Debug.Log ("Ilosc itemow w infostorage: " + DroppedItemsCount());
			Debug.Log ("Ilosc stron: " + pagesCount);
			Debug.Log ("sloty na stronie: " + slotsOnCurrentPage);
			for(int j = 0; j < slotsOnCurrentPage; j++)
			{
				if (j != 0) 
				{
					lootSlotBasePosition += new Vector3 (0, -60, 0);
				}
			
				GameObject slot = Instantiate (lootSlotPrefab, temp.transform);
				GameObject o1 = Instantiate (InfoStorage.recentlyLootedItems [lootSlotsIndex], _infoStorage.transform);
				slot.transform.localScale = new Vector3 (1, 1, 1);
				slot.transform.localPosition = lootSlotBasePosition;
				slot.GetComponentInChildren<Text> ().text = InfoStorage.recentlyLootedItems [lootSlotsIndex].GetComponent<Item> ().itName;
				slot.GetComponent<Image> ().sprite = InfoStorage.recentlyLootedItems [lootSlotsIndex].GetComponent<Item> ().spriteNeutral;
				slot.GetComponent<LootedItemSlot> ().item = o1.GetComponent<Item> ();
				lootSlotsIndex++;
			}
		}

		/*
		for (int i = 0; i < InfoStorage.recentlyLootedItems.Length; i++)
		{
			lootSlots [i].GetComponentInChildren<Text> ().text = " " + InfoStorage.recentlyLootedItems [i].GetComponent<Item> ().itName;
			lootSlots [i].GetComponent<Image> ().sprite = InfoStorage.recentlyLootedItems [i].GetComponent<Item> ().spriteNeutral;
		}
		*/
	}

	public void CountPages ()
	{
		pagesCount = Mathf.Ceil(DroppedItemsCount() / 5f);
	}

	public static float DroppedItemsCount()
	{
		float result;

		int i = 0;
		while (InfoStorage.recentlyLootedItems [i] != null) 
		{
			i++;
		}
		result = i;

		return result;
	}

	//useless for now
	public void CreateLoot()
	{
		for (int i = 0; i < LootboxHandler.DroppedItemsCount(); i++) 
		{
			GameObject o1 = Instantiate (InfoStorage.recentlyLootedItems [i], _infoStorage.transform);
			InfoStorage.recentlyLootedItems [i].GetComponent<Item> ().itProps = o1.GetComponent<Item> ().itProps;
		}
	}
}
