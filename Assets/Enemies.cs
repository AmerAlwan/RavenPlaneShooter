using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
	public GameObject scoreScript;
	public static Score scorePoint;
	public GameObject planeScript;
	public static PlayerMovement planePoint;
	private float speed = 10f;
	Vector3 pointOfNoReturn;
	private Rigidbody enemy;
	public GameObject explosionAnimation;


	// Use this for initialization
	void Start ()
	{
		enemy = GetComponent<Rigidbody> ();
		explosionAnimation.SetActive (false);
		scorePoint = scoreScript.GetComponent<Score> ();
		planePoint = planeScript.GetComponent<PlayerMovement> ();
		if (PlayerPrefs.GetInt ("Level") == 1) {
			speed = 15f;
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
		
		pointOfNoReturn = new Vector3 (-10, transform.position.y, 0); //Literal Point of no return. The plane sprite gets destroyed upon crossing this point to avoid lag
		transform.position = Vector3.MoveTowards (transform.position, pointOfNoReturn, speed);
		if (transform.position.x <= -10) {
			scorePoint.depleteScore ();
			Destroy (gameObject);

		}
		Vector3 TempPos = new Vector3 (0, 0, 0);
		transform.position = Vector3.MoveTowards (transform.position, TempPos, 0.2f);
	}

	public void OnTriggerEnter2D (Collider2D other) //Will trigger when the Enemy Plane's box collider collides with another box collider. This function can be accessed when I check is trigger in the box collider section
	{
		if (other.tag == "Bullet") { //If statement that will run if the object that the box collider collided with has the tag of bullet
			gameObject.SetActive (false);
			explosionAnimation.SetActive (true);
			explosionAnimation.transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
			Destroy (gameObject);
			scorePoint.addScore ();
			//Destroys the enemy plane, and then makes an explosion at where the enemy plane was, and then adds a score


		}
		if (other.tag == "Plane") {
			planePoint.GameOver (); //If the enemy plane collides with the plane, then it will minus a live point from the player. And destroys the neemy plane
			gameObject.SetActive (false);
			explosionAnimation.SetActive (true);
			explosionAnimation.transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
			Destroy (gameObject);
		}



	}
}
