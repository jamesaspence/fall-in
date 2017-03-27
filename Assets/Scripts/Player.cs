﻿using UnityEngine;
using System.Collections;

public class Player : Agent
{
	public Gun gun;
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown ("space")) {
			if (gun.CanFire ()) {
				gun.Fire (transform);
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
}