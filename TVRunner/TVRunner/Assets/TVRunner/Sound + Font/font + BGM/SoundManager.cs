using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public AudioSource[] sounds;
	public AudioSource ingameSound;
	public AudioSource mainMenuSound;
	public bool notIngame;
	public bool playedIngame; 
	public static int state = 1; //1 = menu2 dan 2 = ingame
	public static bool created = false;
	public static string scene;
	public bool changeState = false;
	//awake
	void Awake(){
		if (!created) {
			DontDestroyOnLoad (transform.gameObject);
			created = true;
		} else if (created){
			Destroy (transform.gameObject);
		}
		sounds = GetComponents<AudioSource> ();
		ingameSound = sounds [0];
		mainMenuSound = sounds [1];
	}
	// Use this for initialization
	void Start () {
		if ((Application.loadedLevelName == "Main Menu") || (Application.loadedLevelName == "Credits") || (Application.loadedLevelName == "World Map")) {
			//GetComponent<AudioSource> ().PlayOneShot (mainMenuSound);
			mainMenuSound.Play();
			notIngame = true;
		} else {
			//GetComponent<AudioSource> ().PlayOneShot (ingameSound);
			ingameSound.Play();
			playedIngame = true;
		}
		scene = Application.loadedLevelName;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (created + ingameSound + playedIngame);
		if (scene != Application.loadedLevelName) {
			if ((Application.loadedLevelName == "Main Menu") || (Application.loadedLevelName == "Credits") || (Application.loadedLevelName == "World Map")) {
				if (state != 1) {
					changeState = true;
				}
				notIngame = true;
				playedIngame = false;
				state = 1;
			} else {
				if (state != 2) {
					changeState = true;
				}
				notIngame = false;
				playedIngame = true;
				state = 2;
			}
			scene = Application.loadedLevelName;
		}
		if(changeState) {
			if (playedIngame) {
				//stop
				//GetComponent<AudioSource> ().Stop ();
				mainMenuSound.Stop();
				//play
				ingameSound.Play();
				//GetComponent<AudioSource> ().PlayOneShot (ingameSound);
			} else {
				//stop
				//GetComponent<AudioSource> ().Stop ();
				ingameSound.Stop();
				//play
				mainMenuSound.Play();
				//GetComponent<AudioSource> ().PlayOneShot (mainMenuSound);
			}
			changeState = false;
		}
	}
}
