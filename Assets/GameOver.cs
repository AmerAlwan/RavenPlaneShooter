using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public Text jokeText;
	public Text scoreText;
	public Text score;
	public Text highScoreText;
	public Text highScore;
	public float points;
	public float highPoints;
	public string[] jokes = new string[10];
	private int randJoke;


	// Use this for initialization
	void Start ()
	{
		//Randomly selects one of the jokes
		randJoke = Random.Range (0, 10);
		jokes [0] = "What do you call it when you're sick at the airport? \nTerminal Sickness";
		jokes [1] = "What do you call a plane that's about to crash? \nAn Error Plane";
		jokes [2] = "What kind of chocolate do they sell at the airport? \nPlane chocolate";
		jokes [3] = "What do you call the movie where pilots fight to take off? \nThe Hanger Games";
		jokes [4] = "What do you call a space pilot who lives dangerously? \nHan YOLO";
		jokes [5] = "What do you get when you cross an airplane with a magician? \nA Flying Sorcerer";
		jokes [6] = "Why don't ducks tell jokes when they fly? \nBecause they would quack up!";
		jokes [7] = "Why can't spiders become pilots? \nBecause they only know how to tailspin";
		jokes [8] = "Where can you find Tom Cruise on a flight? \nIn Risky Bussiness Class";
		jokes [9] = "What do you get when you put a flight stick in an egg? \nA yoke";
			
		//Accesses the score and highscore playerprefs
		if (points < PlayerPrefs.GetInt ("Score")) {
			points = PlayerPrefs.GetInt ("Score");
		}
		if (highPoints < PlayerPrefs.GetInt ("HighScore")) {
			highPoints = PlayerPrefs.GetInt ("HighScore");
		}
		jokeText.text = jokes [randJoke];

	}
	
	// Update is called once per frame
	void Update ()
	{
		//Prints the scores on screen in a text
		score.text = points.ToString ();
		highScore.text = highPoints.ToString ();
	}

	public void menuButton ()
	{
		SceneManager.LoadScene ("Scene 1");
	}

	public void storeButton ()
	{
		SceneManager.LoadScene ("Store");
	}

	public void restartButton ()
	{
		SceneManager.LoadScene ("Map1");

	}
}
