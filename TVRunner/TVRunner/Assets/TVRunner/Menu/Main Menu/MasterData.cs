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
	void LoadFromFile(){
		//json
		SimpleJSON.JSONNode node = SimpleJSON.JSONNode.Parse(File.ReadAllText(Application.persistentDataPath +"/data.json"));
		gameVersion = node ["version"];
		volume = node ["volume"].AsFloat;
		levelMax = node ["levelmax"].AsInt;
		//Debug.Log(gameVersion + "\n" + volume.ToString() + "\n" + levelMax.ToString());
		//version.text = volume.ToString();
	}
	public static void WriteToFile(){
		//json
		SimpleJSON.JSONNode node = SimpleJSON.JSONNode.Parse(File.ReadAllText(Application.persistentDataPath +"/data.json"));
		node ["version"] = gameVersion;
		node ["volume"].AsFloat = volume;
		node ["levelmax"].AsInt = levelMax;
		File.WriteAllText(Application.persistentDataPath + "/data.json", node.ToString());

		//test
		/*if (System.IO.File.Exists("myfile.txt"))
		{
			//do stuff
		}*/
	}
	private void SetPlayerPrefs() {
		for (int i = 1; i <= 5; i++) {
			if(PlayerPrefs.HasKey ("Level " + i) == false){
				PlayerPrefs.SetFloat ("Level " + i, 0.0f);
			}
		}
	}
	public static float ChangeHighScore(string lvl, float scr){
		//jika lebih besar, set
		if (PlayerPrefs.GetFloat (lvl) < scr) { 
			PlayerPrefs.SetFloat (lvl, scr);
			return scr;
		} 
		return PlayerPrefs.GetFloat (lvl);
		//jika tidak, abaikan
	}
	// Use this for initialization
	void Start () {
		SetPlayerPrefs ();
		//DontDestroyOnLoad (transform.gameObject);
		if (!System.IO.File.Exists ("data.json")) {
			//Debug.Log("exist");
			string tmp = 
				"{\n" +
					"\t" + "\"version\" : \"v 1.1.1\" " + ", \n" + 
					"\t" + "\"volume\" : \"1.0\" " + ", \n" + 
					"\t" + "\"levelmax\" : \"5\" " + ", \n" + 
					"}";
			File.WriteAllText (Application.persistentDataPath + "/data.json", tmp);
			LoadFromFile ();
		} else {
			LoadFromFile ();
		}
		currentLevel = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (levelMax);
		version.text = gameVersion;
		AudioListener.volume = volume;
		//Debug.Log (volume.ToString ());
		/*if(Input.GetKeyDown("space")){
			//volume += 0.1f;
			WriteToFile();
		}*/
		if (currentLevel > levelMax) {
			levelMax = currentLevel;
			WriteToFile();
		}
		//Debug.Log (MasterData.GameVersion);
	}

	//setter getter
	public static string GameVersion
	{
		get { return gameVersion; }
		set { gameVersion = value; }
	}
}
