using UnityEngine;
using System.Collections;

public class Player : Agent
{

	// Use this for initialization
	void Start ()
	{
		RaycastHit hit;
		Ray bullet = new Ray (transform.position, Vector3.up);
		if (Physics.Raycast (bullet, out hit, 11f)) {
			GameObject gameObject = hit.collider.gameObject;
			Debug.Log (gameObject);
		} else {
			Debug.Log ("No dice.");
		}
		Debug.Log ("Started!");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

