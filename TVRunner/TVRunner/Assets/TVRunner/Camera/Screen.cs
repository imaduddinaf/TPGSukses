using UnityEngine;
using System.Collections;

public class Screen : MonoBehaviour {
	
	public float velocity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(velocity * Time.deltaTime, 0f, 0f);
	}
}
