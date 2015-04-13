using UnityEngine;
using System.Collections;


public class text : MonoBehaviour {

	private item itemm;
	private float posY;
	private float posX;
	public Transform textfield;

	// Use this for initialization
	void Start () {
		GameObject itemmObject = GameObject.Find ("true item");
		if (itemmObject != null){
			itemm = itemmObject.GetComponent <item>();
		}
		if (itemm == null){
			Debug.Log ("Cannot find 'item' script");
		}
		posY = textfield.position.y;
		posX = textfield.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		fixpos ();
	}

	void fixpos(){
		if (itemm.bilangan1 >= 10 && itemm.bilangan2 >= 10) {
			print (itemm.bilangan1);
			//posX = 1;
			//textfield.position = new Vector2 (posX, posY);
		} else if (itemm.bilangan1 < 10 && itemm.bilangan2 < 10) {
			//textfield.position = new Vector2 (-0.7f, posY);
			print ("as");
		} 
		else {
			//textfield.position = new Vector2 (0.8f, posY);
			print ("das");
		}
	}
}
