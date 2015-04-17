using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClickPlay(){
		Application.LoadLevel ("World Map");
		MasterData.WriteToFile ();
	}

	public void OnClickDie(){
		Application.Quit ();
	}

}
