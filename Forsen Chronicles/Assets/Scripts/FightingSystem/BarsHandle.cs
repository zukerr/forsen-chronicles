using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarsHandle : MonoBehaviour {

	public static Image leftHealth;
	public static Image leftMana;
	public static Image rightHealth;
	public static Image rightMana;
	public static Image leftYellow;
	public static Image rightYellow;
	public static GameObject leftBars;
	public static GameObject rightBars;
	public static bool displayRightBars = false;
	public static Text leftHealthText;
	public static Text leftManaText;
	public static Text rightHealthText;
	public static Text rightManaText;

	public Image _leftHealth;
	public Image _leftMana;
	public Image _rightHealth;
	public Image _rightMana;
	public Image _leftYellow;
	public Image _rightYellow;
	public GameObject _leftBars;
	public GameObject _rightBars;
	public BasicUnitFunctions player;
	public Text _leftHealthText;
	public Text _leftManaText;
	public Text _rightHealthText;
	public Text _rightManaText;


	// Use this for initialization
	void Start () {

		leftHealth = _leftHealth;
		leftMana = _leftMana;
		rightHealth = _rightHealth;
		rightMana = _rightMana;
		leftBars = _leftBars;
		rightBars = _rightBars;
		leftHealthText = _leftHealthText;
		leftManaText = _leftManaText;
		rightHealthText = _rightHealthText;
		rightManaText = _rightManaText;
		leftYellow = _leftYellow;
		rightYellow = _rightYellow;
	}
	
	// Update is called once per frame
	void Update () {


		BarsHandle.AdjustLeftBars (player);
		StartCoroutine (AnimateLeftYellowBar (player));

		if ((rightBars.activeSelf == true)&&(displayRightBars == true))
		{
			if ((AbilityBasic.Target!=null)&&(AbilityBasic.Target.friendly == false)) 
			{
				AdjustRightBars (AbilityBasic.Target);
				//Debug.Log ("animating YELLOW BAR for: " + AbilityBasic.Target.gameObject.name);
				StartCoroutine (AnimateRightYellowBar (AbilityBasic.Target));
			}
		}
	}

	public static void AdjustLeftBars(BasicUnitFunctions unit)
	{
		leftHealth.fillAmount = unit.health / unit.max_health;
		leftMana.fillAmount = unit.mana / unit.max_mana;
		leftHealthText.text = unit.health.ToString();
		leftManaText.text = unit.mana.ToString();
	}

	public static void AdjustRightBars(BasicUnitFunctions unit)
	{
		rightHealth.fillAmount = unit.health / unit.max_health;
		rightMana.fillAmount = unit.mana / unit.max_mana;
		rightHealthText.text = unit.health.ToString();
		rightManaText.text = unit.mana.ToString();
	}

	public static IEnumerator AnimateLeftYellowBar(BasicUnitFunctions unit_)
	{
		//Debug.Log ("animating yellow bar");
		while (leftYellow.fillAmount > unit_.health / unit_.max_health) 
		{
			leftYellow.fillAmount = leftYellow.fillAmount - 0.01f  * Time.deltaTime;
			yield return null;
		}

		leftYellow.fillAmount = unit_.health / unit_.max_health;
	}

	public static IEnumerator AnimateRightYellowBar(BasicUnitFunctions unit_)
	{
		//Debug.Log ("animating yellow bar");
		while (rightYellow.fillAmount > unit_.health / unit_.max_health) 
		{
			rightYellow.fillAmount = rightYellow.fillAmount - 0.01f  * Time.deltaTime;
			yield return null;
		}

		rightYellow.fillAmount = unit_.health / unit_.max_health;
	}

	public static void AdjustBars(BasicUnitFunctions _unit)
	{
		switch (_unit.friendly) 
		{
		case true:
			BarsHandle.AdjustLeftBars (_unit);
			leftYellow.fillAmount = _unit.health / _unit.max_health;
			break;

		case false:
			BarsHandle.rightBars.SetActive (true);
			BarsHandle.AdjustRightBars (_unit);
			rightYellow.fillAmount = _unit.health / _unit.max_health;
			break;
		}
	}
}
