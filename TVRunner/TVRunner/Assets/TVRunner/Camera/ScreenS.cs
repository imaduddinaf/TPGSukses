using UnityEngine;
using System.Collections;

public class ScreenS : MonoBehaviour {
	
	public float velocity;
	// Use this for initialization
	void Start () {
		Runner2D runner = GetComponent<Runner2D> ();
		if (runner != null) {
			velocity = runner.velocity;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(velocity * Time.deltaTime, 0f, 0f);
	}
}
