using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGameObjectScript : MonoBehaviour
{
	public GameObject bullet;
	public Vector2 location;
	public float bulletTime = 0.5f;
	public GameObject plane;
	public GameObject heli;
	public GameObject car;
	private GameObject[] player = new GameObject[3];

	int p;
	public float tempTime = 15f;

	// Use this for initialization
	void Start ()
	{
		player [0] = plane;
		player [1] = heli;
		player [2] = car;

		for (int i = 0; i < 3; i++) {
			if (i == PlayerPrefs.GetInt ("player")) {
				p = i;
			}
		}
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButtonDown (0) && bulletTime >= tempTime) { //If left click or Space i clicked, it will call the shoot bullet function
			shootBullet (); 
		}
		bulletTime += 1f;
	}

	void shootBullet ()
	{
		//Determiens the location of the plane, and spawns the bullet there
		if (PlayerPrefs.GetInt ("player") == 0) {
			location = new Vector2 (player [p].transform.position.x, player [p].transform.position.y - 40);
		}
		if (PlayerPrefs.GetInt ("player") == 1) {
			location = new Vector2 (player [p].transform.position.x, player [p].transform.position.y - 20);
		}
		if (PlayerPrefs.GetInt ("player") == 2) {
			location = new Vector2 (player [p].transform.position.x, player [p].transform.position.y + 10);
		}

		bulletTime = tempTime - 15f;
		tempTime += 15f;
		Instantiate (bullet, location, Quaternion.identity);
	

	}

}
