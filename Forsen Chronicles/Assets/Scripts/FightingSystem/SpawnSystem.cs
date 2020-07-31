using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour {

	public static SpawnSystem me;
	public static int AllSpawnersCount;
	public static bool[] logicalSpawns;

	public static int[] deadList;

	public GameObject spawnsParent;
	public static GameObject[] phisicalSpawns;

	//private bool setupHelper = false;

	// Use this for initialization
	void Awake () {
		me = this;
		//setupHelper = true;

		//setupHelper = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnersSetup()
	{
		AllSpawnersCount = spawnsParent.transform.childCount;

		logicalSpawns = new bool[AllSpawnersCount];
		phisicalSpawns = new GameObject[AllSpawnersCount];

		for(int i = 0; i < AllSpawnersCount; i++)
		{
			phisicalSpawns [i] = spawnsParent.transform.GetChild (i).gameObject;
			spawnsParent.transform.GetChild (i).gameObject.GetComponent<SpawnWorldMobs> ().index = i;
			logicalSpawns [i] = true;
		}
        Debug.LogWarning("spawners set up");
	}

	public void SetupGOs()
	{
		phisicalSpawns = new GameObject[AllSpawnersCount];

		for (int i = 0; i < AllSpawnersCount; i++) {
			GameObject.Find ("Spawns").transform.GetChild (i).gameObject.GetComponent<SpawnWorldMobs> ().index = i;
			phisicalSpawns [i] = GameObject.Find ("Spawns").transform.GetChild (i).gameObject;
		}
	}

	public void Load()
	{
        Debug.LogWarning("Loading spawners:");
        for (int i = 0; i < AllSpawnersCount; i++) 
		{
			if (!logicalSpawns [i]) 
			{
                if (phisicalSpawns[i] != null)
                {
                    //Debug.LogError(phisicalSpawns[i].name);
                }
                Destroy (phisicalSpawns [i]);
			}
           // Debug.LogWarning(i);
           // Debug.LogWarning(logicalSpawns[i]);
        }
        Debug.LogWarning("spawners loaded");
    }

	public void CopyBoolTable(bool[] from, bool[] to)
	{
        if(from == null)
        {
            Debug.LogError("FROM IS NULL");
        }

		to = new bool[from.Length];

		for (int i = 0; i < from.Length; i++) 
		{
			to [i] = from [i];
		}

       // Debug.LogWarning("table copied");
        //return outcome;
    }

    public static bool[] CopyBoolTable2(bool[] from)
    {
      //  Debug.LogWarning("COPYING BOOL TABLE:");
        bool[] outcome = new bool[AllSpawnersCount];
        
        for (int i = 0; i < AllSpawnersCount; i++)
        {
            if(from[i])
            {
                outcome[i] = true;
            }
            else
            {
                outcome[i] = false;
            }
            //Debug.LogWarning(outcome[i]);
        }

      //  Debug.LogWarning("BOOL TABLE COPIED");
        return outcome;
    }


	/*
	public void LoadSpawns(bool[] table)
	{
		for (int i = 0; i < spawnsParent.transform.childCount; i++) 
		{
			if (table.Length <= i) 
			{
				Destroy (phisicalSpawns [i]);
			}
			else if (table.Length > i)
			{
				if (!table [i]) 
				{
					Destroy (phisicalSpawns [i]);
				}
			}
		}
	}

	public bool[] SaveSpawns()
	{
		//setup
		bool[] table = new bool[spawnsParent.transform.childCount];

		for (int i = 0; i < spawnsParent.transform.childCount; i++) 
		{
			if (phisicalSpawns [i] == null) {
				table[i] = false;
			}
			else
			{
				table[i] = true;
			}
		}

		return table;

	}
	*/
}
