using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItemData : MonoBehaviour {


    public static WorldItemData me;
    public int worldItemsCount = 4;
    public static bool[] worldItemsBools;
    public static GameObject[] worldItems;
    public GameObject worldItemsParent;


    // Use this for initialization
    void Awake () {
        me = this;

        worldItems = new GameObject[worldItemsCount];

        for (int i = 0; i < worldItemsCount; i++)
        {
            worldItems[i] = worldItemsParent.transform.GetChild(i).gameObject;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static bool[] CopyBools(bool[] from, int range)
    {
        bool[] outcome = new bool[range];

        for (int i = 0; i < range; i++)
        {
            if (from[i])
            {
                outcome[i] = true;
            }
            else
            {
                outcome[i] = false;
            }
        }
        return outcome;
    }

    public void WorldItemsSetup()
    {
        worldItemsBools = new bool[worldItemsCount];

        for (int i = 0; i < worldItemsCount; i++)
        {
            worldItemsBools[i] = true;
        }
    }

    public void LoadWorldItems()
    {
        for (int i = 0; i < worldItemsCount; i++)
        {
            if (!worldItemsBools[i])
            {
                Destroy(worldItems[i]);
            }
        }
    }
}
