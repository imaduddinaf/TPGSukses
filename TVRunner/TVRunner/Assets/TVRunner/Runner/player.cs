using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player : MonoBehaviour {

	// Use this for initialization
	private IngameMenu menu;
	public TextMesh Test;
	public int energy;
	private int maxEnergy;
	public int playerValue;
	private string currentLevel;
	private level levelHandle;

	void Start () {
		GameObject levelObject = GameObject.Find ("Level Handle");
		if (levelObject != null){
			levelHandle = levelObject.GetComponent <level>();
		}
		if (levelHandle == null){
			Debug.Log ("Cannot find 'level' script");
		}
		GameObject menuObj = GameObject.Find ("Menu");
		menu = menuObj.GetComponent <IngameMenu>();
		energy = 12;
		maxEnergy = energy;
		/*if (Application.loadedLevelName == "Tutorial") 
			InvokeRepeating("DecreaseBattery", 18f, 1f);
		else 
			InvokeRepeating("DecreaseBattery", 1f, levelHandle.energyDrain);*/
		Invoke ("GetValue", 0f);
		//playerValue = Random.Range (1, levelHandle.batasPlayer);
		///Test.text = "" + playerValue;
	}

	void Update () {
		if (energy == 0){
			Die ();
			//currentLevel = Application.loadedLevelName;
			//Application.LoadLevel(currentLevel);
		}
	}
	void Die(){
		menu.GameOver();
	}

	public void AddEnergy (int newEnergyValue){
		energy += newEnergyValue;
		if (energy > maxEnergy)
			energy = maxEnergy;
	}
	
	void DecreaseBattery(){
		energy -= levelHandle.energyDrain;
	}

	void GetValue(){
		if (Application.loadedLevelName == "Tutorial") 
			InvokeRepeating("DecreaseBattery", 18f, 1f);
		else 
			InvokeRepeating("DecreaseBattery", 1f, 1f);
		playerValue = Random.Range (1, levelHandle.batasPlayer);
		Test.text = "" + playerValue;
		energy += levelHandle.bonusEnergy;
		maxEnergy = energy;
	}
}
