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
		if (Input.GetKeyDown (KeyCode.Escape)) {
			//Time.timeScale = 0;
			//Application.Quit();
			//Pause();
			BackToMainMenuButton();
		}
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
		Application.LoadLevel ("Level 1");
	}
	public void Level2(){
		MasterData.currentLevel = 2;
		Application.LoadLevel ("Level 2");
	}
	public void Level3(){
		MasterData.currentLevel = 3;
		Application.LoadLevel ("Level 3");
	}
	public void level4(){
		MasterData.currentLevel = 4;
		Application.LoadLevel ("Level 4");
	}
}
