using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player : MonoBehaviour {

	// Use this for initialization
	public float movespeed;
	public Rigidbody2D rb;
	public GUIText scoreText;
	public GUIText Test;
	public text dar;
	public int energy;
	public int playervalue;
	void Start () {
		energy = 10;
		InvokeRepeating("DecreaseBattery", 1f, 1f);
		UpdateBattery ();
		playervalue = Random.Range (1, 10);
		Test.text = "random: " + playervalue;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (movespeed, 0, 0);
		rb.velocity = new Vector2 (movespeed, rb.velocity.y);
		//InvokeRepeating("DecreaseBattery", 1f, 30f);
		//CancelInvoke();
		UpdateBattery ();
		if (energy == 0){
			Application.LoadLevel(0);
		}
	}

	public void AddEnergy (int newEnergyValue){
		energy += newEnergyValue;
		UpdateBattery ();
	}

	void UpdateBattery (){
		scoreText.text = "Energy: " + energy;
	}
	void DecreaseBattery(){
		energy--;
	}
}
