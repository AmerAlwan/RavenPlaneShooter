using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Store : MonoBehaviour
{
	public Button easyBut;
	public Button hardBut;
	public Button planeBut;
	public Button heliBut;
	public Button carBut;
	public Button mapBut;
	public Text heliPrice;
	public Text carPrice;
	public Text moneyVar;
	private int money;
	private int[] price = new int[3];
	public Button[] sprites = new Button[3];

	// Use this for initialization
	void Start ()
	{
		sprites [0] = planeBut;
		price [0] = 0;
		sprites [1] = heliBut;
		price [1] = PlayerPrefs.GetInt ("HeliPrice");
		sprites [2] = carBut;
		price [2] = PlayerPrefs.GetInt ("CarPrice");
		money = PlayerPrefs.GetInt ("Money");
		for (int i = 0; i < 3; i++) {
			if (PlayerPrefs.GetInt ("player") == i) {
				changeText (i);
			}
		}
		if (PlayerPrefs.GetInt ("Level") == 0) {
			ColorBlock colors = easyBut.colors;
			colors.normalColor = Color.gray;
			easyBut.colors = colors;
		}
		if (PlayerPrefs.GetInt ("Level") == 1) {
			ColorBlock colors = hardBut.colors;
			colors.normalColor = Color.gray;
			hardBut.colors = colors;
		}
	

	}
	
	// Update is called once per frame
	void Update ()
	{
		for (int i = 0; i < 3; i++) {	
			if (PlayerPrefs.GetInt ("player") == i) {
				ColorBlock colors = sprites [i].colors;
				colors.normalColor = Color.gray;
				sprites [i].colors = colors;
				colors.highlightedColor = Color.gray;
				sprites [i].colors = colors;
			}
		}
		money = PlayerPrefs.GetInt ("Money");
		moneyVar.text = "$" + money.ToString ();
		heliPrice.text = price [1].ToString ();
		carPrice.text = price [2].ToString ();
	}

	public void planeButton ()
	{
		changeText (0);
		PlayerPrefs.SetInt ("player", 0);
	}

	public void heliButton ()
	{
		if (money >= price [1]) {
			changeText (1);
			PlayerPrefs.SetInt ("player", 1);
			PlayerPrefs.SetInt ("HeliPrice", 0);
			money -= price [1];
			PlayerPrefs.SetInt ("Money", money);
		}
	
	}

	public void carButton ()
	{
		if (money >= price [2]) {
			changeText (2);
			PlayerPrefs.SetInt ("player", 2);
			PlayerPrefs.SetInt ("CarPrice", 0);
			money -= price [2];
			PlayerPrefs.SetInt ("Money", money);
		}
	}

	public void easyButton ()
	{
		PlayerPrefs.SetInt ("Level", 0);
		if (PlayerPrefs.GetInt ("Level") == 0) {
			ColorBlock colors = easyBut.colors;
			colors.normalColor = Color.gray;
			easyBut.colors = colors;
			colors.highlightedColor = Color.gray;
			easyBut.colors = colors;
			easyBut.GetComponentInChildren<Text> ().text = "Coward :O";
			hardBut.GetComponentInChildren<Text> ().text = "HARD";
		
			colors = hardBut.colors;
			colors.normalColor = Color.white;
			hardBut.colors = colors;
		}

	}

	public void hardButton ()
	{
		PlayerPrefs.SetInt ("Level", 1);
		if (PlayerPrefs.GetInt ("Level") == 1) {
			ColorBlock colors = hardBut.colors;
			colors.normalColor = Color.gray;
			hardBut.colors = colors;
			colors.highlightedColor = Color.gray;
			hardBut.colors = colors;
			hardBut.GetComponentInChildren<Text> ().text = "Pro Gamer ;)";
			easyBut.GetComponentInChildren<Text> ().text = "EASY";

			colors = easyBut.colors;
			colors.normalColor = Color.white;
			easyBut.colors = colors;
		}
	}

	void changeText (int sprite)
	{
		for (int i = 0; i < 3; i++) {
			sprites [i].GetComponentInChildren<Text> ().text = "Purchase";
			ColorBlock colors = sprites [i].colors;
			colors.normalColor = Color.white;
			sprites [i].colors = colors;
			if (i == sprite) {
				sprites [i].GetComponentInChildren<Text> ().text = "Purchased";

			}
		}

	}

	public void backButton ()
	{
		SceneManager.LoadScene ("Scene 1");
	}
		
}



