using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healthbar : MonoBehaviour {

	public RectTransform healthTransform;
	private float cachedY;
	private float minXvalue;
	private float maxXValue;
	private int currentHealth;
	private int maxHealth;
	private player playerr;


	// Use this for initialization
	void Start () {
		GameObject playerrObject = GameObject.Find ("player");
		if (playerrObject != null){
			playerr = playerrObject.GetComponent <player>();
		}
		if (playerr == null){
			Debug.Log ("Cannot find 'player' script");
		}
		cachedY = healthTransform.position.y;
		maxXValue = healthTransform.position.x;
		minXvalue = healthTransform.position.x - healthTransform.rect.width;
		Invoke ("gethealth", 0f);
	}
	
	// Update is called once per frame
	void Update () {
		currentHealth = playerr.energy;
		handlehealth ();
	}

	void handlehealth(){
		float currentXValue = MapValues (currentHealth, 0, maxHealth, minXvalue, maxXValue);
		healthTransform.position = new Vector2 (currentXValue, cachedY);
	}

	float MapValues(float x, float inMin, float inMax, float outMin, float outMax){
		return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
 	}

	void gethealth(){
		maxHealth = playerr.energy;
		currentHealth = maxHealth;
		print (maxHealth);
		print (currentHealth);
	}
}
