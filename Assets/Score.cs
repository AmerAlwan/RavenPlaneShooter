using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
	public Text scoreText;
	public Text highScoreText;
	public  int score;
	public int highScore;
	private GameObject player;
	public Text moneyVar;
	private int money;


	// Use this for initialization
	void Start ()
	{
		score = 0;
		highScore = PlayerPrefs.GetInt ("HighScore");
		money = PlayerPrefs.GetInt ("Money");
		player = GameObject.FindGameObjectWithTag ("Plane");
	}

	void Update ()
	{
		scoreText.text = score.ToString ();
		highScoreText.text = highScore.ToString ();
		moneyVar.text = "$" + money.ToString ();
		if (score > highScore) {
			highScore = score;
		}
		PlayerPrefs.SetInt ("Score", score);
		PlayerPrefs.SetInt ("HighScore", highScore);
		PlayerPrefs.SetInt ("Money", money);

	
		
	}

	public void addScore ()
	{
		score += 360;
		money += 13234;

	}

	public void depleteScore ()
	{
		score -= 720;
		if (score <= 0) {
			score = 0;
		}


	}

	public void menuButton ()
	{
		SceneManager.LoadScene ("Scene 1");
	}
}
