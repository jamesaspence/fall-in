using UnityEngine;
using System.Collections;

public class Player : Agent
{
	private Gun gun;

	// Use this for initialization
	void Start ()
	{
		this.gun = new Rifle ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown ("space")) {
			if (gun.CanFire ()) {
				gun.Fire ();
			} else {
				Debug.Log ("Can't fire.");
				Debug.Log ("Number of rounds: " + gun.GetRounds ());
			}
		}

		if (Input.GetKeyDown ("r")) {
			Debug.Log ("reload button!");
			gun.Reload ();
		}
	}

	void ShootGun()
	{
		// Test code - will be removed
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