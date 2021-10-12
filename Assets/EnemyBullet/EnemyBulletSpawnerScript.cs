using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawnerScript : MonoBehaviour
{
	public GameObject bullet;
	private GameObject[] enemy;
	float randY;
	public Vector2 spawnLocation;
	//Where to Spawn
	private float spawnRate = 1f;
	//2
	float spawnTime;
	//nextSpawn //1 //0.1f

	// Use this for initialization
	void Start ()
	{
		spawnTime = Random.Range (0.090f, 0.03f);
	}

	// Update is called once per frame
	void Update ()
	{
		if (Time.time > spawnTime) {
			enemy = GameObject.FindGameObjectsWithTag ("Enemy");
			spawnTime = Time.time + spawnRate;
			for (int i = 0; i < enemy.Length; i++) {
				spawnLocation = new Vector2 (enemy [i].transform.position.x, enemy [i].transform.position.y);
				Instantiate (bullet, spawnLocation, Quaternion.identity);
				print (transform.position);
			}
		}

	}
}
