using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Agent {
	void Update () {
		if (gun.CanFire ()) {
			gun.Fire (transform);
		} else {
			if (gun.GetRounds () == 0) {
				gun.Reload ();
			}
		}
	}
}
