using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour {

	public int howManyItems;

	public GameObject item1;
	public GameObject item2;
	public GameObject item3;
	public GameObject item4;
	public GameObject item5;
	public GameObject item6;
	public GameObject item7;
	public GameObject item8;
	public GameObject item9;
	public GameObject item10;

	public float chanceForItem1;
	public float chanceForItem2;
	public float chanceForItem3;
	public float chanceForItem4;
	public float chanceForItem5;
	public float chanceForItem6;
	public float chanceForItem7;
	public float chanceForItem8;
	public float chanceForItem9;
	public float chanceForItem10;

	public static int lootboxItemsIndex;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GenerateLoot()
	{
		float temp;
		GameObject[] items = 
		{
			item1,
			item2,
			item3,
			item4,
			item5,
			item6,
			item7,
			item8,
			item9,
			item10
		};

		float[] chances = 
		{
			chanceForItem1,
			chanceForItem2,
			chanceForItem3,
			chanceForItem4,
			chanceForItem5,
			chanceForItem6,
			chanceForItem7,
			chanceForItem8,
			chanceForItem9,
			chanceForItem10
		};
			
		for (int i = 0; i < howManyItems; i++) 
		{
			temp = Random.Range (0f, 100f);
			if (temp <= chances[i]) 
			{
				InfoStorage.recentlyLootedItems[lootboxItemsIndex] = items[i];
				lootboxItemsIndex++;
			}
		}
	}
}
