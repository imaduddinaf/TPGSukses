using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	private bool quit;
	//menu
	private float menuWidth;
	private float menuHeight;
	// Use this for initialization
	void Start () {
		menuWidth = Screen.width * 0.5f;
		menuHeight = Screen.height * 0.5f;
		quit = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			//Time.timeScale = 0;
			Application.Quit();
			//Pause();
		}
	
	}

	void Quit(){
		Application.Quit ();
	}

	public void OnClickPlay(){
		Application.LoadLevel ("World Map");
		MasterData.WriteToFile ();
	}

	public void OnClickDie(){
		quit = true;
	}

	public void OnClickCredits(){
		Application.LoadLevel ("Credits");		
	}

	public void OnClickOptions(){
		Application.LoadLevel ("Options");	
	}
	void OnGUI(){
		float screenWidth = Screen.width;
		float screenHeight = Screen.height;
		float distanceBetweenMenus = menuHeight * 0.05f;
		//menu pause
		if (quit) {
			GUI.Box (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f), (screenHeight * 0.5f) - (screenHeight * 0.35f), menuWidth, menuHeight), "");
			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f) + (menuWidth * 0.1f), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.15f), menuWidth * 0.8f, menuHeight * 0.2f), "Cancel")) {
				Debug.Log ("Cancel Quit");
				quit = false;
			}
			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f) + (menuWidth * 0.1f), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.15f) + (distanceBetweenMenus + (menuHeight * 0.2f)), menuWidth * 0.8f, menuHeight * 0.2f), "Quit")) {
				Debug.Log ("Quit");
				Quit ();
			}
		}
	}
}
