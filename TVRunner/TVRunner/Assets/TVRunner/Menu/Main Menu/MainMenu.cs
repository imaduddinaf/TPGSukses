using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			//Time.timeScale = 0;
			Application.Quit();
			//Pause();
		}
	
	}

	public void OnClickPlay(){
		Application.LoadLevel ("World Map");
		MasterData.WriteToFile ();
	}

	public void OnClickDie(){
		Application.Quit ();
	}

}
