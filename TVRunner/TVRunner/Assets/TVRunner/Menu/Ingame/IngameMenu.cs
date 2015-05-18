using UnityEngine;
using System.Collections;

public class IngameMenu : MonoBehaviour {
	private bool pauseEnabled;
	private bool gameOver;
	private bool congrats;
	//menu
	private float menuWidth;
	private float menuHeight;
	float screenWidth;
	float screenHeight;
	float distanceBetweenMenus;
	public Texture2D ingameMenuBg;
	public Texture2D resume;
	public Texture2D restart;
	public Texture2D quit;
	public Texture2D nextLevel;
	public Texture2D star;
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
		Debug.Log (MasterData.currentLevel + ".." + MasterData.levelMax);
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
		menuWidth = Screen.width * 0.7f;
		menuHeight = Screen.height * 0.9f;
		pauseEnabled = false;
		gameOver = false;
		congrats = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Pause ();
		/*if (!pauseEnabled && Input.GetKeyDown (KeyCode.Escape)) {
			//Time.timeScale = 0;
			//Application.Quit();
			Pause();
		}*/
		if (Input.GetKeyDown (KeyCode.Backspace) || Input.GetKeyDown (KeyCode.Escape)) {
			if(pauseEnabled && !gameOver && !congrats) {
				Resume();
			}
			else if(!pauseEnabled && !gameOver && !congrats) {
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
		GUI.skin.box.fontSize=50;
		GUI.skin.box.wordWrap=false;
		GUI.skin.button.fontSize=50;
		GUI.skin.button.wordWrap=false;
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		distanceBetweenMenus = menuHeight * 0.05f;

		//menu pause
		if (pauseEnabled) {
			
			GUIStyle restartStyle = new GUIStyle();
			//restartStyle.active.background = restart;
			restartStyle.active.textColor = Color.red;

			GUI.Box (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.35f), (screenHeight * 0.5f) - (screenHeight * 0.45f), menuWidth, menuHeight), "pause");
			//GUI.DrawTexture (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.35f), (screenHeight * 0.5f) - (screenHeight * 0.45f), menuWidth, menuHeight), ingameMenuBg, ScaleMode.ScaleToFit, true);

			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.35f ) + (menuWidth * 0.1f), (screenHeight * 0.5f) - (screenHeight * 0.45f) + (menuHeight * 0.15f), menuWidth * 0.8f, menuHeight * 0.2f), resume)) {
				Debug.Log ("Resume");
				Resume();
			}
			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.35f ) + (menuWidth * 0.1f), (screenHeight * 0.5f) - (screenHeight * 0.45f) + (menuHeight * 0.15f) + (distanceBetweenMenus + (menuHeight * 0.2f)), menuWidth * 0.8f, menuHeight * 0.2f), restart)) {
				Debug.Log ("Restart");
				Restart();
			}
			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.35f ) + (menuWidth * 0.1f), (screenHeight * 0.5f) - (screenHeight * 0.45f) + (menuHeight * 0.15f) + ((distanceBetweenMenus * 2) + (menuHeight * 0.2f * 2)), menuWidth * 0.8f, menuHeight * 0.2f), quit)) {
				Debug.Log ("Quit");
				Quit ();
			}
		}
		//menu gameover
		if (gameOver) {
			GUI.Box (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f), (screenHeight * 0.5f) - (screenHeight * 0.35f), menuWidth, menuHeight), "game over");
			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f ) + (menuWidth * 0.1f), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.15f), menuWidth * 0.8f, menuHeight * 0.2f), restart)) {
				Debug.Log ("Restart");
				Restart();
			}
			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f ) + (menuWidth * 0.1f), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.15f) + (distanceBetweenMenus + (menuHeight * 0.2f)), menuWidth * 0.8f, menuHeight * 0.2f), quit)) {
				Debug.Log ("Quit");
				Quit ();
			}
		}
		//menu win-congrats
		if (congrats) {
			//GUI.Box (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f), (screenHeight * 0.5f) - (screenHeight * 0.35f), menuWidth, menuHeight), "congratulations!!");
			GUI.DrawTexture (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.35f), (screenHeight * 0.5f) - (screenHeight * 0.45f), menuWidth, menuHeight), ingameMenuBg, ScaleMode.ScaleToFit, true);

			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f ), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.25f) + (distanceBetweenMenus + (menuHeight * 0.3f)), menuWidth * 0.15f, menuHeight * 0.15f), restart)) {
				Debug.Log ("Restart");
				Restart();
			}
			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.075f ), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.25f) + (distanceBetweenMenus + (menuHeight * 0.2f)), menuWidth * 0.2f, menuHeight * 0.2f), nextLevel)) {
				Debug.Log ("Next Level");
				NextLevel();
			}
			if (GUI.Button (new Rect ((screenWidth * 0.65f), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.25f) + (distanceBetweenMenus + (menuHeight * 0.3f)), menuWidth * 0.15f, menuHeight * 0.15f), quit)) {
				Debug.Log ("Quit");
				Quit ();
			}
		}
	}
}
		