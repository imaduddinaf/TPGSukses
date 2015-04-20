using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player : MonoBehaviour {

	// Use this for initialization
	public float movespeed;
	public TextMesh Test;
	public int energy;
	private int maxEnergy;
	public int playerValue;
	public string currentLevel;

	void Start () {
		energy = 15;
		maxEnergy = energy;
		if (Application.loadedLevelName == "Tutorial") 
			InvokeRepeating("DecreaseBattery", 18f, 1f);
		else 
			InvokeRepeating("DecreaseBattery", 1f, 1f);
		//UpdateBattery ();
		playerValue = Random.Range (1, 10);
		Test.text = "" + playerValue;
	}

	void Update () {
		//UpdateBattery ();
		//Debug.Log ("energy : " +energy);
		if (energy == 0){
			currentLevel = Application.loadedLevelName;
			Application.LoadLevel(currentLevel);
		}
	}

	public void AddEnergy (int newEnergyValue){
		energy += newEnergyValue;
		if (energy > maxEnergy)
			energy = maxEnergy;
		//UpdateBattery ();
	}

	void UpdateBattery (){
		//scoreText.text = "Energy: " + energy;
	}
	void DecreaseBattery(){
		energy--;
	}


}
