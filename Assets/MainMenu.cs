using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public Button StartButton;
	public Button StoreButton;
	public Text title;
	public Text scoreText;
	public Text score;
	public Text highScoreText;
	public Text highScore;
	public bool map1 = true;
	public GameObject plane;
	public GameObject heli;
	public GameObject car;
	public int myCharacter;
	private GameObject[] sprites = new GameObject[3];
	public float points;
	public float highPoints;



	// Use this for initialization
	void Start ()
	{

		sprites [0] = plane;
		sprites [1] = heli;
		sprites [2] = car;

		if (points < PlayerPrefs.GetInt ("Score")) {
			points = PlayerPrefs.GetInt ("Score");
		}
		if (highPoints < PlayerPrefs.GetInt ("HighScore")) {
			highPoints = PlayerPrefs.GetInt ("HighScore");
		}


	
	}

	// Update is called once per frame
	void Update ()
	{
		myCharacter = PlayerPrefs.GetInt ("player");
		for (int i = 0; i < 3; i++) {
			sprites [i].SetActive (false);
			if (i == myCharacter) {
				sprites [i].SetActive (true);
			}
		}
			
		score.text = points.ToString ();
		highScore.text = highPoints.ToString ();


	}

	public void nextScene ()
	{
		if (map1) {
				SceneManager.LoadScene ("Map1");
		}
	}

	public void storeScene ()
	{
		SceneManager.LoadScene ("Store");
	}

	public void startButtonHover ()
	{ //This Function, which is attached to a pointer enter event trigger component in StartButton, will turn the Start Button Grey when a mouse hovers over it
		ColorBlock colors = StartButton.colors;
		colors.highlightedColor = Color.grey;
		StartButton.colors = colors;
	}

	public void noStartButtonHover ()
	{ //This Function, which is attached to a pointer exit event trigger component in StartButton, will turn the Start Button white when a mouse is not hovering over it
		ColorBlock colors = StartButton.colors;
		colors.highlightedColor = Color.white;
		StartButton.colors = colors; 
	}

	public void storeButtonHover ()
	{ //This Function, which is attached to a pointer enter event trigger component in StoreButton, will turn the Store Button Grey when a mouse hovers over it
		ColorBlock colors = StoreButton.colors;
		colors.highlightedColor = Color.grey;
		StoreButton.colors = colors;
	}

	public void noStoreButtonHover ()
	{ //This Function, which is attached to a pointer exit event trigger component in StoreButton, will turn the StoreButton white when a mouse is not hovering over it
		ColorBlock colors = StoreButton.colors;
		colors.highlightedColor = Color.white;
		StoreButton.colors = colors; 
	}

	public void resetGame ()
	{
		PlayerPrefs.SetInt ("player", 0);
		PlayerPrefs.SetInt ("Money", 0);
		PlayerPrefs.SetInt ("HeliPrice", 15000);
		PlayerPrefs.SetInt ("CarPrice", 30000);
		PlayerPrefs.SetInt ("Score", 0);
		PlayerPrefs.SetInt ("HighScore", 0);
		PlayerPrefs.SetInt ("Level", 0);

	}

}

