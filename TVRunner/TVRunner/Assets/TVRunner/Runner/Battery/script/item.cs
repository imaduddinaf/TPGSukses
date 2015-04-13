using UnityEngine;
using System.Collections;

public class item : MonoBehaviour {

	// Use this for initialization
	public bool type;
	private int energyValue;
	private player playerr;
	public GUIText Tester;
	//private int vel;
	private int inoperasi;
	private int bilangan1;
	private int bilangan2;
	public Transform itemget;

	void Start () {
		GameObject playerrObject = GameObject.Find ("player");
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
	}

	
	// Update is called once per frame
	void Update () {
		//vel = playerr.playervalue;
		//Tester.text = "random2: " + vel;
	}
	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.name == "player")
		{
			Transform efek = Instantiate(itemget,transform.position,transform.rotation) as Transform;
			Destroy(efek.gameObject,1f);
			Destroy(gameObject);
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
				Tester.text = bilangan1 + " + " + bilangan2;
			} else if (inoperasi == 2) {
				bilangan1 = Random.Range (playerr.playervalue + 1, 99);
				bilangan2 = bilangan1 - playerr.playervalue;
				Tester.text = bilangan1 + " - " + bilangan2;
			} else if (inoperasi == 3) {
				bilangan2 = Random.Range (1, 20);
				bilangan1 = playerr.playervalue * bilangan2;
				Tester.text = bilangan1 + " / " + bilangan2;
			} else if (inoperasi == 4) {
				while (true) {
					bilangan1 = Random.Range (1, playerr.playervalue + 1);
					if (playerr.playervalue % bilangan1 == 0) {
						bilangan2 = playerr.playervalue / bilangan1;
						break;
					}
				}
				Tester.text = bilangan1 + " * " + bilangan2;
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
				Tester.text = bilangan1 + " + " + bilangan2;
			} else if (inoperasi == 2) {
				if((bilangan1 - bilangan2) == playerr.playervalue){
					while(true){
						bilangan1 = Random.Range(1,100);
						bilangan2 = Random.Range(1, 100);
						if(bilangan1 - bilangan2 != playerr.playervalue) break;
					}
				}
				Tester.text = bilangan1 + " - " + bilangan2;
			} else if (inoperasi == 3) {
				if((bilangan1 / bilangan2) == playerr.playervalue){
					while(true){
						bilangan1 = Random.Range(1,100);
						bilangan2 = Random.Range(1, 100);
						if(bilangan1 / bilangan2 != playerr.playervalue) break;
					}
				}
				Tester.text = bilangan1 + " / " + bilangan2;
			} else if (inoperasi == 4) {
				if((bilangan1 * bilangan2) == playerr.playervalue){
					while(true){
						bilangan1 = Random.Range(1,100);
						bilangan2 = Random.Range(1, 100);
						if(bilangan1 * bilangan2 != playerr.playervalue) break;
					}
				}
				Tester.text = bilangan1 + " * " + bilangan2;
			}
		}
	}
}
