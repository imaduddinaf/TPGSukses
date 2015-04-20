using UnityEngine;
using System.Collections;

public class item : MonoBehaviour {

	// Use this for initialization
	public bool type;
	private int energyValue;
	private player playerr;
	//public GUIText Tester;
	public TextMesh displayText;
	//private int vel;
	private int inOperasi;
	public int bilangan1;
	public int bilangan2;
	public Transform itemParticle;


	void Start () {
		GameObject playerrObject = GameObject.Find ("Runner 2D");
		if (playerrObject != null){
			playerr = playerrObject.GetComponent <player>();
		}
		if (playerr == null){
			Debug.Log ("Cannot find 'player' script");
		}
		Invoke("getOperasi",0f);

	}

	
	// Update is called once per frame
	void Update () {
		//vel = playerr.playervalue;
		//Tester.text = "random2: " + vel;
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.name == "Runner 2D")
		{
			Destroy(gameObject);
			Transform efek = Instantiate(itemParticle,transform.position,transform.rotation) as Transform;
			Destroy(efek.gameObject,1f);
			playerr.AddEnergy(energyValue);
			Debug.Log("Asdasd : " + energyValue);
		}
	}
	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.name == "Runner 2D")
		{
			Destroy(gameObject);
			Transform efek = Instantiate(itemParticle,transform.position,transform.rotation) as Transform;
			Destroy(efek.gameObject,1f);
			playerr.AddEnergy(energyValue);
		}
	}

	void getOperasi(){
		//vel = playerr.playervalue;
		if (type == true) {
			energyValue = 5;
			inOperasi = Random.Range (1, 5);
			if (inOperasi == 1) {
				bilangan1 = Random.Range (1, playerr.playerValue);
				bilangan2 = playerr.playerValue - bilangan1;
				displayText.text = bilangan1 + " + " + bilangan2;
			} else if (inOperasi == 2) {
				bilangan1 = Random.Range (playerr.playerValue + 1, 99);
				bilangan2 = bilangan1 - playerr.playerValue;
				displayText.text = bilangan1 + " - " + bilangan2;
			} else if (inOperasi == 3) {
				bilangan2 = Random.Range (1, 10);
				bilangan1 = playerr.playerValue * bilangan2;
				displayText.text = bilangan1 + " / " + bilangan2;
			} else if (inOperasi == 4) {
				while (true) {
					bilangan1 = Random.Range (1, playerr.playerValue + 1);
					if (playerr.playerValue % bilangan1 == 0) {
						bilangan2 = playerr.playerValue / bilangan1;
						break;
					}
				}
				displayText.text = bilangan1 + " * " + bilangan2;
			}
		} 
		else {
			energyValue = -3;
			inOperasi = Random.Range (1, 5);
			bilangan1 = Random.Range(1,100);
			bilangan2 = Random.Range(1,100);
			if (inOperasi == 1) {
				if((bilangan1 + bilangan2) == playerr.playerValue){
					while(true){
						bilangan1 = Random.Range(1,100);
						bilangan2 = Random.Range(1,100);
						if(bilangan1 + bilangan2 != playerr.playerValue) break;
					}
				}
				displayText.text = bilangan1 + " + " + bilangan2;
			} else if (inOperasi == 2) {
				if((bilangan1 - bilangan2) == playerr.playerValue){
					while(true){
						bilangan1 = Random.Range(1,100);
						bilangan2 = Random.Range(1, 100);
						if(bilangan1 - bilangan2 != playerr.playerValue) break;
					}
				}
				displayText.text = bilangan1 + " - " + bilangan2;
			} else if (inOperasi == 3) {
				if((bilangan1 / bilangan2) == playerr.playerValue){
					while(true){
						bilangan1 = Random.Range(1,100);
						bilangan2 = Random.Range(1, 100);
						if(bilangan1 / bilangan2 != playerr.playerValue) break;
					}
				}
				displayText.text = bilangan1 + " / " + bilangan2;
			} else if (inOperasi == 4) {
				if((bilangan1 * bilangan2) == playerr.playerValue){
					while(true){
						bilangan1 = Random.Range(1,100);
						bilangan2 = Random.Range(1, 100);
						if(bilangan1 * bilangan2 != playerr.playerValue) break;
					}
				}
				displayText.text = bilangan1 + " * " + bilangan2;
			}
		}
	}
}
