using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
	private float scroleSpeed = 0.4f;
	Renderer myRenderer;

	// Use this for initialization
	void Start ()
	{
		myRenderer = GetComponent<Renderer> ();
		if (PlayerPrefs.GetInt ("Level") == 1) {
			scroleSpeed = 0.6f;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector2 makeScrole = new Vector2 (Time.time * scroleSpeed, 0);
		myRenderer.material.mainTextureOffset = makeScrole;
	}
}
