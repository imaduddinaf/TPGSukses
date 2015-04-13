using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player : MonoBehaviour {

	// Use this for initialization
	public float movespeed;
	//public GUIText scoreText;
	public TextMesh Test;
	public int energy;
	private int maxenergy;
	public int playervalue;
	void Start () {
		energy = 20;
		maxenergy = energy;
		InvokeRepeating("DecreaseBattery", 1f, 1f);
		UpdateBattery ();
		playervalue = Random.Range (1, 10);
		Test.text = "" + playervalue;
	}

	void Update () {
		UpdateBattery ();
		if (energy == 0){
			Application.LoadLevel(0);
		}
	}

	public void AddEnergy (int newEnergyValue){
		energy += newEnergyValue;
		if (energy > maxenergy)
			energy = maxenergy;
		UpdateBattery ();
	}

	void UpdateBattery (){
		//scoreText.text = "Energy: " + energy;
	}
	void DecreaseBattery(){
		energy--;
	}
}
