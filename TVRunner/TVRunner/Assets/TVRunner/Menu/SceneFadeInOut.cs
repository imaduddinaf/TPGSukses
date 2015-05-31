﻿using UnityEngine;
using System.Collections;

public class SceneFadeInOut : MonoBehaviour {

	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
	private bool sceneStarting = true;      // Whether or not the scene is still fading in.
	private GUITexture guiTexture;
	void Awake () {
		guiTexture = GetComponent<GUITexture> ();
		// Set the texture so that it is the the size of the screen and covers it.
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}
	// Use this for initialization
	void Start () {
		// If the scene is starting...
		if(sceneStarting)
			// ... call the StartScene function.
			StartScene();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
	}

	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
	}

	void StartScene ()
	{
		// Fade the texture to clear.
		FadeToClear();
		
		// If the texture is almost clear...
		if(guiTexture.color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the GUITexture.
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;
			
			// The scene is no longer starting.
			sceneStarting = false;
		}
	}

	public void EndScene ()
	{
		// Make sure the texture is enabled.
		guiTexture.enabled = true;
		
		// Start fading towards black.
		FadeToBlack();
		
		// If the screen is almost black...
		if(guiTexture.color.a >= 0.95f)
			// ... reload the level.
			Application.LoadLevel("Main Menu");
	}
}