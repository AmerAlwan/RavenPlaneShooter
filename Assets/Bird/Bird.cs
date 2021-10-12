using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
	public GameObject explosionAnimation;
	public GameObject planeScript;
	public static PlayerMovement plane;

	// Use this for initialization
	void Start ()
	{
		plane = planeScript.GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3 (transform.position.x - 10f, transform.position.y, 0);
		if (transform.position.x <= -10) {
			Destroy (gameObject);
		}
	}

	public void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Plane") {
			gameObject.SetActive (false);
			explosionAnimation.SetActive (true);
			explosionAnimation.transform.position = new Vector3 (plane.transform.position.x - 10, plane.transform.position.y - 10, 0);

			Destroy (gameObject);
			plane.GameOver ();

		}

		if (other.tag == "Enemy") {
			for (int i = 0; i < 10; i++) {
				transform.position = new Vector3 (transform.position.x, Random.Range (110f, 400f), 0);
			}
		}
	}
}
