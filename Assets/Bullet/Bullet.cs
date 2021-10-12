using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


	private Vector3 endGoal;
	private float speed = 50f;
	private Vector3 mousePos;
	private Vector3 posMouse;
	private GameObject plane;
	private int playerModifier;
	private int angleModifier;


	// Use this for initialization

	void Start ()
	{
		if (PlayerPrefs.GetInt ("player") == 0) {
			playerModifier = 0;
			angleModifier = 8;
		}
		if (PlayerPrefs.GetInt ("player") == 1) {
			playerModifier = 0; //20
			angleModifier = 15;
		}
		if (PlayerPrefs.GetInt ("player") == 2) {
			playerModifier = 50;
			angleModifier = 13;
		}
		plane = GameObject.FindGameObjectWithTag ("Plane");

		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);


		//Getting the direction of travel of the bullet right was the most annoying thing. I need it to travel towards the mouse, yet also maintain the correct angle corresponding to the plane's tilted angle
		//So everything below, is basically modifying the directiont he bullet travels depending on the angle. There is no process here, this was all type based solely on guess and check
		// of what seemed to work. At the end, when the angle got above 90 degrees, I couldnt fix it, nothing worked. So youll notice a bg, if you title the plane really high, the bullet's angle and 
		//direction of travel will looks wrong. But even in other angles, sometimes I miss something, and youll notice in game, sometimes bugs happen where the direction of travel is weird
		//Also, the other plane sprites had different angles, so I added a plane modifier that changes the direction of travel to match the specific plane. Again, this is based on guess and check
		float angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		if (angle >= 87 && angle < 90) {
			posMouse = new Vector3 (mousePos.x * 100, ((mousePos.y - transform.position.y) + -40 + playerModifier) * 100, 0);
		} else if (angle >= 79 && angle < 87) {
			posMouse = new Vector3 (mousePos.x * 100, ((mousePos.y - transform.position.y) + 0 + playerModifier) * 100, 0);
	
		} else if (angle >= 72 && angle < 79) {
			angleModifier = 20;
			posMouse = new Vector3 (mousePos.x * 100, ((mousePos.y - transform.position.y) + -20 + playerModifier) * 100, 0);

		} else if (angle >= 60 && angle < 72) {
			posMouse = new Vector3 (mousePos.x * 100, ((mousePos.y - transform.position.y) + -20 + playerModifier) * 100, 0);
		} else if (angle > 58 && angle < 60) {
			posMouse = new Vector3 (mousePos.x * 100, ((mousePos.y - transform.position.y) - 10 + playerModifier) * 100, 0);
		} else if (angle < 52 && angle >= 20) {
			posMouse = new Vector3 (mousePos.x * 100, ((mousePos.y - transform.position.y) - 100 + playerModifier) * 100, 0);
		} else if (angle < 20) {
			posMouse = new Vector3 (mousePos.x * 100, ((mousePos.y - transform.position.y) - 200 + playerModifier) * 100, 0);
		} else if (angle >= 44 || angle <= 49) {
			posMouse = new Vector3 (mousePos.x * 100, ((mousePos.y - transform.position.y) - 40 + playerModifier) * 100, 0); //44-49
		}
		angle -= angleModifier;
		Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, 1000f);
		transform.Rotate (Vector3.back, 45); //Alters the angle of th ebullet to match the tilt of the plane

	


	}
	
	// Update is called once per frame
	void Update ()
	{


		endGoal = new Vector3 (1000, transform.position.y, 0); //The bullet will travel to this point befor ebeing destroyed. Again to avoid lag from too much bullets
		transform.position = Vector2.MoveTowards (transform.position, posMouse, speed);
		if (transform.position.x >= 1000 && transform.position.x < 1200) {
			Destroy (gameObject); 
		}

	}
}
