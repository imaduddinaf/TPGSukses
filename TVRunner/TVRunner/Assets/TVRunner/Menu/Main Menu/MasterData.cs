using UnityEngine;
using System.Collections;
using System.IO;
using SimpleJSON;
using UnityEngine.UI;

public class MasterData : MonoBehaviour {
	private string data;
	public Text version;
	public static int currentLevel = 0;
	public static float volume;
	public static string gameVersion;
	public static int levelMax;
	void LoadFromFile(){
		//json
		SimpleJSON.JSONNode node = SimpleJSON.JSONNode.Parse(File.ReadAllText(Application.dataPath +"/data.json"));
		gameVersion = node ["version"];
		volume = node ["volume"].AsFloat;
		levelMax = node ["levelmax"].AsInt;
		//Debug.Log(gameVersion + "\n" + volume.ToString() + "\n" + levelMax.ToString());
		//version.text = volume.ToString();
	}
	public static void WriteToFile(){
		//json
		SimpleJSON.JSONNode node = SimpleJSON.JSONNode.Parse(File.ReadAllText(Application.dataPath +"/data.json"));
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
	// Use this for initialization
	void Start () {
		//DontDestroyOnLoad (transform.gameObject);
		if (System.IO.File.Exists ("data.json")) {
			Debug.Log("exist");
			string tmp = 
				"{\n" +
					"\t" + "\"version\" : \"v 1.0\" " + ", \n" + 
					"\t" + "\"volume\" : \"1.0\" " + ", \n" + 
					"\t" + "\"levelmax\" : \"13\" " + ", \n" + 
					"}";
			File.WriteAllText (Application.dataPath + "/data.json", tmp);
			LoadFromFile ();
		} else {
			LoadFromFile ();
		}
		levelMax = 13;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (levelMax);
		version.text = gameVersion;
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
