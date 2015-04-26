using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healthbar : MonoBehaviour {

	public RectTransform healthTransform;
	private float cachedY;
	private float cachedZ;
	private float cachedX;
	private float minXvalue;
	private float maxXValue;
	private int currentHealth;
	private int maxHealth;
	private player playerr;
	public Canvas canvasHealth;
	
	// Use this for initialization
	void Start () {
		GameObject playerrObject = GameObject.Find ("Runner 2D");
		if (playerrObject != null){
			playerr = playerrObject.GetComponent <player>();
		}
		if (playerr == null){
			Debug.Log ("Cannot find 'player' script");
		}
		cachedY = healthTransform.position.y;
		cachedX = healthTransform.position.x;
		maxXValue = healthTransform.position.x;
		minXvalue = healthTransform.position.x - healthTransform.rect.width * canvasHealth.scaleFactor;
		//print (healthTransform.rect.width);
		//print (minXvalue);
		Invoke ("GetHealth", 0f);
	}
	
	// Update is called once per frame
	void Update () {
		currentHealth = playerr.energy;
		HandleHealth ();
	}

	void HandleHealth(){
		float currentXValue = MapValues (currentHealth, 0, maxHealth, minXvalue, maxXValue);
		//Debug.Log ("currentX Value" +currentXValue);
		if (currentXValue > cachedX)
			currentXValue = cachedX;
		//Debug.Log ("currentX Value2 " +currentXValue);
 		healthTransform.position = new Vector2 (currentXValue, cachedY);
	}

	float MapValues(float x, float inMin, float inMax, float outMin, float outMax){
		return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
 	}

	void GetHealth(){
		maxHealth = playerr.energy;
		//Debug.Log ("maxhealth" +maxHealth);
		currentHealth = maxHealth;
		//Debug.Log ("currenthealt" +currentHealth);
	}
}
