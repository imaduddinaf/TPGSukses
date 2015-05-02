using UnityEngine;
using System.Collections;

public class IngameMenu : MonoBehaviour {
	private bool pauseEnabled;
	private bool gameOver;
	private bool congrats;
	//menu
	private float menuWidth;
	private float menuHeight;
	//behaviour

	public void Pause(){
		pauseEnabled = true;
		Time.timeScale = 0;
	}

	public void Resume(){
		pauseEnabled = false;
		Time.timeScale = 1;
	}

	public void GameOver(){
		gameOver = true;
		Time.timeScale = 0;
	}

	public void Congrats(){
		congrats = true;
		Time.timeScale = 0;
	}

	public void Quit(){
		MasterData.currentLevel = 0;
		Application.LoadLevel("Main Menu");
	}

	public void NextLevel() {
		MasterData.currentLevel += 1;
		//Debug.Log (MasterData.currentLevel + ".." + MasterData.levelMax);
		if (MasterData.currentLevel > MasterData.levelMax) {
			Application.LoadLevel ("World Map");
		} else {
			Application.LoadLevel ("Level " + MasterData.currentLevel);
		}
	}

	public void Restart(){		
		Resume();
		Application.LoadLevel(Application.loadedLevel);
	}
	// Use this for initialization
	void Start () {
		menuWidth = Screen.width * 0.5f;
		menuHeight = Screen.height * 0.7f;
		pauseEnabled = false;
		gameOver = false;
		congrats = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Pause ();
		if (!pauseEnabled && Input.GetKeyDown (KeyCode.Escape)) {
			//Time.timeScale = 0;
			//Application.Quit();
			Pause();
		}
		if (Input.GetKeyDown (KeyCode.Backspace)) {
			if(pauseEnabled) {
				Resume();
			}
			else if(!pauseEnabled) {
				Pause();
			}
		}
		/*if (Input.GetKeyDown ("space")) {
			Debug.Log("space pressed");
		}*/
	}

	void OnGUI(){
		float screenWidth = Screen.width;
		float screenHeight = Screen.height;
		float distanceBetweenMenus = menuHeight * 0.05f;
		//menu pause
		if (pauseEnabled) {
			GUI.Box (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f), (screenHeight * 0.5f) - (screenHeight * 0.35f), menuWidth, menuHeight), "menu box");
			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f ) + (menuWidth * 0.1f), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.15f), menuWidth * 0.8f, menuHeight * 0.2f), "Resume")) {
				Debug.Log ("Resume");
				Resume();
			}
			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f ) + (menuWidth * 0.1f), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.15f) + (distanceBetweenMenus + (menuHeight * 0.2f)), menuWidth * 0.8f, menuHeight * 0.2f), "Restart")) {
				Debug.Log ("Restart");
				Restart();
			}
			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f ) + (menuWidth * 0.1f), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.15f) + ((distanceBetweenMenus * 2) + (menuHeight * 0.2f * 2)), menuWidth * 0.8f, menuHeight * 0.2f), "Quit")) {
				Debug.Log ("Quit");
				Quit ();
			}
		}
		//menu gameover
		if (gameOver) {
			GUI.Box (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f), (screenHeight * 0.5f) - (screenHeight * 0.35f), menuWidth, menuHeight), "game over");
			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f ) + (menuWidth * 0.1f), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.15f), menuWidth * 0.8f, menuHeight * 0.2f), "Restart")) {
				Debug.Log ("Restart");
				Restart();
			}
			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f ) + (menuWidth * 0.1f), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.15f) + (distanceBetweenMenus + (menuHeight * 0.2f)), menuWidth * 0.8f, menuHeight * 0.2f), "Quit")) {
				Debug.Log ("Quit");
				Quit ();
			}
		}
		//menu win-congrats
		if (congrats) {
			GUI.Box (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f), (screenHeight * 0.5f) - (screenHeight * 0.35f), menuWidth, menuHeight), "congratulations!!");
			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f ) + (menuWidth * 0.1f), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.15f), menuWidth * 0.8f, menuHeight * 0.2f), "Restart")) {
				Debug.Log ("Restart");
				Restart();
			}
			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f ) + (menuWidth * 0.1f), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.15f) + (distanceBetweenMenus + (menuHeight * 0.2f)), menuWidth * 0.8f, menuHeight * 0.2f), "Next Level")) {
				Debug.Log ("Next Level");
				NextLevel();
			}
			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f ) + (menuWidth * 0.1f), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.15f) + ((distanceBetweenMenus * 2) + (menuHeight * 0.2f * 2)), menuWidth * 0.8f, menuHeight * 0.2f), "Quit")) {
				Debug.Log ("Quit");
				Quit ();
			}
		}
	}
}
		