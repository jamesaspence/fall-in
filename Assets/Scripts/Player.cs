using UnityEngine;
using System.Collections;

public class Player : Agent
{

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown ("space")) {
			Debug.Log ("fired!");
			ShootGun ();
		}
	}

	void ShootGun()
	{
		RaycastHit hit;

		Debug.Log(transform.position);
		Debug.Log (transform.forward);

		Ray bullet = new Ray (transform.position, transform.forward);
		if (Physics.Raycast (bullet, out hit, 11f)) {
			GameObject gameObject = hit.collider.gameObject;
			Debug.Log (gameObject);
		} else {
			Debug.Log ("No dice.");
		}
		Debug.Log ("Started!");
	}
}