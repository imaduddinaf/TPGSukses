using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	//behaviour
	public void Pause(){
		Time.timeScale = 0;
	}

	public void UnPause(){
		Time.timeScale = 1.0f;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
