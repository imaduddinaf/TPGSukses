using UnityEngine;
using System.Collections;

public class item : MonoBehaviour {

	// Use this for initialization
	public bool type;
	private int energyValue;
	private float scoreItem;
	private player playerr;
	private Runner2D runnerObj;
	private level levelHandle;
	public TextMesh displayText;
	private int inOperasi;
	public int bilangan1;
	public int bilangan2;
	private int rnd;
	public string name;
	public int number;
	public int group;
	//sound

	//init
	void Start () {
		GameObject levelObject = GameObject.Find ("Level Handle");
		if (levelObject != null){
			levelHandle = levelObject.GetComponent <level>();
		}
		if (levelHandle == null){
			Debug.Log ("Cannot find 'level' script");
		}

		GameObject playerrObject = GameObject.Find ("Runner 2D");
		if (playerrObject != null){
			playerr = playerrObject.GetComponent <player>();
		}
		if (playerr == null){
			Debug.Log ("Cannot find 'player' script");
		}
		//menentukan true atau false
		runnerObj = playerrObject.GetComponent <Runner2D> ();
		name = this.gameObject.name;
		number = int.Parse (name);
		Debug.Log ("===================");
		rnd = Random.Range (0, 2);
		//random apakah item ini nanti benar atau salah
		if (levelHandle.itemTrueGroup [group, 0] == 1) {
			if (number % 2 == 0) { //genap
				type = true;
				Debug.Log(number + " true");
				levelHandle.itemTrueGroup [group, 0] = 0;
			}
			else {
				if (rnd == 0) {
					type = false;
					Debug.Log(number + " false");
				} 
				else {
					type = true;
					Debug.Log(number + " true");
					levelHandle.itemTrueGroup [group, 0] = 0;
				}
			}
		} 
		else {
			Debug.Log(number + " false");
			type = false;
		}
		Invoke("GetOperasi",0.01f);
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.name == "Runner 2D"){
			playerr.AddEnergy(energyValue);
			runnerObj.AddScore(scoreItem);
			if(type){
				runnerObj.triggered=false;
				runnerObj.trueTriggered=true;
				runnerObj.falseTriggered=false;
				Debug.Log("benerr");
			}
			if(!type){
				runnerObj.triggered=false;
				runnerObj.falseTriggered=true;
				runnerObj.trueTriggered=false;
				Debug.Log("salahh");
			}
		}
	}


	void GetOperasi(){
		if (type == true) {
			scoreItem = 1000;
			energyValue = levelHandle.nilaiBenar;
			inOperasi = Random.Range (levelHandle.batasBoperasi, levelHandle.batasOperasi);
			if (inOperasi == 1) {
				bilangan1 = Random.Range (levelHandle.batasMin, playerr.playerValue+1);
				bilangan2 = playerr.playerValue - bilangan1;
				displayText.text = bilangan1 + " + " + bilangan2;
			} else if (inOperasi == 2) {
				bilangan1 = Random.Range (playerr.playerValue, levelHandle.batasMax);
				bilangan2 = bilangan1 - playerr.playerValue;
				displayText.text = bilangan1 + " - " + bilangan2;
			} /*else if (inOperasi == 3) {
				while (true) {
					bilangan1 = Random.Range (1, playerr.playerValue + 1);
					if (playerr.playerValue % bilangan1 == 0) {
						bilangan2 = playerr.playerValue / bilangan1;
						break;
					}
				}
				displayText.text = bilangan1 + " * " + bilangan2;
			} else if (inOperasi == 4) {
				bilangan2 = Random.Range (1, levelHandle.batasMin);
				bilangan1 = playerr.playerValue * bilangan2;
				displayText.text = bilangan1 + " / " + bilangan2;
			} */
		} 
		else {
			scoreItem = -750;
			energyValue = levelHandle.nilaiSalah;
			inOperasi = Random.Range (levelHandle.batasBoperasi, levelHandle.batasOperasi);
			bilangan1 = Random.Range(levelHandle.batasMin, levelHandle.batasMax);
			bilangan2 = Random.Range(levelHandle.batasMin, levelHandle.batasMax);
			if (inOperasi == 1) {
				if((bilangan1 + bilangan2) == playerr.playerValue){
					while(true){
						bilangan1 = Random.Range(levelHandle.batasMin, levelHandle.batasMax);
						bilangan2 = Random.Range(levelHandle.batasMin, levelHandle.batasMax);
						if(bilangan1 + bilangan2 != playerr.playerValue) break;
					}
				}
				displayText.text = bilangan1 + " + " + bilangan2;
			} else if (inOperasi == 2) {
				if((bilangan1 - bilangan2) == playerr.playerValue){
					while(true){
						bilangan1 = Random.Range(levelHandle.batasMin, levelHandle.batasMax);
						bilangan2 = Random.Range(levelHandle.batasMin, levelHandle.batasMax);
						if(bilangan1 - bilangan2 != playerr.playerValue) break;
					}
				}
				displayText.text = bilangan1 + " - " + bilangan2;
			} /*else if (inOperasi == 3) {
				if((bilangan1 * bilangan2) == playerr.playerValue){
					while(true){
						bilangan1 = Random.Range(levelHandle.batasMin, levelHandle.batasMax);
						bilangan2 = Random.Range(levelHandle.batasMin, levelHandle.batasMax);
						if(bilangan1 * bilangan2 != playerr.playerValue) break;
					}
				}
				displayText.text = bilangan1 + " * " + bilangan2;
			} else if (inOperasi == 4) {
				if((bilangan1 / bilangan2) == playerr.playerValue){
					while(true){
						bilangan1 = Random.Range(levelHandle.batasMin, levelHandle.batasMax);
						bilangan2 = Random.Range(levelHandle.batasMin, levelHandle.batasMax);
						if(bilangan1 / bilangan2 != playerr.playerValue) break;
					}
				}
				displayText.text = bilangan1 + " / " + bilangan2;
			}*/
		}
	}
}
