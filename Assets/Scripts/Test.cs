using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {
        //targetPosition.x = transform.position.z;
        //targetPosition.y = transform.position.y;

    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 targetPosition = target.transform.position;
        transform.LookAt(targetPosition, transform.up);
    }
}
