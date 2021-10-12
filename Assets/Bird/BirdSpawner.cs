using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
	public GameObject bird;
	private GameObject enemy;
	float randY;
	Vector2 spawnLocation;
	//Where to Spawn
	public float spawnRate = 4f;
	//2
	public float spawnTime = 3.5f;
	//nextSpawn //1

	// Use this for initialization
	void Start ()
	{
		if (PlayerPrefs.GetInt ("Level") == 1) {
			spawnRate = 2f;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time > spawnTime) {
			spawnTime = Time.time + spawnRate;
			randY = Random.Range (110f, 400f);
			spawnLocation = new Vector2 (transform.position.x, randY);
			Instantiate (bird, spawnLocation, Quaternion.identity);
		}
	}
}
