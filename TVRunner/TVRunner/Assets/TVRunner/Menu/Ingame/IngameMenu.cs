using UnityEngine;
using System.Collections;

public class IngameMenu : MonoBehaviour {
	//behaviour
	public void Pause(){
		Time.timeScale = 0;
	}

	public void UnPause(){
		Time.timeScale = 1.0f;
	}

	public void RestartLevel(){

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			//Time.timeScale = 0;
			Application.Quit();
		}
	}

	void OnGUI(){

	}
}
