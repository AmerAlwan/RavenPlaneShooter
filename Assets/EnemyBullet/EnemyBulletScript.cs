using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
	private Vector3 endPoint;
	public GameObject planeScript;
	public static PlayerMovement plane;
	private float speed = 20f;

	// Use this for initialization
	void Start ()
	{
		endPoint = new Vector3 (-50, transform.position.y, 0);
		plane = planeScript.GetComponent<PlayerMovement> ();
	}

	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector2.MoveTowards (transform.position, endPoint, speed);
		if (transform.position.x <= -1000) {
			Destroy (gameObject);
		}
	}

	public void OnTriggerEnter2D (Collider2D other)
	{

		if (other.tag == "Plane") {
			gameObject.SetActive (false);
			Destroy (gameObject);
			plane.GameOver ();


		}


	}
}
