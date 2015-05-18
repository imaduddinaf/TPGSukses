using UnityEngine;
using System.Collections;

public class ScreenS : MonoBehaviour {
	
	private float velocity;
	private Runner2D runner;
	// Use this for initialization
	void Start () {
		GameObject playerrObject = GameObject.Find ("Runner 2D");
		runner = playerrObject.GetComponent <Runner2D> ();
		//Runner2D runner = GetComponent<Runner2D> ();
		//if (runner != null) {
			velocity = runner.tmpVelocity;
		//}
	}
	
	// Update is called once per frame
	void Update () {
		velocity = runner.tmpVelocity;
		transform.Translate(velocity * Time.deltaTime, 0f, 0f);
	}
}
