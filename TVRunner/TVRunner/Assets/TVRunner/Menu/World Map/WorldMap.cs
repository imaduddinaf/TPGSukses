using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WorldMap : MonoBehaviour {	
	public Sprite starShine;
	public Sprite starBlack;
	public Sprite openIcon;
	public Sprite lockIcon;
	public Text version;
	private GameObject[] levelIcons = new GameObject[16];
	private GameObject[] starPrnt = new GameObject[161];
	private GameObject[,] stars = new GameObject[16, 4];
	// Use this for initialization
	void Start () {
		//init icon
		for (int i = 1; i <= 15; i++) {
			levelIcons[i] = GameObject.Find ("Level" + i);
			levelIcons[i].GetComponent<Button>().interactable = false;
		}
		for (int i = 1; i <= MasterData.maxLevel; i++) {
			starPrnt[i] = GameObject.Find ("Star" + i);
		}
		for (int i = 1; i <= MasterData.maxLevel; i++) {
			for (int j = 1; j <= 3; j++) {
				//float idx = i + (j / 10);
				stars[i, j] = GameObject.Find ("Star" + i + "-" + j);
			}
		}
		//check, is level unlocked?
		for (int i = 1; i <= MasterData.maxLevel; i++) {
			if (i <= MasterData.levelMax) {
				//change icon
				levelIcons[i].GetComponent<Image>().sprite = openIcon;
				levelIcons[i].GetComponent<Button>().interactable = true;
				Text[] tmp = levelIcons[i].gameObject.GetComponentsInChildren<Text>();
				tmp[0].text = i + "";
				//star
				starPrnt[i].SetActive(true);
				Debug.Log("highscore lv " + i + " = " + PlayerPrefs.GetFloat("Level " + i));
				//number of star
				if(PlayerPrefs.GetFloat("Level " + i) < 0.34 && PlayerPrefs.GetFloat("Level " + i) > 0) {
					stars[i, 2].GetComponent<Image>().sprite = starShine;
				}
				else if (PlayerPrefs.GetFloat("Level " + i) < 0.76 && PlayerPrefs.GetFloat("Level " + i) > 0) {
					stars[i, 2].GetComponent<Image>().sprite = starShine;
					stars[i, 1].GetComponent<Image>().sprite = starShine;
				}
				else if (PlayerPrefs.GetFloat("Level " + i) <= 1 && PlayerPrefs.GetFloat("Level " + i) > 0) {
					stars[i, 2].GetComponent<Image>().sprite = starShine;
					stars[i, 1].GetComponent<Image>().sprite = starShine;
					stars[i, 3].GetComponent<Image>().sprite = starShine;
				}
				Debug.Log("Level " + i + " = " + PlayerPrefs.GetFloat("Level " + i));
			}
			else {
				//change icon
				levelIcons[i].GetComponent<Image>().sprite = lockIcon;
				levelIcons[i].GetComponent<Button>().interactable = false;
				Text[] tmp = levelIcons[i].gameObject.GetComponentsInChildren<Text>();
				tmp[0].text = "";
				//star
				starPrnt[i].SetActive(false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			//Time.timeScale = 0;
			//Application.Quit();
			//Pause();
			BackToMainMenuButton();
		}
		//Debug.Log (MasterData.GameVersion);
	}

	public void BackToMainMenuButton(){
		Application.LoadLevel ("Main Menu");
	}
	//level picker
	public void Tutorial(){
		MasterData.currentLevel = 0;
		Application.LoadLevel ("Tutorial");
	}
	public void Level1(){
		MasterData.currentLevel = 1;
		Application.LoadLevel ("Level 1");
	}
	public void Level2(){
		MasterData.currentLevel = 2;
		Application.LoadLevel ("Level 2");
	}
	public void Level3(){
		MasterData.currentLevel = 3;
		Application.LoadLevel ("Level 3");
	}
	public void level4(){
		MasterData.currentLevel = 4;
		Application.LoadLevel ("Level 4");
	}
	public void level5(){
		MasterData.currentLevel = 5;
		Application.LoadLevel ("Level 5");
	}
	public void level6(){
		MasterData.currentLevel = 6;
		Application.LoadLevel ("Level 6");
	}
	public void level7(){
		MasterData.currentLevel = 7;
		Application.LoadLevel ("Level 7");
	}
	public void level8(){
		MasterData.currentLevel = 8;
		Application.LoadLevel ("Level 8");
	}
	public void level9(){
		MasterData.currentLevel = 9;
		Application.LoadLevel ("Level 9");
	}
	public void level10(){
		MasterData.currentLevel = 10;
		Application.LoadLevel ("Level 10");
	}
	public void level11(){
		MasterData.currentLevel = 11;
		Application.LoadLevel ("Level 11");
	}
	public void level12(){
		MasterData.currentLevel = 12;
		Application.LoadLevel ("Level 12");
	}
	public void level13(){
		MasterData.currentLevel = 13;
		Application.LoadLevel ("Level 13");
	}
	public void level14(){
		MasterData.currentLevel = 14;
		Application.LoadLevel ("Level 15");
	}
	public void level15(){
		MasterData.currentLevel = 14;
		Application.LoadLevel ("Level 15");
	}

}
