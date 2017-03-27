using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour {

	private DateTime createdAt;

	// Use this for initialization
	void Start () {
		this.createdAt = System.DateTime.Now;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * (Time.deltaTime * 9f));
		if (this.createdAt <= System.DateTime.Now.Subtract(TimeSpan.FromMilliseconds (4000))) {
			DestroyBullet ();
		}
	}

	void OnCollisionEnter() 
	{
		Debug.Log ("Collision detected!");
		DestroyBullet ();
	}

	void DestroyBullet()
	{
		Debug.Log ("Destroying, goodbye cruel world");
		Destroy (gameObject);
	}
}
