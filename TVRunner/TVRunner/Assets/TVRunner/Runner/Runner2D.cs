using UnityEngine;
using System.Collections;

public class Runner2D : MonoBehaviour {

	public float velocity;
	public float jumpHeight;

	private bool touchingPlatform;
	void Die() {

	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {		
		transform.Translate(velocity * Time.deltaTime, 0f, 0f);
		if (GetComponent<Transform>().position.x > 200) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	void FixedUpdate(){
		if (touchingPlatform && (Input.GetButtonDown ("Jump") || Input.touchCount > 0)) {
			Debug.Log("jumped");
			//GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, jumpHeight, 0.0f));
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpHeight));
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.name == "Spike" || col.gameObject.name == "Box Front") {
			Debug.Log("Trigger Die");
			Die ();
		}
		if (col.gameObject.name == "Portal") {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		touchingPlatform = true;
	}
	
	void OnCollisionExit2D () {
		touchingPlatform = false;
	}
}
