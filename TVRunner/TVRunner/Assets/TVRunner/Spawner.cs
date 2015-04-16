using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
	public Transform prefabGUI;
	public Transform prefabBackground;
	private Queue<Transform> queue;
	// Use this for initialization
	void Start () {
		queue = new Queue<Transform> (2);
		queue.Enqueue ((Transform)Instantiate (prefabGUI));
		queue.Enqueue ((Transform)Instantiate (prefabBackground));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
