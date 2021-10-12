using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
	public float speed = 5f;
	public bool invincible = false;
	public GameObject plane;
	public GameObject heli;
	public GameObject car;
	private Rigidbody player;
	private Vector3 mousePos;
	private Vector2 direction;
	private Vector2[] tempPlanePos = new Vector2[3];
	private Vector3 preMousePos = new Vector3 (0, 0, 0);
	private Vector3 rightEnd = new Vector3 (50, 0, 0);
	private GameObject[] sprites = new GameObject[3];
	private GameObject[] hearts = new GameObject[3];
	public GameObject explosionAnimation;

	private int heartModifier = 0;
	int p;
	private int life = 3;


	private bool playAnimation = true;

	// Use this for initialization
	void Start ()
	{
		
		playAnimation = true;
		explosionAnimation.SetActive (false);
		sprites [0] = plane; //Assigning all the planes to the sprite array
		sprites [1] = heli;
		sprites [2] = car;
		hearts [0] = GameObject.Find ("Heart1");
		hearts [1] = GameObject.Find ("Heart2");
		hearts [2] = GameObject.Find ("Heart3");
		for (int i = 0; i < 3; i++) {
			if (i == PlayerPrefs.GetInt ("player")) {
				player = sprites [i].GetComponent<Rigidbody> (); //Declaring RigidBody in all the planes in the sprite arrays
				p = i;
			}
		}

		if (PlayerPrefs.GetInt ("Level") == 0) {
			sprites [0].transform.localScale = new Vector3 (12, 12, 10); //If the diffculty is easy, it makes the planes smaller.
			sprites [1].transform.localScale = new Vector3 (45, 45, 1);
			sprites [2].transform.localScale = new Vector3 (16, 16, 1);
		}
		if (PlayerPrefs.GetInt ("Level") == 1) {						//If the diffculty is hard, it makes the planes bigger
			sprites [0].transform.localScale = new Vector3 (14, 14, 12);
			sprites [1].transform.localScale = new Vector3 (55, 55, 1);
			sprites [2].transform.localScale = new Vector3 (19, 19, 1);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition); //Records the position of the mouse in the game
		float angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg; //Takes the position of the mouse and calculates it's angle where y=0 is 0 degrees, and y = 300 is 90 degrees
		Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward); //Calculates how much the plane sprite will rotate forwards acording to the angle previously calculates
		sprites [p].transform.rotation = Quaternion.Slerp (sprites [p].transform.rotation, rotation, speed * Time.deltaTime);  //Rotates the plane acording to the previous rotations
		//As you can guess, I got this piece of code online, it was orignally made for the purposes where you have a character that can rotate a full 360 following your mouse. 
		//So you can assume that when I made this, the plane would literally follow my mouse everywhere, hence, in the code below, I had to alter some stuff to make the plane rotation 
		//more realistic

		if (playAnimation) { //This animation makes the plane inside the map whenever you start the game
			if (sprites [p].transform.position != rightEnd) {
				sprites [p].transform.position = Vector3.MoveTowards (sprites [p].transform.position, rightEnd, 5);
			} else {
				playAnimation = false;
			}
		}
	
		sprites [p].transform.position = Vector2.MoveTowards (sprites [p].transform.position, mousePos, 8f); //This code will mkae the plane slowly move towards the mouse instead of just teleporting wherever the mouse is,
		//which would have given the plane an unrealistic moving animation
		sprites [p].transform.Rotate (Vector3.back, 10); //As I said before, The rotation code I have was a bit exagerated, in the sense where the plane would literally rotate everywhere my mouse went
		//So in order to tackle the issue, I added this code that will rotate the plane slightly against the mouse, making the acceleration and deacceleration smoother and 
		//more realistic, the plane will still flip upside down following my mouse, however, you can't do that because then the mouse would  leave the game
		sprites [p].transform.position = new Vector3 (sprites [p].transform.position.x, sprites [p].transform.position.y - 0.8f, 0); //This line adds a bit of gravity and struggle whenver accelerating, just like a real plane,
		//DO NOTE, I was going to use rigid body, but there was a glitch where after  minute of flying the plane would completely stop accelerating
	

		if (sprites [p].transform.position.x > 300) { //This creates a border in the y-axis so the plane can't fly beyond the end of the map
			sprites [p].transform.position = new Vector3 (300, sprites [p].transform.position.y, 0);
		}
		if (sprites [p].transform.position.x < 30) { //This creates a border in the y-axis so the plane can't fly beyond the beggening of the map
			sprites [p].transform.position = new Vector3 (30, sprites [p].transform.position.y, 0);
		}
		if (sprites [p].transform.position.y > 450) { //This creates a border in the x-axis so the plane can't fly above the map
			sprites [p].transform.position = new Vector3 (sprites [p].transform.position.x, 450, 0);
		}
		if (sprites [p].transform.position.y < 10) { //This creates a border in the x-axis so the plane can't fly below the map
			sprites [p].transform.position = new Vector3 (sprites [p].transform.position.x, 10, 0);
		}

		//Because all the sprites where different in terms of their size, I had to alter the position of the hearts according to which plane they follow
		if (PlayerPrefs.GetInt ("player") == 0) { 
			heartModifier = 45;
		}
		if (PlayerPrefs.GetInt ("player") == 1) {
			heartModifier = 100;
		}
		if (PlayerPrefs.GetInt ("player") == 2) {
			heartModifier = 110;
		}

		//This code makes the hearts follow below the plane at a fixed x & y positions (that change according to where the plane is)

		tempPlanePos [0].x = sprites [p].transform.position.x - 130 + heartModifier;
		tempPlanePos [0].y = sprites [p].transform.position.y - 70;
		hearts [0].transform.position = Vector2.MoveTowards (hearts [0].transform.position, tempPlanePos [0], 30f);

		tempPlanePos [1].x = sprites [p].transform.position.x - 115 + heartModifier;
		tempPlanePos [1].y = sprites [p].transform.position.y - 70;
		hearts [1].transform.position = Vector2.MoveTowards (hearts [1].transform.position, tempPlanePos [1], 30f);

		tempPlanePos [2].x = sprites [p].transform.position.x - 100 + heartModifier;
		tempPlanePos [2].y = sprites [p].transform.position.y - 70;
		hearts [2].transform.position = Vector2.MoveTowards (hearts [2].transform.position, tempPlanePos [2], 30f);

		//If Up arrow key is pressed, you become invincible, unkillable!. If you press down arrow, you can be killed again
		if (Input.GetKey (KeyCode.UpArrow)) {
			invincible = true;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			invincible = false;
		}


	}

	public void GameOver () //The name is misleading, If this class is called, it will take away one of the 3 lives, and only when you have 0 lives, does it 
	{

		explosionAnimation.SetActive (true); //In all, whenver a playr loses a life, there will be an explosion at their position
		if (PlayerPrefs.GetInt ("player") == 0) {
			explosionAnimation.transform.position = new Vector3 (transform.position.x - 150, transform.position.y - 10, 0);
		}
		if (PlayerPrefs.GetInt ("player") == 1) {
			explosionAnimation.transform.position = new Vector3 (transform.position.x - 20, transform.position.y - 20, 0);
		}
		if (PlayerPrefs.GetInt ("player") == 2) {
			explosionAnimation.transform.position = new Vector3 (transform.position.x, transform.position.y + 10, 0);
		}
			
		life -= 1;
		if (invincible) {
			life = 3;
		}
		if (life == 3) {
			hearts [0].SetActive (true);
			hearts [1].SetActive (true);
			hearts [2].SetActive (true);
		}
		if (life == 2) {
			hearts [2].SetActive (false);
		}
		if (life == 1) {
			hearts [1].SetActive (false);
		}
		if (life <= 0) { //Switches to the GameOver Scene when hit 0 lives
			SceneManager.LoadScene ("GameOver");
		}
	}


}
