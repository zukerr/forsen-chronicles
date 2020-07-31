using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootedItemSlot : MonoBehaviour {

	public string t1;
	public string t2;
	public string t3;

	public Item item;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetTooltip()
	{
		LootboxHandler.tooltip_on = true;

		LootboxHandler._itname.text = item.itName;
		LootboxHandler._itprops.text = item.itProps;
		LootboxHandler._itcost.text = item.itCost;
	}

	public void ClearTooltip()
	{
		LootboxHandler.tooltip_off = true;

		LootboxHandler._itname.text = " ";
		LootboxHandler._itprops.text = " ";
		LootboxHandler._itcost.text = " ";
	}
}
