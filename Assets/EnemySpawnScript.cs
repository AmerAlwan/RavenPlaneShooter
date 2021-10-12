using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

	public GameObject enemy;
	float randY;
	public Vector2 spawnLocation;
	//Where to Spawn
	private float spawnRate = 1.5f;
	//2
	public float spawnTime = 3.5f;
	//nextSpawn //1

	// Use this for initialization
	void Start ()
	{
		if (PlayerPrefs.GetInt ("Level") == 1) {
			spawnRate = 0.8f;
		}

	}

	// Update is called once per frame
	void Update ()
	{
		if (Time.time > spawnTime) {
			spawnTime = Time.time + spawnRate;
			randY = Random.Range (110f, 400f);
			spawnLocation = new Vector2 (transform.position.x, randY);
			Instantiate (enemy, spawnLocation, Quaternion.identity); //Picked this one up from online. it bascially duplicates the enemy sprite and spawns it at the (randomized) location I choose
		}
	
	}
}
