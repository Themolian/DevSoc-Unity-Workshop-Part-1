using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawn : MonoBehaviour {

	public float bulletSpeed = 1000;
	public Rigidbody2D BulletPrefab;
	public Transform muzzlePoint1;

	public float spawnTime = 5f;
	public float spawnDelay = 0f;

	public float thrust = 1.0f;

	// Use this for initialization
	void Start () 
	{

		InvokeRepeating("Spawn", spawnDelay, spawnTime);

	}
	
	// Update is called once per frame
	void Update () 
	{


	}

	void Spawn()
	{

		Rigidbody2D bulletInstance = Instantiate(BulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 1))) as Rigidbody2D;
         bulletInstance.AddForce(-BulletPrefab.transform.right * thrust);

	}
}
