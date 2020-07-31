using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryHudAdjust : MonoBehaviour {

	private CanvasScaler scaler;
	public InventoryBase inventory;

	// Use this for initialization
	void Awake () {

		//AdjustHudForInventory ();

	}

	public void AdjustHudForInventory()
	{
		scaler = GetComponent<CanvasScaler> ();

		scaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
		if (scaler.uiScaleMode == CanvasScaler.ScaleMode.ConstantPixelSize) {
			Debug.Log ("constant pixel size");
			inventory.CreateLayout ();
		}
		scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
	}
		

}
