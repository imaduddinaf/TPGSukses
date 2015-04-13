using UnityEngine;
using System.Collections;

public class Runner2D : MonoBehaviour {

	public float velocity;
	public float jumpHeight;

	private bool touchingPlatform;
	private float tmpX;
	//behaviour
	void Die() {
		Debug.Log("Trigger Die");
		Time.timeScale = 0;
	}

	public void Jump() {
		Debug.Log("jumped");
		GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpHeight));
	}

	void NextLevel() {
		Application.LoadLevel(Application.loadedLevel);
	}

	// Use this for initialization
	void Start () {
		tmpX = GetComponent<Transform> ().position.x;
	}
	
	// Update is called once per frame
	void Update () {		
		//resume
		if(Input.GetButtonDown("Submit")){
			Time.timeScale = 1.0f;
		}
		//move runner
		transform.Translate(velocity * Time.deltaTime, 0f, 0f);
		if (tmpX < GetComponent<Transform> ().position.x) {
			//Die ();
		}
		tmpX = GetComponent<Transform> ().position.x;
	}

	void FixedUpdate(){
		if (touchingPlatform && (Input.GetButtonDown ("Jump") || Input.touchCount > 0)) {
			Jump();
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "spike" || col.gameObject.tag == "box die") {
			Die ();
		}
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "portal") {
			Debug.Log("Next Level");
			NextLevel();
		}
		touchingPlatform = true;
	}
	
	void OnCollisionExit2D () {
		touchingPlatform = false;
	}
}
