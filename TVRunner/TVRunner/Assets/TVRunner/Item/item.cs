using UnityEngine;
using System.Collections;

public class item : MonoBehaviour {

	// Use this for initialization
	public bool type;
	private int energyValue;
	private player playerr;
	//public GUIText Tester;
	public TextMesh displaytext;
	//private int vel;
	private int inoperasi;
	public int bilangan1;
	public int bilangan2;
	public Transform itemget;

	void Start () {
		GameObject playerrObject = GameObject.Find ("Runner 2D");
		if (playerrObject != null){
			playerr = playerrObject.GetComponent <player>();
		}
		if (playerr == null){
			Debug.Log ("Cannot find 'player' script");
		}
		//vel = playerr.playervalue;
		//Tester.text = "random2: " + vel;
		Invoke("getovel",0f);
		//getovel ();
		//boo.text = "test";

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
			Transform efek = Instantiate(itemget,transform.position,transform.rotation) as Transform;
			Destroy(efek.gameObject,1f);
			playerr.AddEnergy(energyValue);
			Debug.Log("Asdasd : " + energyValue);
		}
	}
	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.name == "Runner 2D")
		{
			Destroy(gameObject);
			Transform efek = Instantiate(itemget,transform.position,transform.rotation) as Transform;
			Destroy(efek.gameObject,1f);
			playerr.AddEnergy(energyValue);
		}
	}

	void getovel(){
		//vel = playerr.playervalue;
		if (type == true) {
			energyValue = 5;
			inoperasi = Random.Range (1, 5);
			if (inoperasi == 1) {
				bilangan1 = Random.Range (1, playerr.playervalue);
				bilangan2 = playerr.playervalue - bilangan1;
				displaytext.text = bilangan1 + " + " + bilangan2;
			} else if (inoperasi == 2) {
				bilangan1 = Random.Range (playerr.playervalue + 1, 99);
				bilangan2 = bilangan1 - playerr.playervalue;
				displaytext.text = bilangan1 + " - " + bilangan2;
			} else if (inoperasi == 3) {
				bilangan2 = Random.Range (1, 10);
				bilangan1 = playerr.playervalue * bilangan2;
				displaytext.text = bilangan1 + " / " + bilangan2;
			} else if (inoperasi == 4) {
				while (true) {
					bilangan1 = Random.Range (1, playerr.playervalue + 1);
					if (playerr.playervalue % bilangan1 == 0) {
						bilangan2 = playerr.playervalue / bilangan1;
						break;
					}
				}
				displaytext.text = bilangan1 + " * " + bilangan2;
			}
		} 
		else {
			energyValue = -3;
			inoperasi = Random.Range (1, 5);
			bilangan1 = Random.Range(1,100);
			bilangan2 = Random.Range(1, 100);
			if (inoperasi == 1) {
				if((bilangan1 + bilangan2) == playerr.playervalue){
					while(true){
						bilangan1 = Random.Range(1,100);
						bilangan2 = Random.Range(1, 100);
						if(bilangan1 + bilangan2 != playerr.playervalue) break;
					}
				}
				displaytext.text = bilangan1 + " + " + bilangan2;
			} else if (inoperasi == 2) {
				if((bilangan1 - bilangan2) == playerr.playervalue){
					while(true){
						bilangan1 = Random.Range(1,100);
						bilangan2 = Random.Range(1, 100);
						if(bilangan1 - bilangan2 != playerr.playervalue) break;
					}
				}
				displaytext.text = bilangan1 + " - " + bilangan2;
			} else if (inoperasi == 3) {
				if((bilangan1 / bilangan2) == playerr.playervalue){
					while(true){
						bilangan1 = Random.Range(1,100);
						bilangan2 = Random.Range(1, 100);
						if(bilangan1 / bilangan2 != playerr.playervalue) break;
					}
				}
				displaytext.text = bilangan1 + " / " + bilangan2;
			} else if (inoperasi == 4) {
				if((bilangan1 * bilangan2) == playerr.playervalue){
					while(true){
						bilangan1 = Random.Range(1,100);
						bilangan2 = Random.Range(1, 100);
						if(bilangan1 * bilangan2 != playerr.playervalue) break;
					}
				}
				displaytext.text = bilangan1 + " * " + bilangan2;
			}
		}
	}
}
