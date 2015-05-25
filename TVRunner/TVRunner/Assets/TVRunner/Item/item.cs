using UnityEngine;
using System.Collections;

public class item : MonoBehaviour {

	// Use this for initialization
	private bool type;
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
		runnerObj = playerrObject.GetComponent <Runner2D> ();
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
			}
			if(!type){
				runnerObj.triggered=false;
				runnerObj.falseTriggered=true;
				runnerObj.trueTriggered=false;
			}
		}
	}


	void GetOperasi(){
		rnd = Random.Range (0, 2);
		if (rnd == 0) {
			if (levelHandle.jumlahBenar == 0) {
				type = false;
				levelHandle.jumlahSalah--;
			} else {
				type = true;
				levelHandle.jumlahBenar--;
			}
		} else if (rnd == 1) {
			if (levelHandle.jumlahSalah == 0) {
				type = true;
				levelHandle.jumlahBenar--;
			} else {
				type = false;
				levelHandle.jumlahSalah--;
			}
		}
		if (type == true) {
			scoreItem = 1000;
			energyValue = levelHandle.nilaiBenar;
			inOperasi = Random.Range (1, levelHandle.batasOperasi);
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
			inOperasi = Random.Range (1, levelHandle.batasOperasi);
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
