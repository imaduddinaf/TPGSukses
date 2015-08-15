﻿using UnityEngine;
using System.Collections;

public class level : MonoBehaviour {

	public int batasPlayer;
	public int batasOperasi;
	public int batasBoperasi;
	public int nilaiBenar;
	public int nilaiSalah;
	public int batasMax;
	public int batasMin;
	public int energyDrain;
	public int bonusEnergy;
	public int scoreMax;
	public int jumlahBenar;
	public int jumlahSalah;
	private string currentLevel;
	public int[ , , ] itemTrueGroup = new int[100, 1, 2];
	public int jumlahGroup;
	void Awake () {
		currentLevel = Application.loadedLevelName;
		Debug.Log (currentLevel);
		batasBoperasi = 1;
		LevelHandler ();
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitTrueGroup(){
		Debug.Log ("init");
		for (int i = 1; i <= jumlahGroup; i++) {
			itemTrueGroup[i, 0, 0] = 1;
			itemTrueGroup[i, 0, 1] = 1;
		}
	}

	void LevelHandler(){
		if (currentLevel == "Tutorial") {
			bonusEnergy = 0;
			energyDrain = 3;
			batasPlayer = 4;
			batasOperasi = 3;
			nilaiBenar = 10;
			nilaiSalah = -8;
			batasMax = 10;
			batasMin = 0;
			jumlahBenar = 1;
			jumlahSalah = 1;
			jumlahGroup = 1;
			scoreMax = jumlahGroup * 1000;
			InitTrueGroup();
		}
		else if (currentLevel == "Level 1") {
			bonusEnergy = 0;
			energyDrain = 6;
			batasPlayer = 10;
			batasOperasi = 3;
			nilaiBenar = 60;
			nilaiSalah = -7;
			batasMax = 10;
			batasMin = 0;
			jumlahBenar = 2;
			jumlahSalah = 2;
			jumlahGroup = 3;
			scoreMax = jumlahGroup * 1000;
			InitTrueGroup();
		}
		else if(currentLevel == "Level 2"){
			bonusEnergy = 0;
			energyDrain = 3;
			batasPlayer = 10;
			batasOperasi = 3;
			nilaiBenar = 50;
			nilaiSalah = -15;
			batasMax = 10;
			batasMin = 0;
			jumlahBenar = 2;
			jumlahSalah = 2;
			jumlahGroup = 5;
			scoreMax = jumlahGroup * 1000;
			InitTrueGroup();
		}
		else if (currentLevel == "Level 3") {
			bonusEnergy = 0;
			energyDrain = 1;
			batasPlayer = 6;
			batasOperasi = 2;
			nilaiBenar = 8;
			nilaiSalah = -4;
			batasMax = 15;
			batasMin = 0;
			jumlahBenar = 2;
			jumlahSalah = 2;
			jumlahGroup = 2;
			scoreMax = jumlahGroup * 1000;
			InitTrueGroup();
		}
		else if(currentLevel == "Level 4"){
			bonusEnergy = 0;
			energyDrain = 1;
			batasPlayer = 6;
			batasOperasi = 2;
			nilaiBenar = 8;
			nilaiSalah = -4;
			batasMax = 15;
			batasMin = 0;
			jumlahBenar = 3;
			jumlahSalah = 3;
			scoreMax = 3000;
		}
		else if (currentLevel == "Level 5") {
			bonusEnergy = 0;
			energyDrain = 1;
			batasPlayer = 7;
			batasOperasi = 2;
			nilaiBenar = 8;
			nilaiSalah = -5;
			batasMax = 20;
			batasMin = -1;
			jumlahBenar = 2;
			jumlahSalah = 3;
			scoreMax = 2000;
		}
		else if(currentLevel == "Level 6"){
			bonusEnergy = 0;
			energyDrain = 1;
			batasPlayer = 7;
			batasBoperasi = 2;
			batasOperasi = 3;
			nilaiBenar = 8;
			nilaiSalah = -4;
			batasMax = 10;
			batasMin = 0;
			jumlahBenar = 2;
			jumlahSalah = 2;
			scoreMax = 2000;
		}
		else if (currentLevel == "Level 7") {
			bonusEnergy = 0;
			energyDrain = 1;
			batasPlayer = 7;
			batasBoperasi = 2;
			batasOperasi = 3;
			nilaiBenar = 8;
			nilaiSalah = -4;
			batasMax = 15;
			batasMin = 2;
			jumlahBenar = 3;
			jumlahSalah = 2;
			scoreMax = 3000;
		}
		else if(currentLevel == "Level 8"){
			bonusEnergy = 0;
			energyDrain = 1;
			batasPlayer = 8;
			batasBoperasi = 2;
			batasOperasi = 3;
			nilaiBenar = 8;
			nilaiSalah = -4;
			batasMax = 20;
			batasMin = 2;
			jumlahBenar = 3;
			jumlahSalah = 3;
			scoreMax = 3000;
		}
		else if (currentLevel == "Level 9") {
			bonusEnergy = 0;
			energyDrain = 2;
			batasPlayer = 8;
			batasBoperasi = 2;
			batasOperasi = 3;
			nilaiBenar = 7;
			nilaiSalah = -4;
			batasMax = 25;
			batasMin = 3;
			jumlahBenar = 3;
			jumlahSalah = 4;
			scoreMax = 3000;
		}
		else if(currentLevel == "Level 10"){
			bonusEnergy = 0;
			energyDrain = 1;
			batasPlayer = 8;
			batasOperasi = 3;
			nilaiBenar = 8;
			nilaiSalah = -4;
			batasMax = 15;
			batasMin = -1;
			jumlahBenar = 3;
			jumlahSalah = 3;
			scoreMax = 3000;
		}
		else if (currentLevel == "Level 11") {
			bonusEnergy = 0;
			energyDrain = 1;
			batasPlayer = 9;
			batasOperasi = 3;
			nilaiBenar = 7;
			nilaiSalah = -4;
			batasMax = 22;
			batasMin = -3;
			jumlahBenar = 4;
			jumlahSalah = 3;
			scoreMax = 4000;
		}
		else if(currentLevel == "Level 12"){
			bonusEnergy = 0;
			energyDrain = 2;
			batasPlayer = 9;
			batasOperasi = 3;
			nilaiBenar = 7;
			nilaiSalah = -4;
			batasMax = 29;
			batasMin = -5;
			jumlahBenar = 4;
			jumlahSalah = 4;
			scoreMax = 4000;
		}
		else if(currentLevel == "Level 13"){
			bonusEnergy = 0;
			energyDrain = 1;
			batasPlayer = 10;
			batasOperasi = 3;
			nilaiBenar = 6;
			nilaiSalah = -5;
			batasMax = 36;
			batasMin = -7;
			jumlahBenar = 4;
			jumlahSalah = 5;
			scoreMax = 4000;
		}
	}
}
