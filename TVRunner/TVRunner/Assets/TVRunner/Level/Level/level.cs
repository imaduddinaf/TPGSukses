using UnityEngine;
using System.Collections;

public class level : MonoBehaviour {

	public int batasPlayer;
	public int batasOperasi;
	public int nilaiBenar;
	public int nilaiSalah;
	public int batasMax;
	public int batasMin;
	public int energyDrain;
	private string currentLevel;

	// Use this for initialization
	void Start () {
		currentLevel = Application.loadedLevelName;
		Debug.Log (currentLevel);
		LevelHandler ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LevelHandler(){
		if (currentLevel == "Tutorial") {
			energyDrain = 1;
			batasPlayer = 4;
			batasOperasi = 5;
			nilaiBenar = 10;
			nilaiSalah = -3;
			batasMax = 10;
			batasMin = 0;
		}
		else if (currentLevel == "Level 1") {
			energyDrain = 1;
			batasPlayer = 4;
			batasOperasi = 2;
			nilaiBenar = 10;
			nilaiSalah = -3;
			batasMax = 10;
			batasMin = 0;
		}
		else if(currentLevel == "Level 2"){
			energyDrain = 1;
			batasPlayer = 4;
			batasOperasi = 2;
			nilaiBenar = 10;
			nilaiSalah = -3;
			batasMax = 10;
			batasMin = 0;
		}
	}
}
