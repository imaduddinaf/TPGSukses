using UnityEngine;
using System.Collections;
using System.IO;
using SimpleJSON;
using UnityEngine.UI;

public class MasterData : MonoBehaviour {
	private string data;
	public Text version;
	public static int currentLevel;
	public static float volume;
	public static string gameVersion;
	public static int levelMax;
	public static int maxLevel;
	void LoadFromFile(){
		volume = PlayerPrefs.GetFloat ("Volume");
		levelMax = PlayerPrefs.GetInt ("Level Max");
		maxLevel = PlayerPrefs.GetInt ("Max Level");
		gameVersion = PlayerPrefs.GetString ("Version").ToString();
		Debug.Log (volume + "");
		//json
		/*SimpleJSON.JSONNode node = SimpleJSON.JSONNode.Parse(File.ReadAllText(Application.persistentDataPath +"/data.json"));
		gameVersion = node ["version"];
		volume = node ["volume"].AsFloat;
		levelMax = node ["levelmax"].AsInt;*/
		//Debug.Log(gameVersion + "\n" + volume.ToString() + "\n" + levelMax.ToString());
		//version.text = volume.ToString();
	}
	public static void WriteToFile(){
		PlayerPrefs.SetFloat ("Volume", volume);
		PlayerPrefs.SetInt ("Level Max", levelMax);
		PlayerPrefs.SetInt ("Max Level", maxLevel);
		PlayerPrefs.SetString ("Version", "0.1");
		//Debug.Log (volume + "");
		Debug.Log ("levelmax : " + levelMax);
		Debug.Log ("pref : " + PlayerPrefs.GetInt ("Level Max"));
		PlayerPrefs.Save ();
		//json
		/*SimpleJSON.JSONNode node = SimpleJSON.JSONNode.Parse(File.ReadAllText(Application.persistentDataPath +"/data.json"));
		node ["version"] = gameVersion;
		node ["volume"].AsFloat = volume;
		node ["levelmax"].AsInt = levelMax;
		File.WriteAllText(Application.persistentDataPath + "/data.json", node.ToString());*/
	}
	private void InitPlayerPrefs(){
		//simpan punya perf
		PlayerPrefs.SetInt ("Perf", 1);
		//simpan volume
		if (PlayerPrefs.HasKey ("Volume") == false) {
			PlayerPrefs.SetFloat ("Volume", 1.0f);
		}
		//simpan gameversion
		if (PlayerPrefs.HasKey ("Version") == false) {
			PlayerPrefs.SetString ("Version", "0.1");
		}
		//simpan level max
		if (PlayerPrefs.HasKey ("Level Max") == false) {
			PlayerPrefs.SetInt ("Level Max", 2);
		}
		//simpan max level
		if (PlayerPrefs.HasKey ("Max Level") == false || PlayerPrefs.GetInt("Max Level") < 5) {
			PlayerPrefs.SetInt ("Max Level", 5);
		}
		//simpan skor level
		SetScore ();
	}
	private void SetScore() {
		for (int i = 1; i <= levelMax; i++) {
			if(PlayerPrefs.HasKey ("Level " + i) == false){
				PlayerPrefs.SetFloat ("Level " + i, 0.0f);
			}
		}
		//WriteToFile ();
	}
	public static float ChangeHighScore(string lvl, float scr){
		//jika lebih besar, set
		if (PlayerPrefs.GetFloat (lvl) < scr) { 
			PlayerPrefs.SetFloat (lvl, scr);
			return scr;
		} 
		return PlayerPrefs.GetFloat (lvl);
		WriteToFile ();
		//jika tidak, abaikan
	}
	public static void ChangeLevelMax(){
		if (currentLevel > levelMax) {
			Debug.Log(currentLevel + " : " + levelMax);
			levelMax = currentLevel;
			WriteToFile();
		}
	}
	// Use this for initialization
	void Start () {
		//awal instal
		if (PlayerPrefs.HasKey ("Perf") == false) {
			//set gameversion
			//set volume
			//set max level yang sudah dicapai
			//set skor tiap level
			Debug.Log("asd");
			InitPlayerPrefs ();
		} 
		InitPlayerPrefs ();
		LoadFromFile();
		currentLevel = 1;
	}
	
	// Update is called once per frame
	void Update () {
		version.text = gameVersion;
		AudioListener.volume = volume;
		ChangeLevelMax ();
		//WriteToFile();
	}

	//setter getter
	public static string GameVersion
	{
		get { return gameVersion; }
		set { gameVersion = value; }
	}
}
