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
	public int bonusEnergy;
	public int scoreMax;
	public int jumlahBenar;
	public int jumlahSalah;
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
			bonusEnergy = 0;
			energyDrain = 1;
			batasPlayer = 4;
			batasOperasi = 3;
			nilaiBenar = 10;
			nilaiSalah = -3;
			batasMax = 10;
			batasMin = 0;
			jumlahBenar = 1;
			jumlahSalah = 1;
			scoreMax = 1000;
		}
		else if (currentLevel == "Level 1") {
			bonusEnergy = 0;
			energyDrain = 1;
			batasPlayer = 4;
			batasOperasi = 2;
			nilaiBenar = 10;
			nilaiSalah = -3;
			batasMax = 10;
			batasMin = 0;
			jumlahBenar = 2;
			jumlahSalah = 2;
			scoreMax = 2000;
		}
		else if(currentLevel == "Level 2"){
			bonusEnergy = 0;
			energyDrain = 1;
			batasPlayer = 4;
			batasOperasi = 2;
			nilaiBenar = 10;
			nilaiSalah = -3;
			batasMax = 10;
			batasMin = 0;
			jumlahBenar = 2;
			jumlahSalah = 2;
			scoreMax = 2000;
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
			scoreMax = 2000;
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
			batasPlayer = 4;
			batasOperasi = 2;
			nilaiBenar = 10;
			nilaiSalah = -3;
			batasMax = 10;
			batasMin = 0;
			jumlahBenar = 2;
			jumlahSalah = 3;
			scoreMax = 2000;
		}
		else if(currentLevel == "Level 6"){
			bonusEnergy = 0;
			energyDrain = 1;
			batasPlayer = 4;
			batasOperasi = 2;
			nilaiBenar = 10;
			nilaiSalah = -3;
			batasMax = 10;
			batasMin = 0;
			jumlahBenar = 2;
			jumlahSalah = 2;
			scoreMax = 2000;
		}
		else if (currentLevel == "Level 7") {
			bonusEnergy = 0;
			energyDrain = 1;
			batasPlayer = 4;
			batasOperasi = 2;
			nilaiBenar = 10;
			nilaiSalah = -3;
			batasMax = 10;
			batasMin = 0;
			jumlahBenar = 3;
			jumlahSalah = 2;
			scoreMax = 3000;
		}
		else if(currentLevel == "Level 8"){
			bonusEnergy = 0;
			energyDrain = 1;
			batasPlayer = 4;
			batasOperasi = 2;
			nilaiBenar = 10;
			nilaiSalah = -3;
			batasMax = 10;
			batasMin = 0;
			jumlahBenar = 3;
			jumlahSalah = 3;
			scoreMax = 3000;
		}
		else if (currentLevel == "Level 9") {
			bonusEnergy = 0;
			energyDrain = 1;
			batasPlayer = 4;
			batasOperasi = 2;
			nilaiBenar = 10;
			nilaiSalah = -3;
			batasMax = 10;
			batasMin = 0;
			jumlahBenar = 3;
			jumlahSalah = 4;
			scoreMax = 3000;
		}
		else if(currentLevel == "Level 10"){
			bonusEnergy = 0;
			energyDrain = 1;
			batasPlayer = 4;
			batasOperasi = 2;
			nilaiBenar = 10;
			nilaiSalah = -3;
			batasMax = 10;
			batasMin = 0;
			jumlahBenar = 3;
			jumlahSalah = 3;
			scoreMax = 3000;
		}
		else if (currentLevel == "Level 11") {
			bonusEnergy = 0;
			energyDrain = 1;
			batasPlayer = 4;
			batasOperasi = 2;
			nilaiBenar = 10;
			nilaiSalah = -3;
			batasMax = 10;
			batasMin = 0;
			jumlahBenar = 4;
			jumlahSalah = 3;
			scoreMax = 4000;
		}
		else if(currentLevel == "Level 12"){
			bonusEnergy = 0;
			energyDrain = 1;
			batasPlayer = 4;
			batasOperasi = 2;
			nilaiBenar = 10;
			nilaiSalah = -3;
			batasMax = 10;
			batasMin = 0;
			jumlahBenar = 4;
			jumlahSalah = 4;
			scoreMax = 4000;
		}
		else if(currentLevel == "Level 13"){
			bonusEnergy = 0;
			energyDrain = 1;
			batasPlayer = 4;
			batasOperasi = 2;
			nilaiBenar = 10;
			nilaiSalah = -3;
			batasMax = 10;
			batasMin = 0;
			jumlahBenar = 4;
			jumlahSalah = 5;
			scoreMax = 4000;
		}
	}
}
