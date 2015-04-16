using UnityEngine;
using System.Collections;

public class WorldMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BackToMainMenuButton(){
		Application.LoadLevel ("Main Menu");
	}
	//level picker
	public void Tutorial(){
		Application.LoadLevel ("Tutorial");
	}
	public void Level1(){
		Application.LoadLevel ("Level Tes");
	}
}
