using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WorldMap : MonoBehaviour {
	
	public Text version;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (MasterData.GameVersion);
	}

	public void BackToMainMenuButton(){
		Application.LoadLevel ("Main Menu");
	}
	//level picker
	public void Tutorial(){
		MasterData.currentLevel = 0;
		Application.LoadLevel ("Tutorial");
	}
	public void Level1(){
		MasterData.currentLevel = 1;
		Application.LoadLevel ("Level Tes");
	}
}
