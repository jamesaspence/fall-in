using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private int targetX = -15;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (TargetNeedsInversion()) {
	        targetX = -(targetX);
	    }

	    Vector3 direction;
	    if (targetX > 0) {
	        direction = Vector3.right;
	    } else {
	        direction = Vector3.left;
	    }
        
        transform.Translate(direction * (4f * Time.deltaTime));
	}

    private bool TargetNeedsInversion()
    {
        Vector3 position = transform.position;
        if (targetX > 0) {
            return position.x >= targetX;
        } else {
            return position.x <= targetX;
        }
    }
}
