using UnityEngine;
using System.Collections;

public class Runner2D : MonoBehaviour {

	public float velocity;
	public float jumpHeight;

	private bool touchingPlatform;
	private float tmpX;

	private Vector3 vel;
	//behaviour
	void Die() {
		Debug.Log("Trigger Die");
		//Time.timeScale = 0;
		MasterData.currentLevel = 0;
		Application.LoadLevel ("Main Menu");
	}

	void Jump() {
		Debug.Log("jumped");
		//GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpHeight));
		GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpHeight), ForceMode2D.Force);
		//GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpHeight * Time.deltaTime * 4.0f), ForceMode2D.Impulse);
		//GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, jumpHeight);
	}

	void NextLevel() {
		MasterData.currentLevel += 1;
		Application.LoadLevel(Application.loadedLevel+1);
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {		
		//resume
		Debug.Log (Time.deltaTime);
		if(Input.GetButtonDown("Submit")){
			Time.timeScale = 1.0f;
		}
		if (touchingPlatform && (Input.GetKeyDown("space")/*GetButtonDown ("Jump") || Input.touchCount > 0*/)) {
			Jump();
		}
		//move runner
		transform.Translate(velocity * Time.deltaTime, 0f, 0f);

		//GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, 0f);
	}

	void FixedUpdate(){
		if (touchingPlatform && Input.touchCount > 0) {
			Jump ();
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
