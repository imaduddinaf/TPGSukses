using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player : MonoBehaviour {

	// Use this for initialization
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

		energy = 20;
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
			currentLevel = Application.loadedLevelName;
			Application.LoadLevel(currentLevel);
		}
	}

	public void AddEnergy (int newEnergyValue){
		energy += newEnergyValue;
		if (energy > maxEnergy)
			energy = maxEnergy;
	}
	
	void DecreaseBattery(){
		energy--;
	}

	void GetValue(){
		if (Application.loadedLevelName == "Tutorial") 
			InvokeRepeating("DecreaseBattery", 18f, 1f);
		else 
			InvokeRepeating("DecreaseBattery", 1f, levelHandle.energyDrain);
		playerValue = Random.Range (1, levelHandle.batasPlayer);
		Test.text = "" + playerValue;
	}
}
